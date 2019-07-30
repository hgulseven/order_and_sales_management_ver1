namespace Order_And_Sales_Management_ver1.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PackagedProductDetailsModel
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PackedProductID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PackagedProductLineNo { get; set; }

        public double Amount { get; set; }

        public int ProductID { get; set; }

        public virtual ProductModel ProductModel { get; set; }
    }
}
