﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace order_and_sales_management_ver1.Models
{
    public class packedproductdetail
    {
        [Key]
        [Column(Order = 0)]
        public int packedId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int contentLineNo { get; set; }
        [StringLength(13)]
        [Display(Name = "Ana Ürün Barkod")]
        public string baseProductBarcodeID { get; set; }
        [StringLength(13)]
        [Display(Name = "Paketli Ürün Barkod")]
        public string packedProductBarcodeID { get; set; }
        public int baseId { get; set; }
        public virtual baseproduct baseProduct { get; set; }
        [Display(Name = "Miktar")]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString = "{0:0.###}")]
        public decimal amount { get; set; }
        public virtual packedproduct packedProduct {get;set;}
    }
}
