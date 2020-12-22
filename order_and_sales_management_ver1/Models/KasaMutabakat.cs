using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using order_and_sales_management_ver1.Models;

namespace order_and_sales_management_ver1.Models
{
    public class KasaMutabakat
    {
        [Display(Name = "İşlem Günü")]
        [Key]
        [Column(Order = 1)]
        public DateTime mutabakatTimeStamp { get; set; }
        [Key]
        [Column(Order = 2)]
        public int locationID { get; set; }
        [Key]
        [Column(Order = 3)]
        [Display(Name = "Mutabakat Tipi")]
        public string typeOfMutabakat { get; set; } /*Günbaşı, Ara, GünSonu*/
        public DateTime mutabakatDate { get; set; }
        [Display(Name = "Mutabakatı Yapan")]
        public EmployeesModels employee { get; set; }
        public int personelID { get; set; }

        [Display(Name = "5 krs")]
        public int change5KRS { get; set; }

        [Display(Name = "10 krs")]
        public int change10KRS { get; set; }
        [Display(Name = "25 krs")]
        public int change25KRS { get; set; }
        [Display(Name = "50 krs")]
        public int change50KRS { get; set; }
        [Display(Name = "1TL")]
        public int change1TL { get; set; }
        [Display(Name = "5 TL")]
        public int change5TL { get; set; }
        [Display(Name = "10 TL")]
        public int change10TL { get; set; }
        [Display(Name = "20 TL")]
        public int change20TL { get; set; }
        [Display(Name = "50 TL")]
        public int change50TL { get; set; }
        [Display(Name = "100 TL")]
        public int change100TL { get; set; }
        [Display(Name = "200 TL")]
        public int change200TL { get; set; }
        [Display(Name = "5 krs")]
        public int nakit5KRS { get; set; }
        [Display(Name = "10 krs")]
        public int nakit10KRS { get; set; }
        [Display(Name = "25 krs")]
        public int nakit25KRS { get; set; }
        [Display(Name = "50 krs")]
        public int nakit50KRS { get; set; }
        [Display(Name = "1TL")]
        public int nakit1TL { get; set; }
        [Display(Name = "5 TL")]
        public int nakit5TL { get; set; }
        [Display(Name = "10 TL")]
        public int nakit10TL { get; set; }
        [Display(Name = "20 TL")]
        public int nakit20TL { get; set; }
        [Display(Name = "50 TL")]
        public int nakit50TL { get; set; }
        [Display(Name = "100 TL")]
        public int nakit100TL { get; set; }
        [Display(Name = "200 TL")] 
        public int nakit200TL { get; set; }
        [Display(Name = "Kredi Kartı Toplam")]
        public float krediKartıToplam { get; set; }
        public float sistemNakitToplam { get; set; }
        public float sistemKrediKartıToplam { get; set; }
        public float sistemDigerToplam { get; set; }
    }

    public class Expenditures
    {
        [Key]
        [Column(Order =1)]
        [Display(Name = "İşlem Günü")]
        public DateTime opDate { get; set; }
        [Key]
        [Column(Order = 2)]
        public int locationID { get; set; }
        [Display(Name = "Harcamayı Yapan")]
        public EmployeesModels employee { get; set; }
        [Display(Name = "Açıklama")]
        public string aciklama { get; set; }
        [Display(Name = "Tutar")]
        public float amount { get; set; }

    }
}
