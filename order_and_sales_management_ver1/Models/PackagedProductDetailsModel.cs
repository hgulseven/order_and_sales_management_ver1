namespace order_and_sales_management_ver1.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PackagedProductDetailsModel
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(13,MinimumLength =4)]
        public string PackedProductID { get; set; }
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PackagedProductLineNo { get; set; }
        [Key]
        [Column(Order = 2)]
        public int recStatus { get; set; }
        [Key]
        [Column(Order = 3)]
        public DateTime recDate { get; set; }
        public double Amount { get; set; }
        [StringLength(13)]
        public string productBarcodeID { get; set; }
        public int customerID { get; set; }
        [NotMapped]
        public virtual products Products { get; set; }
    }
}
