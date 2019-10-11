using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace order_and_sales_management_ver1.Models
{
    [NotMapped]
    public class Reports
    {
        DateTime saleDate { get; set; }
        int locationID { get; set; }
        int personelID { get; set; }
        string  personelName { get; set; }
        int productID { get; set; }
        string productName { get; set; }
        float productAmount { get; set; }
        float tutar { get; set; }
        float paidAmount { get; set; }
        float paymentDifference { get; set; }
    }
}
