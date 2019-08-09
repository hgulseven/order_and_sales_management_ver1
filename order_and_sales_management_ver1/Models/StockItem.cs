namespace Order_And_Sales_Management_ver1.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class StockItem
    {
        [Key,Column(Order = 0)]
        [ForeignKey("ProductModel")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int productID { get; set; }

        public virtual ProductModel product { get; set; }

        [Key,Column(Order = 1)]
        [ForeignKey("StockLocationModel")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int locationID { get; set; }
        public virtual StockLocationModel StockLocationModel { get; set; }

        [Key,Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(10)]
        public string productionLotID { get; set; }

        public double stockAmount { get; set; }

        public int recStatus { get; set; }
    }
}
