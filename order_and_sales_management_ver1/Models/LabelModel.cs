using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace order_and_sales_management_ver1.Models
{
    public class LabelModel
    {
        public int productID { get; set; }
        [Display(Name = "Ürün Adı")]
        public string productName { get; set; }
        [Display(Name = "Miktar Satırı")]
        public string productAmount { get; set; }
        [Display(Name = "İçindekiler Satırı")]
        public string productContents { get; set; }
        [Display(Name = "Gıda Kodeks Satırı")]
        public string productLawStr { get; set;}
        [Display(Name = "Parti No")]
        public string productLotNo { get; set; }
        [Display(Name = "Ürün Barkod")]
        public string productBarcodID { get; set; }
    }
}
