namespace Order_And_Sales_Management_ver1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OrderModel
    {
        public OrderModel()
        {
            OrderDetailsModels = new HashSet<OrderDetailsModel>();
        }

        [Key]
        public int orderID { get; set; }
        [Display(Name ="Sipariþ Tarihi")]
        public DateTime orderDate { get; set; }
        
        public int recStatus { get; set; }
        [ForeignKey("EmployeesModels")]
        [Display(Name = "Sipariþ Veren")]
        public int orderOwner_personelID { get; set; }
        public virtual EmployeesModels orderOwnerEmployeeModel { get; set; }

        public virtual ICollection<OrderDetailsModel> OrderDetailsModels { get; set; }
        [ForeignKey("StockLocationModel")]
        [Display(Name = "Sipariþ Lokasyonu")]
        public int orderLocationID { get; set; }
        public virtual StockLocationModel orderLocation { get; set; }

    }
}
