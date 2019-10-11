using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Order_And_Sales_Management_ver1.Models
{
    public class terazitable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int teraziID { get; set; }
        [StringLength(20)]
        public string TeraziName { get; set; }
    }
}
