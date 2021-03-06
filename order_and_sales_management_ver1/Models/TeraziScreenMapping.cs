namespace order_and_sales_management_ver1.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TeraziScreenMapping")]
    public partial class TeraziScreenMapping
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int teraziID { get; set; }
        public int? screenSeqNo { get; set; }
        [Key]
        [Column(Order = 1)]
        [StringLength(13)]
        public string barcodeID { get; set; }
    }
}
