using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Order_And_Sales_Management_ver1.Models;

namespace order_and_sales_management_ver1.Models
{
    [NotMapped]
    public class EtiketYazdır
    {
        public int etiketType { get; set; }
        [Display(Name ="Etiket Adet")]
        public int etiketAdet { get; set; }
        public UretimGiris uretim { get; set; }
    }
}
