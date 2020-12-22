using System;

namespace order_and_sales_management_ver1.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OrderDetailsModel
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Sipariþ No")]
        public int orderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Sipariþ Satýr No")]
        public int orderLineNo { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime validTo { get; set; }

        public int productID { get; set; }
//        public ProductModel ProductModel { get; set; }
        [NotMapped]
        public products Product { get; set; }

        [Display(Name ="Ürün Barkod")]
        [StringLength(13)]
        public string productBarcodeID { get; set; }
        [Display(Name ="Ürün Miktarý")]
        public float productAmount { get; set; }

        [Display(Name = "Yüklenen Miktar")]

        public float loadedProductAmount { get; set; }

        public int orderDeliveryDate { get; set; }

        public int productionLotID { get; set; }

        public int productQualityChecker { get; set; }
        [Display(Name ="Kullanýcý Kodu")]
        public int EntryUserID { get; set; }
        public string orderCritic { get; set; }

        public DateTime validFrom { get; set; }
        public virtual OrderModel OrderModel { get; set; }
        public int recStatus { get; set; } /* -1 : Order Deleted 1: Aktif order  2:Order Delivered */
    }
}
