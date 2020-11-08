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
        [Key]
        public int packedId { get; set; }

        [Display(Name ="Ürün Adı")]
        public string packedProductName { get; set; }
        public string barcodProductId { get; set; }
        public virtual List<packedproductdetail> packedProductDetails{ get; set; }

        [NotMapped]
        public string operation { get; set; }
    }
}
