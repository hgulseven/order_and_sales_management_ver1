namespace order_and_sales_management_ver1.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ProductModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductModel()
        {
            orderdetailsmodels = new HashSet<OrderDetailsModel>();
            packagedproductdetailsmodels = new HashSet<PackagedProductDetailsModel>();
            salesmodels = new HashSet<SalesModel>();
        }
        [Key]
        [Display(Name = "Ürün Kodu")]
        public int productID { get; set; }
        [Display(Name = "Ürün Adý")]
        public string ProductName { get; set; }
        [Display(Name = "Ürün Barkodu")]
        [StringLength(13)]
        public string productBarcodeID { get; set; }
        [Display(Name = "Perakende Satýþ Fiyatý")]
        public decimal productRetailPrice { get; set; }
        [Display(Name = "Toptan Satýþ Fiyatý")]
        public decimal productWholesalePrice { get; set; }
        public int recStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetailsModel> orderdetailsmodels { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PackagedProductDetailsModel> packagedproductdetailsmodels { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesModel> salesmodels { get; set; }
        [Display(Name = "Teradrikçi Kodu")]
        public string sellersID { get; set; }
    }
}
