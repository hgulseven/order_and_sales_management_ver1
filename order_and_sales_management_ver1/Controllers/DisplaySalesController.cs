using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Order_And_Sales_Management_ver1.Models;
using order_and_sales_management_ver1.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace order_and_sales_management_ver1.Controllers
{
    public class DbInterface
    {
     //   private string connectionString = "Data Source=GULSEVENSRV\\SQLEXPRESS;Initial Catalog=GULSEVEN;User ID=sa;Password=QAZwsx135";

        public SqlConnection connect()
        {
            SqlConnection cnn;
            cnn = new SqlConnection(Program.Connection_String);
            return (cnn);
        }

    }
    public class DisplaySalesController : Controller    {

        public  List<DisplaySales> GetDisplaySales()
        {
            List<DisplaySales> displaySales = new List<DisplaySales>();
            float floatVal = 0;
            SqlConnection cnn;

            DbInterface dbInterface = new DbInterface();
            cnn = dbInterface.connect();
            try
            {

                cnn.Open();
                SqlCommand sqlCommand = cnn.CreateCommand();
                sqlCommand.CommandText = "select  salesID,sum(amount*productRetailPrice) as tutar,max(paidAmount) as paidTutar " +
                                                                       "from SalesModels left outer join EmployeesModels  on (SalesModels.personelID = EmployeesModels.personelID) " +
                                                                       "left outer join ProductModels on(SalesModels.productID=ProductModels.productID) " +
                                                                       "where typeOfCollection = 0  group by salesID" ;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    DisplaySales displaySale = new DisplaySales();
                    displaySale.rowID = i.ToString();
                    displaySale.salesID = reader["salesID"].ToString();
                    float.TryParse(reader["tutar"].ToString(), out floatVal);
                    displaySale.tutar = floatVal.ToString("N2");
                    float.TryParse(reader["paidTutar"].ToString(), out floatVal);
                    displaySale.paidTutar = floatVal.ToString("N2"); 
                    displaySales.Add(displaySale);
                    i = i + 1;
                }
                reader.Close();
                sqlCommand.Dispose();
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

            SqlConnection cnn;

            DbInterface dbInterface = new DbInterface();
            cnn = dbInterface.connect();

            try
            {
                cnn.Open();
                SqlCommand sqlCommand = cnn.CreateCommand();
                sqlCommand.CommandText = "select SalesModels.personelID,salesLineID,CONCAT(persName,' ',persSurname) as employee, productName, amount, (amount*productRetailPrice) as tutar " +
                                                                       "from SalesModels left outer join EmployeesModels  on (SalesModels.personelID = EmployeesModels.personelID) " +
                                                                       "left outer join ProductModels on(SalesModels.productID=ProductModels.productID) " +
                                                                       "where typeOfCollection = 0  and SalesModels.salesID=@salesID "+
                                                                       "order by salesLineID" ;
                sqlCommand.Parameters.AddWithValue("@salesID", salesID);
                SqlDataReader reader = sqlCommand.ExecuteReader();
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
                sqlCommand.Dispose();
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
            SqlConnection cnn;
            string modelError = "";
            DbInterface dbInterface = new DbInterface();
            cnn = dbInterface.connect();

            try
            {
                cnn.Open();
                SqlCommand sqlCommand = cnn.CreateCommand();
                sqlCommand.CommandText = "Update SalesModels set typeOfCollection=@typeOfCollection " +
                                                                       "where typeOfCollection = 0  and salesID=@salesID and saleDate = @saleDate";   /* Date eklenmeli */
                sqlCommand.Parameters.AddWithValue("@saleDate", DateTime.Now.ToString("yyyy-MM-dd"));
                sqlCommand.Parameters.AddWithValue("@typeOfCollection", typeOfCollection);
                sqlCommand.Parameters.AddWithValue("@salesID", salesID);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("VeriTabaniGuncelleme", "Veri tabanı Güncelleme Hatası");
                modelError = "Veri tabanı Güncelleme Hatası";
            }
            if (cnn != null) cnn.Close();
            return RedirectToAction("Index","DisplaySales",new { error = modelError});

        }

        public void updatePaidAmount(string salesID, string paidAmount)
        {
            SqlConnection cnn;
            string modelError = "";
            DbInterface dbInterface = new DbInterface();
            cnn = dbInterface.connect();

            try
            {
                cnn.Open();
                SqlCommand sqlCommand = cnn.CreateCommand();
                sqlCommand.CommandText = "Update SalesModels set paidAmount=@paidTutar " +
                                                                       "where typeOfCollection = 0  and salesID=@salesID and saleDate=@salesDate";   /* Date eklenmeli */
                sqlCommand.Parameters.AddWithValue("@salesDate", DateTime.Now.ToString("yyyy-MM-dd"));
                sqlCommand.Parameters.AddWithValue("@typeOfCollection", 0);
                int intSalesID = 0;
                int.TryParse(salesID, out intSalesID);
                sqlCommand.Parameters.AddWithValue("@salesID", intSalesID);
                float floatPaidTutar = 0; ;
                float.TryParse(paidAmount, out floatPaidTutar);
                sqlCommand.Parameters.AddWithValue("@paidTutar", floatPaidTutar);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
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