namespace Order_And_Sales_Management_ver1.Models
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

        public int productID { get; set; }
        [Display(Name ="�r�n Miktar�")]
        public int productAmount { get; set; }

        public int orderDeliveryDate { get; set; }

        public int productionLotID { get; set; }

        public int productQualityChecker { get; set; }

        public string orderCritic { get; set; }

        public virtual OrderModel OrderModel { get; set; }

        public virtual ProductModel ProductModel { get; set; }

        public int recStatus { get; set; } /* -1 : Order Deleted 1: Aktif order  2:Order Delivered */
    }
}
