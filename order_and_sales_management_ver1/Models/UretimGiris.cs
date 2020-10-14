namespace order_and_sales_management_ver1.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [NotMapped]
    public partial class UretimGiris
    {
        [Display(Name = "Ürün Adı")]
        public string productName{get;set;}
        public int productID { get; set; }

        public virtual ICollection<ProductModel> products{ get; set; }

        [Display(Name = "Üretim Lot No")]
        public string productionLotID { get; set; }

        [Display(Name = "Üretim Miktarı")]
        public double stockAmount { get; set; } 
    }
}
