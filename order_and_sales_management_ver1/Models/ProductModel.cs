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
        [Display(Name = "�r�n Kodu")]
        public int productID { get; set; }
        [Display(Name = "�r�n Ad�")]
        public string ProductName { get; set; }
        [Display(Name = "�r�n Barkodu")]
        [StringLength(13)]
        public string productBarcodeID { get; set; }
        [Display(Name = "Perakende Sat�� Fiyat�")]
        public decimal productRetailPrice { get; set; }
        [Display(Name = "Toptan Sat�� Fiyat�")]
        public decimal productWholesalePrice { get; set; }
        public int recStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetailsModel> orderdetailsmodels { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PackagedProductDetailsModel> packagedproductdetailsmodels { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesModel> salesmodels { get; set; }
        [Display(Name = "Teradrik�i Kodu")]
        public string sellersID { get; set; }
    }
}
