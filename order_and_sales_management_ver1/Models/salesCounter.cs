using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace order_and_sales_management_ver1.Models
{
    public class salesCounter
    {
        [Key]
        public DateTime salesDate { get; set; }
        public int counter { get; set; }
    }
}
