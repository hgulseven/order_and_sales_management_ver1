using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace order_and_sales_management_ver1.Models
{
    public class packagedproductsbarcode
    {
        [Key]
        [StringLength(13,MinimumLength =4)]
        public string barcodeID { get; set; }
        public int recStatus { get; set; }
    }
}
