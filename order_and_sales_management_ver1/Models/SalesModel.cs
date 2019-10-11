namespace Order_And_Sales_Management_ver1.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SalesModel
    {
        [Key]
        [Column(Order = 0)]
        public DateTime saleDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [Display(Name = "Sat�� No")]
        public int salesID { get; set; }

        [Key]
        [Column(Order = 2)]
        [Display(Name = "Sat�� Sat�r No")]
        public int salesLineId { get; set; }
        [Display(Name = "Personel No")]
        public int personelID { get; set; }
        [Display(Name = "�r�n No")]
        public int productID { get; set; }
        public float amount { get; set; }
        public float paidAmount { get; set; }

        [NotMapped]
        public float tutar { get; set; }
        public int typeOfCollection { get; set; }
        public int locationID { get; set; }
        public virtual EmployeesModels employeesmodels { get; set; }
        public virtual ProductModel ProductModel { get; set; }
    }
}
