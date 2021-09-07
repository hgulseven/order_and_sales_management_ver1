namespace order_and_sales_management_ver1.Models
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SalesModel
    {
        [Key]
        [Column(Order = 0)]
        public DateTime saleDate { get; set; }

        public DateTime saleTime { get; set; }
        [Key]
        [Column(Order = 1)]
        [Display(Name = "Satýþ No")]
        public int salesID { get; set; }

        [Key]
        [Column(Order = 2)]
        [Display(Name = "Satýþ Satýr No")]
        public int salesLineId { get; set; }
        [Display(Name = "Personel No")]
        public int personelID { get; set; }

        [Display(Name = "Miktar")]
        public float amount { get; set; }

        public float dueAmount { get; set; }
        public float paidAmount { get; set; }

        [NotMapped]
        [Display(Name = "Tutar")]
        public decimal tutar { get; set; }
        [NotMapped]
        [Display(Name ="Personel")]
        public string personelNameSurname { get; set; }
        public int typeOfCollection { get; set; }
        [Key]
        [Column(Order = 3)]
        public int locationID { get; set; }
        [StringLength(13,MinimumLength =4)]
        [Display(Name = "Ürün Barkod")]
        public string productBarcodeID { get; set; }
        public virtual EmployeesModels employeesmodels { get; set; }

        [NotMapped]
        public virtual products Products { get; set; }
        public virtual stocklocationmodel location { get; set; }

        public float dara { get; set; }
        
        public  decimal wholesaleamount { get; set; }
    }

    [NotMapped]
    public class saleItem
    {
        [JsonProperty("salesID")]
        public int salesID { get; set; }
        [JsonProperty("personelID")]
        public int personelID { get; set; }

        [JsonProperty("productBarcodeID")]
        [StringLength(13)]
        public string productBarcodeID { get; set; }

        [JsonProperty("amount")]
        public float amount { get; set; }
 
        [JsonProperty("tutar")]
        public float tutar { get; set; }
        public decimal wholesaleamount { get; set; }
    }

}
