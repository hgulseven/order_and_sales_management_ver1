using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace order_and_sales_management_ver1.Models
{
    public class baseproduct
    {
        [Key]
        public int baseId { get; set; }
        [Display(Name = "Perakende Fiyatı")]
        public decimal retailPrice { get; set; }
        [Display(Name = "Toptan Fiyatı")]
        public decimal wholeSalePrice { get; set; }
        [Display(Name = "Ürün Adı")]

        public string name { get; set; }
        [Display(Name = "Teadrikçi Kodu")]
        public string sellersID { get; set; }
        public int detailsId { get; set; }
        [Display(Name = "Ürün Barcod")]
        public string barcodeID { get; set; }

        public virtual ICollection<packedproductdetail> packedProductDetail { get; set; }  
    }
}
