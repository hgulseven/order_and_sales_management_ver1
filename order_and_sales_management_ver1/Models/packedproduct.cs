using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace order_and_sales_management_ver1.Models
{
    public class packedproduct
    {
        [Display(Name = "Paket Ürün Kodu")]
        [Key]
        public int packedId { get; set; }

        [Display(Name ="Ürün Adı")]
        public string packedProductName { get; set; }

        [Display(Name = "Barkod")]
        [StringLength(13)]
        public string packedProductBarcodeID { get; set; }

        [Display(Name ="Perakende Fiyatı")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F2}")]

        public decimal productRetailPrice { get; set; }
        [Display(Name = "Toptan Fiyatı")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F2}")]
        public decimal productWholesalePrice { get; set; }
        public virtual List<packedproductdetail> packedProductDetails{ get; set; }

        [NotMapped]
        public string operation { get; set; }
    }
}
