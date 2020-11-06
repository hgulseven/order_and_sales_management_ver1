namespace order_and_sales_management_ver1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OrderModel
    {
        public OrderModel()
        {
            orderdetailsmodels = new HashSet<OrderDetailsModel>();
        }
        [Key]
        [Column(Order =0)]
        [Display(Name = "Sipari� No")]
        public int orderID { get; set; }
        [Key]
        [Column(Order = 1)]
        public DateTime validTo { get; set; }

        [Display(Name ="Sipari� Tarihi")]
        public DateTime orderDate { get; set; }
        
        public int recStatus { get; set; }
        [Display(Name = "Sipari� Veren")]
        public int personelID { get; set; }
        public virtual EmployeesModels orderOwnerEmployeeModel { get; set; }

        public virtual ICollection<OrderDetailsModel> orderdetailsmodels { get; set; }

        [Display(Name = "Sipari� Lokasyonu")]
        public int orderLocationID { get; set; }
        public virtual stocklocationmodel orderLocation { get; set; }

        public DateTime validFrom{ get; set; }


    }
}
