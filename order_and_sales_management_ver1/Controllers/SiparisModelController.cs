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
using Newtonsoft.Json;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace order_and_sales_management_ver1.Controllers
{
    public class ColumnData
    {
        public int Width { get; set; }
        public string Alignment { get; set; } 
        public string Col_value { get; set; }
    }

    public class Columns
    {
        public List<ColumnData> Cols { get; set; } 
    }
    public class PrintData
    {
        public string Header { get; set; }
        public List<Columns> Lines{ get; set; }
    }

    public class SiparisModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SiparisModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Liste(string? err)
        {
            List<OrderModel> siparis = new List<OrderModel>();
            if (err != null && err != "")
            {
                ModelState.AddModelError("error", err);
            }

            if (User.Identity.IsAuthenticated)
            {
                int location = int.Parse(HttpContext.User.Claims.Where(c => c.Type == "location").FirstOrDefault().Value.ToString());
                if (location == 1)
                {
                    siparis = _context.OrderModel.Include(b => b.orderdetailsmodels)
                                                                             .Include(b => b.orderLocation)
                                                                             .Include(c => c.orderOwnerEmployeeModel)
                                                                             .Where(t => t.recStatus == Program.Const_Active_Order && t.validTo==DateTime.Parse("2099-01-01"))
                                                                             .ToList();
                }
                else
                {
                    siparis = _context.OrderModel.Include(b => b.orderdetailsmodels)
                                                                             .Include(b => b.orderLocation)
                                                                             .Include(c => c.orderOwnerEmployeeModel)
                                                                             .Where(t => t.recStatus == Program.Const_Active_Order && t.orderLocationID == location && t.validTo == DateTime.Parse("2099-01-01"))
                                                                             .ToList();
                }
                foreach (OrderModel order in siparis)
                {
                    order.orderOwnerEmployeeModel = _context.employeesmodels.FirstOrDefault(e => e.personelID == order.personelID);
                }
                foreach (OrderModel order in siparis)
                {
                    foreach (OrderDetailsModel orderDetails in order.orderdetailsmodels)
                        orderDetails.Product= _context.Products.FirstOrDefault(e => e.productBarcodeID== orderDetails.productBarcodeID);
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
                    siparis.Products = _context.Products.Where(x => x.productName.Contains(productName)).ToList();
                }
                else
                {
                    siparis.Products = new List<products>();

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
        public ActionResult Guncelle(int orderID,string? error)
        {
            if (error != null && error != "")
            {
                ModelState.AddModelError("error", error);
            }
            OrderModel order = _context.OrderModel.Include(b => b.orderdetailsmodels)
                                                                                        .FirstOrDefault<OrderModel>(t => t.orderID == orderID && t.validTo == DateTime.Parse("2099-01-01"));
                                                                                         
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
                orderDetails.Product= _context.Products.FirstOrDefault(e => e.productBarcodeID == orderDetails.productBarcodeID);
            siparis.orderdetailsmodels = order.orderdetailsmodels;
            siparis.operation = "Update";
            return View("Giris", siparis);
        }
        public class Returnvalue {
            public int orderID { get; set; }
            public string error { get; set; }

        }

        [HttpPost]
        public Returnvalue Kaydet(string jsonSiparis, string jsonOrderDetails,Boolean printOrder)
        {
            JObject jobjSiparis;
            JArray jobjOrderDetails;
            OrderModel siparisnew = new OrderModel();
            OrderModel siparis = new OrderModel();
            string Operation = "";
            ordercounter counter = new ordercounter ();
            DateTime validity = DateTime.Now;
            Returnvalue returnvalue = new Returnvalue();
            returnvalue.error = "";
            returnvalue.orderID = 0;

            siparisnew.orderdetailsmodels = new List<OrderDetailsModel>();
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
                            siparisnew.orderID = int.Parse(value);
                            break;
                        case "orderDate":
                            siparisnew.orderDate = DateTime.ParseExact(value, "MM/dd/yyyy HH:mm:ss", provider);
                            break;
                        case "orderOwner_personelID":
                            siparisnew.personelID = int.Parse(value);
                            break;
                        case "LocationID":
                            siparisnew.orderLocationID = int.Parse(value);
                            break;
                        case "Operation":
                            Operation = value;
                            break;
                            
                    }
                }
                siparisnew.recStatus = Program.Const_Active_Order;

                if (Operation != "Add")
                {
                    siparis = _context.OrderModel.Include(b => b.orderdetailsmodels)
                                                                                                .FirstOrDefault<OrderModel>(t => t.orderID == siparisnew.orderID && t.validTo == DateTime.Parse("2099-01-01"));
                    _context.OrderModel.Remove(siparis);
                    _context.SaveChanges();
                    siparis.validTo = validity;
                    foreach (OrderDetailsModel item in siparis.orderdetailsmodels)
                    {
                        item.validTo = validity;
                    }

                    _context.OrderModel.Add(siparis);
                    _context.SaveChanges();
                } else
                {
                    counter = _context.ordercounters.FirstOrDefault();
                    counter.counter = counter.counter + 1;
                    _context.ordercounters.Update(counter);
                    _context.SaveChanges(); 
                    siparisnew.orderID = counter.counter;
                }

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
                                case "productBarcodeID":
                                    orderDetails.productBarcodeID = value.Trim();
                                    break;
                                case "productAmount":
                                    orderDetails.productAmount = float.Parse(value);
                                    break;
                                case "entryUserID":
                                    orderDetails.EntryUserID = int.Parse(value);
                                    break;
                            }
                        }
                        orderDetails.orderID = siparisnew.orderID;
                        orderDetails.recStatus = Program.Const_Active_Order;
                        orderDetails.validTo= DateTime.Parse("2099-01-01");
                        orderDetails.validFrom = validity;
                        siparisnew.orderdetailsmodels.Add(orderDetails);
                    }
                }
                siparisnew.validTo = DateTime.Parse("2099-01-01");
                siparisnew.validFrom = validity;

                _context.Add(siparisnew);
                _context.SaveChanges();
            }
            if (printOrder)
            {
                returnvalue.error=Print(siparisnew.orderID);
            }
            returnvalue.orderID= siparisnew.orderID;
            return returnvalue;
        }

        public string getLocation(int employeeID)
        {
            EmployeesModels employee;

            employee = _context.employeesmodels.Include(e => e.empLocation).First(e => e.personelID == employeeID);
            var serialize_Settings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            var myStr = JsonConvert.SerializeObject(employee.empLocation, serialize_Settings);
            return myStr;
        }

        public SiparisModel getProducts(string productName)
        {
            SiparisModel siparis = new SiparisModel();
            if (!String.IsNullOrEmpty(productName))
            {
                siparis.Products = _context.Products.Where(x => x.productName.Contains(productName)).ToList();
            }
            else
            {
                siparis.Products = new List<products>();

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
                                                                     .Where(t => (t.recStatus == Program.Const_Active_Order || t.recStatus== Program.Const_Order_Partially_Loaded) && t.validTo == DateTime.Parse("2099-01-01"))
                                .ToList();
            foreach (OrderModel order in siparis)
            {
                order.orderOwnerEmployeeModel = _context.employeesmodels.FirstOrDefault(e => e.personelID == order.personelID);
            }
            foreach (OrderModel order in siparis)
            {
                foreach (OrderDetailsModel orderDetails in order.orderdetailsmodels)
                    orderDetails.Product= _context.Products.FirstOrDefault(e => e.productBarcodeID== orderDetails.productBarcodeID);
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
                                                                    .First(t => t.orderID == orderID && t.validTo == DateTime.Parse("2099-01-01"));
            siparis.orderOwnerEmployeeModel = _context.employeesmodels.FirstOrDefault<EmployeesModels>(t => t.personelID == siparis.personelID);
            foreach (OrderDetailsModel orderDetails in siparis.orderdetailsmodels)
            {
                orderDetails.Product= new products();
                orderDetails.Product= _context.Products.FirstOrDefault<products>(t => t.productBarcodeID== orderDetails.productBarcodeID);
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
                            case "validTo":
                                siparis.validTo = DateTime.Parse(value);
                                break;
                            case "validFrom":
                                siparis.validFrom = DateTime.Parse(value);
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
                                    case "productBarcodeID":
                                        orderDetails.productBarcodeID= value.Trim();
                                        break;
                                    case "entryUserID":
                                        orderDetails.EntryUserID = int.Parse(value);
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
                            orderDetails.validTo = siparis.validTo;
                            orderDetails.validFrom = siparis.validFrom;
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

        public Columns add_line(string col1val, string col2val, string col3val,string col4val)
        {
            Columns line;
            ColumnData col;
            line = new Columns();
            line.Cols = new List<ColumnData>();
            col = new ColumnData();
            col.Col_value = col1val;
            col.Alignment = "Left";
            col.Width = 9;
            line.Cols.Add(col);
            col = new ColumnData();
            col.Col_value = col2val;
            col.Alignment = "Right";
            col.Width = 5;
            line.Cols.Add(col);
            col = new ColumnData();
            col.Col_value = col3val;
            col.Alignment = "Right";
            col.Width = 6;
            line.Cols.Add(col);
            col = new ColumnData();
            col.Col_value = col4val;
            col.Alignment = "Right";
            col.Width = 8;
            line.Cols.Add(col);
            return (line);
        }
        public string Print(int? orderID)
         {
            string responseData="TCPOK";
            string printer_responseData="OK";
            string error = "";
            PrintData printData = new PrintData();
            printData.Lines = new List<Columns>();
            Columns line;
            string pName;
            OrderModel orderModel = _context.OrderModel.Include(b=>b.orderdetailsmodels)
                                                                                                    .Include(b=>b.orderLocation)
                                                                                                    .Include(b=>b.orderOwnerEmployeeModel).FirstOrDefault(x => x.orderID == orderID);
            printData.Header = orderModel.orderLocation.locationName+ " Lokasyonu\nSipariş No : " + orderModel.orderID + "\nSiparişi Veren : "+orderModel.orderOwnerEmployeeModel.persName + " "+ orderModel.orderOwnerEmployeeModel.persSurName;
            int i = 0;
            var toplam = 0.0;
            foreach (OrderDetailsModel orderDetails in orderModel.orderdetailsmodels)
            {
                orderDetails.Product = _context.Products.FirstOrDefault(b=>b.productBarcodeID==orderDetails.productBarcodeID);
                if (orderDetails.Product.productName.Length > 9)
                    pName = orderDetails.Product.productName.Substring(0, 9);
                else
                    pName = orderDetails.Product.productName;
                line = add_line(    pName,
                                               orderDetails.productAmount.ToString("N0", CultureInfo.GetCultureInfo("tr-TR")),
                                               orderDetails.Product.productWholesalePrice.ToString("N2", CultureInfo.GetCultureInfo("tr-TR")),
                                               (orderDetails.Product.productWholesalePrice * orderDetails.productAmount).ToString("N2", CultureInfo.GetCultureInfo("tr-TR")));
                printData.Lines.Add(line);
                toplam = toplam + orderDetails.Product.productWholesalePrice * orderDetails.productAmount;
            }
            line = add_line("", "", "", "--------");
            printData.Lines.Add(line);
            line = add_line("Toplam", "", "",toplam.ToString("N2", CultureInfo.GetCultureInfo("tr-TR")));
            printData.Lines.Add(line);
            var myStr = JsonConvert.SerializeObject(printData);
            Int32 port = 65432;
            string server = "192.168.1.46";
            try
            {
                TcpClient client = new TcpClient(server, port);
                Byte[] data = System.Text.Encoding.UTF8.GetBytes(myStr);
                NetworkStream stream = client.GetStream();
                var lengthInfo = myStr.Length.ToString() + '#';
                stream.Write(System.Text.Encoding.UTF8.GetBytes(lengthInfo), 0, lengthInfo.Length);
                stream.Flush();
                stream.Write(data, 0, data.Length);
                stream.Flush();
                data = new Byte[4096];
                responseData = String.Empty;
                do
                {
                    stream.Read(data, 0, 5);
                } while (data.Length < 5 && stream.CanRead);
                responseData = System.Text.Encoding.UTF8.GetString(data);
                responseData=responseData.Replace("\0", string.Empty);
                printer_responseData = String.Empty;
                do
                {
                    stream.Read(data, 0, 1024);
                } while (data.Length == 0 && stream.CanRead);
                printer_responseData = System.Text.Encoding.UTF8.GetString(data);
                printer_responseData=printer_responseData.Replace("\0", string.Empty);
                client.Close();
            }
            catch (Exception  ex)
            {
                responseData = ex.ToString();
            }

            if (responseData != "TCPOK")
                error = "Yazıcı sunucusundan cevap alınamadı " + responseData;
            if (printer_responseData != "OK")
                error = printer_responseData;
            return error;
        }
    }
 }