using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace order_and_sales_management_ver1.Models
{
    public class CrossTable
    {
        [StringLength(255)]
        [Key]
        public string pname { get; set; }
        public int baseID{ get; set; }
        public int packedID{ get; set; }
        public int productID{ get; set; }
    }
}
