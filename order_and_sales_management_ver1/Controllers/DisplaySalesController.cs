﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Order_And_Sales_Management_ver1.Models;
using Order_And_Sales_Management_ver1.Data;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;


namespace Order_And_Sales_Management_ver1.Controllers
{



    public class DbInterface
    {

     //   private string connectionString = "Data Source=GULSEVENSRV\\MySqlEXPRESS;Initial Catalog=GULSEVEN;User ID=sa;Password=QAZwsx135";

        public MySqlConnection connect()
        {
            MySqlConnection cnn;
            cnn = new MySqlConnection(Program.Connection_String);
            return (cnn);
        }

    }
    public class DisplaySalesController : Controller    {

        public const string SelectLastCustomerWhoDidPayment = "select max(salesID) as salesID from salesmodels where typeOfCollection>0 and saleDate = @saleDate "; /* Get maximum sales id which is paid on given date */
        public const string UpdateLastCustomerAsNotPaid = "update salesmodels set typeOfCollection = 0 where saleDate=@saleDate and salesID=@salesID";
        public const string SelectCustomersWhichSentToCashier =  "select  salesID,sum(amount*productRetailPrice) as tutar,max(paidAmount) as paidTutar " +
                                                                                                                    "from SalesModels left outer join EmployeesModels  on (SalesModels.personelID = EmployeesModels.personelID) " +
                                                                                                                    "left outer join ProductModels on(SalesModels.productID=ProductModels.productID) " +
                                                                                                                    "where typeOfCollection = 0  and saleDate=@saleDate group by salesID";

        public const string SelectSalesDetail =     "select SalesModels.personelID,salesLineID,CONCAT(persName,' ',persSurname) as employee, productName, amount, (amount*productRetailPrice) as tutar " +
                                                                                    "from SalesModels left outer join EmployeesModels  on (SalesModels.personelID = EmployeesModels.personelID) " +
                                                                                    "left outer join ProductModels on(SalesModels.productID=ProductModels.productID) " +
                                                                                    "where typeOfCollection = 0  and SalesModels.salesID=@salesID "+
                                                                                    "order by salesLineID";
        public const string UpdateSalesAsPaid = "Update SalesModels set typeOfCollection=@typeOfCollection " +
                                                                                   "where typeOfCollection = 0  and salesID=@salesID and saleDate = @saleDate";

        public const string UpdatePaidAmount = "Update SalesModels set paidAmount=@paidTutar " +
                                                                                    "where salesID=@salesID and saleDate=@salesDate";   

        public List<DisplaySales> GetDisplaySales()
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
                mySqlCommand.CommandText = SelectCustomersWhichSentToCashier;
                mySqlCommand.Parameters.AddWithValue("@saleDate", DateTime.Now.ToString("yyyy-MM-dd"));
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
            }
            if (cnn != null) cnn.Close();
            return (displaySales);
        }

        public string GetSalesDetail(string salesID)
        {
            List<DisplaySalesDetail> salesDetails= new List<DisplaySalesDetail>();
            float floatVal = 0;

            MySqlConnection cnn;

            DbInterface dbInterface = new DbInterface();
            cnn = dbInterface.connect();

            try
            {
                cnn.Open();
                MySqlCommand mySqlCommand = cnn.CreateCommand();
                mySqlCommand.CommandText = SelectSalesDetail;
                mySqlCommand.Parameters.AddWithValue("@salesID", salesID);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    DisplaySalesDetail salesDetail = new DisplaySalesDetail();
                    salesDetail.personelID= reader["personelID"].ToString();
                    salesDetail.employee= reader["employee"].ToString();
                    salesDetail.salesLineId = reader["salesLineID"].ToString();
                    salesDetail.productName= reader["productName"].ToString();
                    float.TryParse(reader["tutar"].ToString(), out floatVal);
                    salesDetail.tutar = floatVal.ToString("N2");
                    float.TryParse(reader["amount"].ToString(), out floatVal);
                    salesDetail.amount= floatVal.ToString("N3");
                    salesDetails.Add(salesDetail);
                }
                reader.Close();
                mySqlCommand.Dispose();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("VeriTabani", "Veri Tabanı Erişim Hatası");
            }
            if (cnn != null) cnn.Close();
            string jsonstr = JsonConvert.SerializeObject(salesDetails);
            return (jsonstr);
        }

        // GET: DisplaySales
         public ActionResult Index(string error)
        {
            if (error !="" && error != null)
            {
                ModelState.AddModelError("error", error);
            }
            return View(GetDisplaySales());
        }
        public void refresh()
        {
        }


        public ActionResult Tahsilat(string salesID, string typeOfCollection)
        {
            MySqlConnection cnn;
            string modelError = "";
            DbInterface dbInterface = new DbInterface();
            cnn = dbInterface.connect();

            try
            {
                cnn.Open();
                MySqlCommand mySqlCommand = cnn.CreateCommand();
                mySqlCommand.CommandText = UpdateSalesAsPaid;
                mySqlCommand.Parameters.AddWithValue("@saleDate", DateTime.Now.ToString("yyyy-MM-dd"));
                mySqlCommand.Parameters.AddWithValue("@typeOfCollection", typeOfCollection);
                mySqlCommand.Parameters.AddWithValue("@salesID", salesID);
                mySqlCommand.ExecuteNonQuery();
                mySqlCommand.Dispose();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("VeriTabaniGuncelleme", "Veri tabanı Güncelleme Hatası");
                modelError = "Veri tabanı Güncelleme Hatası";
            }
            if (cnn != null) cnn.Close();
            return RedirectToAction("Index","DisplaySales",new { error = modelError});

        }

        public ActionResult updateLastCustomerAsNotPaid()
        {
            MySqlConnection cnn;
            string modelError = "";
            string salesID="0";
            DbInterface dbInterface = new DbInterface();
            cnn = dbInterface.connect();

            try
            {
                cnn.Open();
                MySqlCommand mySqlCommand = cnn.CreateCommand();
                mySqlCommand.CommandText = SelectLastCustomerWhoDidPayment;
                mySqlCommand.Parameters.AddWithValue("@saleDate", DateTime.Now.ToString("yyyy-MM-dd"));
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    salesID = reader["salesID"].ToString();
                }
                reader.Close();
                mySqlCommand.Dispose();
                mySqlCommand = cnn.CreateCommand();
                mySqlCommand.CommandText = UpdateLastCustomerAsNotPaid;
                mySqlCommand.Parameters.AddWithValue("@saleDate", DateTime.Now.ToString("yyyy-MM-dd"));
                mySqlCommand.Parameters.AddWithValue("@salesID", salesID);
                mySqlCommand.ExecuteNonQuery();
                mySqlCommand.Dispose();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("VeriTabaniGuncelleme", "Veri tabanı Güncelleme Hatası");
                modelError = "Veri tabanı Güncelleme Hatası";
            }
            if (cnn != null) cnn.Close();
            return RedirectToAction("Index", "DisplaySales", new { error = modelError });
        }

        public void updatePaidAmount(string salesID, string paidAmount)
        {
            MySqlConnection cnn;
            string modelError = "";
            DbInterface dbInterface = new DbInterface();
            cnn = dbInterface.connect();

            try
            {
                cnn.Open();
                MySqlCommand mySqlCommand = cnn.CreateCommand();
                mySqlCommand.CommandText = UpdatePaidAmount;
                mySqlCommand.Parameters.AddWithValue("@salesDate", DateTime.Now.ToString("yyyy-MM-dd"));
                mySqlCommand.Parameters.AddWithValue("@typeOfCollection", 0);
                int intSalesID = 0;
                int.TryParse(salesID, out intSalesID);
                mySqlCommand.Parameters.AddWithValue("@salesID", intSalesID);
                float floatPaidTutar = 0; ;
                float.TryParse(paidAmount, out floatPaidTutar);
                mySqlCommand.Parameters.AddWithValue("@paidTutar", floatPaidTutar);
                mySqlCommand.ExecuteNonQuery();
                mySqlCommand.Dispose();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("VeriTabaniGuncelleme", "Veri tabanı Güncelleme Hatası");
                modelError = "Veri tabanı Güncelleme Hatası";
            }
            if (cnn != null) cnn.Close();
        }

    }
   
}