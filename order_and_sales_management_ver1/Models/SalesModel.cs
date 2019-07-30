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
        [Display(Name = "Satýþ No")]
        public int salesID { get; set; }

        [Key]
        [Column(Order = 2)]
        [Display(Name = "Satýþ Satýr No")]
        public int salesLineId { get; set; }
        [Display(Name = "Personel No")]
        public int personelID { get; set; }
        [Display(Name = "Ürün No")]
        public int productID { get; set; }
        public int amount { get; set; }
        [NotMapped]
        public float tutar { get; set; }
        public int typeOfCollection { get; set; }
        public virtual EmployeesModel EmployeesModel { get; set; }
        public virtual ProductModel ProductModel { get; set; }
    }
}
