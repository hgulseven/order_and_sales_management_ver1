using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using order_and_sales_management_ver1.Data;
using order_and_sales_management_ver1.Models;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace order_and_sales_management_ver1.Controllers
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

            if (User.Identity.IsAuthenticated)
            {
                int location = int.Parse(HttpContext.User.Claims.Where(c => c.Type == "location").FirstOrDefault().Value.ToString());
                if (location == 1)
                {
                    siparis = _context.OrderModel.Include(b => b.orderdetailsmodels)
                                                                             .Include(b => b.orderLocation)
                                                                             .Include(c => c.orderOwnerEmployeeModel)
                                                                             .Where(t => t.recStatus == Program.Const_Active_Order)
                                                                             .ToList();
                }
                else
                {
                    siparis = _context.OrderModel.Include(b => b.orderdetailsmodels)
                                                                             .Include(b => b.orderLocation)
                                                                             .Include(c => c.orderOwnerEmployeeModel)
                                                                             .Where(t => t.recStatus == Program.Const_Active_Order && t.orderLocationID == location)
                                                                             .ToList();
                }
                foreach (OrderModel order in siparis)
                {
                    order.orderOwnerEmployeeModel = _context.employeesmodels.FirstOrDefault(e => e.personelID == order.personelID);
                }
                foreach (OrderModel order in siparis)
                {
                    foreach (OrderDetailsModel orderDetails in order.orderdetailsmodels)
                        orderDetails.ProductModel = _context.productmodels.FirstOrDefault(e => e.productID == orderDetails.productID);
                }
            } else
            {
                ModelState.AddModelError("User", "İşlem yapabilmeniz için sisteme giriş yapınız.");
            }
            return View(siparis);
        }

        [HttpGet]
        public ActionResult Giris(string productName)
        {

           SiparisModel siparis = new SiparisModel();
            if (User.Identity.IsAuthenticated)
            {
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
                siparis.operation = "Add";
            }
            else
            {
                ModelState.AddModelError("User", "İşlem yapabilmeniz için sisteme giriş yapınız.");
            }
            return View(siparis);
        }
        
        [HttpGet]
        public ActionResult Guncelle(int orderID)
        {
            OrderModel order = _context.OrderModel.Include(b => b.orderdetailsmodels)
                                                                                        .FirstOrDefault<OrderModel>(t => t.orderID == orderID );
                                                                                         
            SiparisModel siparis = new SiparisModel();
            siparis.orderID = order.orderID;
            siparis.orderDate = order.orderDate;
            siparis.orderLocationID = order.orderLocationID;
            siparis.orderOwner_personelID = order.personelID;
            siparis.recStatus = order.recStatus;
            ViewData["personelID"] = new SelectList(_context.employeesmodels, nameof(SiparisModel.orderOwnerEmployeeModel.personelID), nameof(SiparisModel.orderOwnerEmployeeModel.persName));
            EmployeesModels employees = _context.employeesmodels.FirstOrDefault(t=>t.personelID==siparis.orderOwner_personelID);
            siparis.orderLocation = _context.stocklocationmodel.FirstOrDefault(e => e.locationID == siparis.orderLocationID);
            foreach (OrderDetailsModel orderDetails in order.orderdetailsmodels)
                orderDetails.ProductModel = _context.productmodels.FirstOrDefault(e => e.productID == orderDetails.productID);
            siparis.orderdetailsmodels = order.orderdetailsmodels;
            siparis.operation = "Update";
            return View("Giris", siparis);
        }

        [HttpPost]
        public ActionResult Kaydet(string jsonSiparis, string jsonOrderDetails)
        {
            JObject jobjSiparis;
            JArray jobjOrderDetails;
            OrderModel siparis = new OrderModel();
            string Operation = "";


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
                        case "orderID":
                            siparis.orderID= int.Parse(value);
                            break;
                        case "orderDate":
                            siparis.orderDate = DateTime.ParseExact(value, "MM/dd/yyyy HH:mm:ss", provider);
                            break;
                        case "orderOwner_personelID":
                            siparis.personelID = int.Parse(value);
                            break;
                        case "LocationID":
                            siparis.orderLocationID = int.Parse(value);
                            break;
                        case "Operation":
                            Operation = value;
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
                                    orderDetails.productAmount = float.Parse(value);
                                    break;
                            }
                        }
                        orderDetails.recStatus = Program.Const_Active_Order;
                        siparis.orderdetailsmodels.Add(orderDetails);
                    }
                }
                if (Operation!= "Add")
                {
                    _context.OrderModel.Remove(siparis);
                    _context.SaveChanges();
                }
                _context.Add(siparis);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Giris), new { productName = "" });
        }

        public bool StockItemExists(int prodID, string lotID)
        {
            int locID = Program.Const_Production_Location;
            return _context.stockitems.Any(e => e.productID == prodID && e.locationID == locID && e.productionLotID == lotID);
        }

        public stocklocationmodel getLocation(int employeeID)
        {
            EmployeesModels employee;
            stocklocationmodel stocklocationmodel;

            employee = _context.employeesmodels.FirstOrDefault(e => e.personelID == employeeID);
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

        [HttpGet]
        public ActionResult Load()
        {
            List<OrderModel> siparis = new List<OrderModel>();
            siparis = _context.OrderModel.Include(b => b.orderdetailsmodels)
                                                                     .Include(b => b.orderLocation)
                                                                     .Include(c => c.orderOwnerEmployeeModel)
                                                                     .Where(t => t.recStatus == Program.Const_Active_Order || t.recStatus== Program.Const_Order_Partially_Loaded)
                                .ToList();
            foreach (OrderModel order in siparis)
            {
                order.orderOwnerEmployeeModel = _context.employeesmodels.FirstOrDefault(e => e.personelID == order.personelID);
            }
            foreach (OrderModel order in siparis)
            {
                foreach (OrderDetailsModel orderDetails in order.orderdetailsmodels)
                    orderDetails.ProductModel = _context.productmodels.FirstOrDefault(e => e.productID == orderDetails.productID);
            }

            return View(siparis);
        }

        [HttpGet]
        public ActionResult LoadOrder(int orderID)
        {
            OrderModel siparis = new OrderModel();
            siparis = _context.OrderModel.Include(b => b.orderdetailsmodels)
                                                                    .Include(b => b.orderLocation)
                                                                    .Include(c => c.orderOwnerEmployeeModel)
                                                                    .First(t => t.orderID == orderID);
            siparis.orderOwnerEmployeeModel = _context.employeesmodels.FirstOrDefault<EmployeesModels>(t => t.personelID == siparis.personelID);
            foreach (OrderDetailsModel orderDetails in siparis.orderdetailsmodels)
            {
                orderDetails.ProductModel = new ProductModel();
                orderDetails.ProductModel = _context.productmodels.FirstOrDefault<ProductModel>(t => t.productID == orderDetails.productID);
            }
            return View(siparis);
        }

        [HttpPost]
        public ActionResult LoadOrder(string jsonSiparis, string jsonOrderDetails)
        {
            JObject jobjSiparis;
            JArray jobjOrderDetails;
            float totalOrderAmount = 0;
            float totalLoadedAmount = 0;
            OrderModel siparis = new OrderModel();

            if (jsonSiparis != null)
            {
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
                            case "orderID":
                                siparis.orderID= int.Parse(value);
                                break;
                            case "orderDate":
                                siparis.orderDate = DateTime.ParseExact(value, "MM/dd/yyyy HH:mm:ss", provider);
                                break;
                            case "orderOwner":
                                siparis.personelID = int.Parse(value);
                                break;
                            case "locationID":
                                siparis.orderLocationID = int.Parse(value);
                                break;
                        }
                    }
                    siparis.recStatus = Program.Const_Order_Loaded;
                    jobjOrderDetails = JArray.Parse(jsonOrderDetails);
                    foreach (JObject jObj in jobjOrderDetails)
                    {
                        if (jObj != null)
                        {
                            OrderDetailsModel orderDetails = new OrderDetailsModel();
                            foreach (KeyValuePair<String, JToken> app in jObj)
                            {
                                orderDetails.orderID = siparis.orderID;
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
                                        orderDetails.productAmount = float.Parse(value);
                                        totalOrderAmount = totalOrderAmount + orderDetails.productAmount;
                                        break;
                                    case "loadedProductAmount":
                                        orderDetails.loadedProductAmount = float.Parse(value);
                                        totalLoadedAmount = totalLoadedAmount + orderDetails.loadedProductAmount;
                                        break;
                                }
                            }
                            if (orderDetails.productAmount <= orderDetails.loadedProductAmount)
                                orderDetails.recStatus = Program.Const_Order_Loaded;
                            else
                                orderDetails.recStatus = Program.Const_Order_Partially_Loaded;
                            siparis.orderdetailsmodels.Add(orderDetails);
                        }
                    }
                }
                if (totalOrderAmount <= totalLoadedAmount)
                    siparis.recStatus = Program.Const_Order_Loaded;
                else
                    siparis.recStatus = Program.Const_Order_Partially_Loaded;
                _context.OrderModel.Update(siparis);
                _context.SaveChanges();
                return RedirectToAction("Load");
            }
            return View(siparis);
        }

    }
 }