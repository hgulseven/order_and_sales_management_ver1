using System;

namespace order_and_sales_management_ver1.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OrderDetailsModel
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("OrderModel")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Sipari� No")]
        public int orderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Sipari� Sat�r No")]
        public int orderLineNo { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime validTo { get; set; }

        [ForeignKey("productID")]
        public int productID { get; set; }
        public ProductModel ProductModel { get; set; }

        [Display(Name ="�r�n Miktar�")]
        public float productAmount { get; set; }

        [Display(Name = "Y�klenen Miktar")]

        public float loadedProductAmount { get; set; }

        public int orderDeliveryDate { get; set; }

        public int productionLotID { get; set; }

        public int productQualityChecker { get; set; }

        public string orderCritic { get; set; }
        public DateTime validFrom { get; set; }

        public virtual OrderModel OrderModel { get; set; }

        public int recStatus { get; set; } /* -1 : Order Deleted 1: Aktif order  2:Order Delivered */
    }
}
