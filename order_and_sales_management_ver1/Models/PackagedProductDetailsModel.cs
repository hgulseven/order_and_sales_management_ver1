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

        public int productID { get; set; }
        public int customerID { get; set; }
        public virtual ProductModel ProductModel { get; set; }
    }
}
