namespace Order_And_Sales_Management_ver1.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class StockLocationModel
    {
        [Key]
        public int locationID { get; set; }
        [Display(Name = "Lokasyon")]
        public string locationName { get; set; }
    }
}
