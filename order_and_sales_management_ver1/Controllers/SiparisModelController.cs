using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Order_And_Sales_Management_ver1.Data;
using Order_And_Sales_Management_ver1.Models;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Order_And_Sales_Management_ver1.Controllers
{
    public class SiparisModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SiparisModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Liste()
        {
            List<OrderModel> siparis = new List<OrderModel>();
            siparis = _context.OrderModel.Include(b => b.orderdetailsmodels)
                                                                     .Include(b => b.orderLocation)
                                                                     .Include(c => c.orderOwnerEmployeeModel)
                                .ToList();
            foreach (OrderModel order in siparis)
            {
                order.orderOwnerEmployeeModel = _context.employeesmodels.FirstOrDefault(e => e.personelID == order.orderOwner_personelID); 
            }
            foreach (OrderModel order in siparis)
            {
                foreach (OrderDetailsModel orderDetails in order.orderdetailsmodels)
                        orderDetails.ProductModel = _context.productmodels.FirstOrDefault(e => e.productID== orderDetails.productID);
            }

            return View(siparis);

        }

        [HttpGet]
        public ActionResult Giris(string productName)
        {
            SiparisModel siparis=new SiparisModel();
            siparis.orderDate = DateTime.Now;
            ViewData["personelID"] = new SelectList(_context.employeesmodels, nameof(SiparisModel.orderOwnerEmployeeModel.personelID), nameof(SiparisModel.orderOwnerEmployeeModel.persName));
            EmployeesModels employees = _context.employeesmodels.First();
            siparis.orderLocation = _context.stocklocationmodel.FirstOrDefault(e => e.locationID == employees.locationID);
            if (!String.IsNullOrEmpty(productName))
            {
                siparis.products = _context.productmodels.Where(x => x.ProductName.Contains(productName)).ToList();
            }
            else
            {
                siparis.products = new List<ProductModel>();

            }
            return View(siparis);
        }
        [HttpPost]
        public ActionResult Giris(string jsonSiparis, string jsonOrderDetails)
        {
            JObject jobjSiparis;
            JArray jobjOrderDetails;
            OrderModel siparis=new OrderModel();

            siparis.orderdetailsmodels = new List<OrderDetailsModel>();

            if (ModelState.IsValid)
            {
                CultureInfo provider = CultureInfo.InvariantCulture;

                jobjSiparis = JObject.Parse(jsonSiparis);
                foreach (KeyValuePair<String, JToken> app in jobjSiparis)
                {
                    var appName = app.Key;
                    var value = (String)app.Value;
                    switch (appName)
                    {
                        case "orderDate":
                            siparis.orderDate = DateTime.ParseExact(value,"MM/dd/yyyy HH:mm:ss",provider);
                            break;
                        case "orderOwner_personelID":
                            siparis.orderOwner_personelID = int.Parse(value);
                            break;
                        case "LocationID":
                            siparis.orderLocationID = int.Parse(value);
                            break;
                    }
                }
                siparis.recStatus = Program.Const_Active_Order;
                jobjOrderDetails = JArray.Parse(jsonOrderDetails);
                foreach (JObject jObj in jobjOrderDetails)
                {
                    if (jObj != null) 
                     {
                        OrderDetailsModel orderDetails = new OrderDetailsModel();
                        foreach (KeyValuePair<String, JToken> app in jObj)
                        {
                            var appName = app.Key;
                            var value = (String)app.Value;
                            switch (appName)
                            {
                                case "orderLineNo":
                                    orderDetails.orderLineNo = int.Parse(value);
                                    break;
                                case "productID":
                                    orderDetails.productID = int.Parse(value);
                                    break;
                                case "productAmount":
                                    orderDetails.productAmount = int.Parse(value);
                                    break;
                            }
                        }
                        orderDetails.recStatus = Program.Const_Active_Order;
                        siparis.orderdetailsmodels.Add(orderDetails);
                    }
                }
                _context.Add(siparis);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Giris),new { productName = "" });
        }

        public bool StockItemExists(int prodID,  string lotID)
        {
            int locID = Program.Const_Production_Location;
            return _context.stockitems.Any(e => e.productID == prodID && e.locationID == locID && e.productionLotID == lotID);
        }

        public stocklocationmodel getLocation(int employeeID)
        {
            EmployeesModels employee;
            stocklocationmodel stocklocationmodel;

            employee=_context.employeesmodels.FirstOrDefault(e => e.personelID == employeeID);
            stocklocationmodel = _context.stocklocationmodel.FirstOrDefault(e => e.locationID == employee.locationID);
            return stocklocationmodel;
        }

        public SiparisModel getProducts(string productName)
        {
            SiparisModel siparis = new SiparisModel();
            if (!String.IsNullOrEmpty(productName))
            {
                siparis.products = _context.productmodels.Where(x => x.ProductName.Contains(productName)).ToList();
            }
            else
            {
                siparis.products = new List<ProductModel>();

            }
            return siparis;
        }


    }
}