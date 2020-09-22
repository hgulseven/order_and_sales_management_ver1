using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order_And_Sales_Management_ver1.Models
{
    [NotMapped]
    public class DisplaySales
    {
        public string rowID { get; set; }
        [Display(Name = "Müşteri No")]
        public string salesID { get; set; }
        public string  personelID { get; set; }
        [Display(Name ="Çalışan")]
        public string employee { get; set; }
        [Display(Name = "İndirim Oranı")]
        public string indirimOranı { get; set; }
        [Display(Name = "Tutar")]
        public string tutar { get; set; }
        [Display(Name = "Tahsil Edilen")]
        public string paidTutar { get; set; }

    }

    [NotMapped]
    public class DisplaySalesDetail
    {
        public string personelID { get; set; }
        public string employee { get; set; }
        public string salesLineId { get; set; }
        public string productName { get; set; }
        public string  amount { get; set; }
        public string  tutar { get; set; }
    }
}