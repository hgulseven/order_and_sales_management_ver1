namespace order_and_sales_management_ver1.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class stocklocationmodel
    {
        [Key]
        public int locationID { get; set; }
        [Display(Name = "Lokasyon")]
        public string locationName { get; set; }
        public virtual ICollection<EmployeesModels> employees { get; set; }
        public virtual ICollection<OrderModel> orders { get; set; }

        public virtual ICollection<SalesModel> sales { get; set; }


    }
}
