using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using order_and_sales_management_ver1.Models;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using management_ver1.Controllers;

namespace order_and_sales_management_ver1.Controllers
{
    public class ReportsController : Controller
    {

        public const string EndOFDayReport = "select sum(round(paidAmount,2)) as paidAmount, " +
                                                                                         "sum(round(amount* productmodels.productRetailPrice,2)) as tutar," +
                                                                                          "case salesmodels.typeOfCollection " +
                                                                                                      "when 1 then 'Nakit'  " +
                                                                                                      "when 2 then 'Kredi Kartı' " +
                                                                                                      "when 3 then 'Diğer' " +
                                                                                                      "else 'Bilinmeyen' " +
                                                                                          "end as salesType " +
                                                                              "from salesmodels " +
                                                                              "left outer join " +
                                                                              "productmodels " +
                                                                              "on salesmodels.productID = productmodels.productID " +
                                                                              "where saleDate =@saleDate  and locationID= @locationID" +
                                                                              "group by salesType";
        // GET: Reports
        public ActionResult Index()
        {
            List<DisplaySales> displaySales = new List<DisplaySales>();
            float floatVal = 0;
            MySqlConnection cnn;

            DbInterface dbInterface = new DbInterface();
            cnn = dbInterface.connect();
            try
            {

                cnn.Open();
                MySqlCommand mySqlCommand = cnn.CreateCommand();
                mySqlCommand.CommandText = EndOFDayReport;
                mySqlCommand.Parameters.AddWithValue("@saleDate", DateTime.Now.ToString("yyyy-MM-dd"));
                mySqlCommand.Parameters.AddWithValue("@locationID", 1);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    DisplaySales displaySale = new DisplaySales();
                    displaySale.rowID = i.ToString();
                    displaySale.salesID = reader["salesID"].ToString();
                    float.TryParse(reader["tutar"].ToString(), out floatVal);
                    displaySale.tutar = floatVal.ToString("N2");
                    float.TryParse(reader["paidTutar"].ToString(), out floatVal);
                    if (floatVal == 0)
                    {
                        displaySale.paidTutar = displaySale.tutar;
                    }
                    else
                    {
                        displaySale.paidTutar = floatVal.ToString("N2");
                    }
                    displaySales.Add(displaySale);
                    i = i + 1;
                }
                reader.Close();
                mySqlCommand.Dispose();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("VeriTabani", "Veri Tabanı Erişim Hatası");
                logger log = new logger();
                log.write_to_log("Index", ex.ToString());
            }
            if (cnn != null) cnn.Close();
            return View();
        }

        // GET: Reports/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Reports/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reports/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Reports/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reports/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}