namespace Order_And_Sales_Management_ver1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [NotMapped]
    public partial class SiparisModel
    {
        public SiparisModel()
        {
            OrderDetailsModels = new HashSet<OrderDetailsModel>();
        }

        [Key]
        [ForeignKey("OrderDetailsModels")]
        public int orderID { get; set; }
        [Display(Name = "Sipariş Tarihi")]
        public DateTime orderDate { get; set; }
        public bool recStatus { get; set; }
        [ForeignKey("EmployeesModel")]
        [Display(Name = "Sipariş Veren")]
        public int orderOwner_personelID { get; set; }
        public virtual EmployeesModel orderOwnerEmployeeModel { get; set; }
        public virtual ICollection<OrderDetailsModel> OrderDetailsModels { get; set; }
        [ForeignKey("StockLocationModel")]
        [Display(Name = "Sipariş Lokasyonu")]
        public int orderLocationID { get; set; }
        public virtual StockLocationModel orderLocation { get; set; }
        [Display(Name = "Ürün Adı")]
        public string productName { get; set; }
        public int productID { get; set; }
        public virtual ICollection<ProductModel> products { get; set; }
        [Display(Name = "Üretim Lot No")]
        public string productionLotID { get; set; }
        [Display(Name = "Üretim Miktarı")]
        public double productAmount { get; set; }
    }
}
