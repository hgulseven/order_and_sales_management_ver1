namespace Order_And_Sales_Management_ver1.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class StockItem
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int productID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationID { get; set; }

        public double stockAmount { get; set; }

        public int productionLotID { get; set; }

        public virtual StockLocationModel StockLocationModel { get; set; }
    }
}
