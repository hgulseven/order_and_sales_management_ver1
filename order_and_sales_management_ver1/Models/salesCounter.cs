using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace order_and_sales_management_ver1.Models
{
    public class salescounter
    {
        [Key]
        [Column(Order=0)]
        public DateTime salesDate { get; set; }
        public int counter { get; set; }
        [Key]
        [Column(Order = 1)]
        public int locationID { get; set; }
    }
}
