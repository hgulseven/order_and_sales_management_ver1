using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace order_and_sales_management_ver1.Models
{
    public class LabelModel
    {
        [Display(Name = "Ürün Adı")]
        public string productName { get; set; }
        [Display(Name = "Miktar Satırı")]
        public string productAmount { get; set; }
        [Display(Name = "İçindekiler Satırı")]
        public string productContents { get; set; }
        [Display(Name = "Gıda Kodeks Satırı")]
        public string productLawStr { get; set;}

        [Display(Name = "Saklama Koşulları")]
        public string productStoringCond { get; set; }

        [Display(Name = "Ürün Raf Ömrü")]
        public string productShelfLife{ get; set; }
        public int productDuration { get; set; }

        [Display(Name = "Parti No")]
        public string productLotNo { get; set; }
        [Key]
        [Display(Name = "Ürün Barkod")]
        [StringLength(13)]
        public string productBarcodeID { get; set; }
        [Display(Name = "Firma Bilgisi")]
        public string companyInfo { get; set; }

        [Display(Name = "Menşei")]
        public string mensei { get; set; }

        [Display(Name = "Alerji Bilgisi")]
        public string alerji { get; set; }

        [NotMapped]
        public string recordExists { get; set; }
        [NotMapped]
        [Display(Name = "Kopya Sayısı")]
        public int numberOfCopies { get; set; }
        [NotMapped] 
        public int typeOfLabel { get; set; }
        [NotMapped]
        public string typeOfPrintMedia { get; set; }
    }
}
