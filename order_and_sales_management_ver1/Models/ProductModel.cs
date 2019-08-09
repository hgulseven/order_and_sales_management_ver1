namespace Order_And_Sales_Management_ver1.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ProductModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductModel()
        {
            OrderDetailsModels = new HashSet<OrderDetailsModel>();
            PackagedProductDetailsModels = new HashSet<PackagedProductDetailsModel>();
            SalesModels = new HashSet<SalesModel>();
        }

        [Key]
        public int productID { get; set; }
        [Display(Name = "Ürün Adý")]
        public string ProductName { get; set; }
        [Display(Name = "Ürün Barkodu")]
        public string productBarcodeID { get; set; }
        [Display(Name = "Perakende Satýþ Fiyatý")]
        public double productRetailPrice { get; set; }
        [Display(Name = "Toptan Satýþ Fiyatý")]
        public double productWholesalePrice { get; set; }
        public int recStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetailsModel> OrderDetailsModels { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PackagedProductDetailsModel> PackagedProductDetailsModels { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesModel> SalesModels { get; set; }
    }
}
