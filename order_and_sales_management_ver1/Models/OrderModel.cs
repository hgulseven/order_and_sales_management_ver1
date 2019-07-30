namespace Order_And_Sales_Management_ver1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class OrderModel
    {
        public OrderModel()
        {
            OrderDetailsModels = new HashSet<OrderDetailsModel>();
        }

        [Key]
        public int orderID { get; set; }

        public DateTime orderDate { get; set; }

        public virtual EmployeesModel orderOwnerEmployeeModel { get; set; }
        public int orderOwner_personelID { get; set; }

        public virtual ICollection<OrderDetailsModel> OrderDetailsModels { get; set; }

    }
}
