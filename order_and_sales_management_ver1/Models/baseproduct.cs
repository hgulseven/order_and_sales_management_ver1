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
        [Display(Name = "Ürün No")]
        public int baseId { get; set; }
        [Display(Name = "Perakende Fiyatı")]
        public decimal retailPrice { get; set; }
        [Display(Name = "Toptan Fiyatı")]
        public decimal wholeSalePrice { get; set; }
        [Display(Name = "Ürün Adı")]

        public string name { get; set; }
        [Display(Name = "Tedarikçi Kodu")]
        public string sellersID { get; set; }
        public int detailsId { get; set; }
        [Display(Name = "Ürün Barkod")]
        [StringLength(13)]
        [MinLength(13, ErrorMessage ="Barkod uzunluğu 13 karakter olmalı")]
        [MaxLength(13, ErrorMessage = "Barkod uzunluğu 13 karakter olmalı")]
        public string barcodeID { get; set; }
        [Display(Name="KDV Oranı")]
        public decimal productKDV { get; set; }
        public virtual ICollection<packedproductdetail> packedProductDetail { get; set; }  
    }
}
