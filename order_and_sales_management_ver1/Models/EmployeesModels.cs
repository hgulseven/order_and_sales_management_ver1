namespace order_and_sales_management_ver1.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class EmployeesModels
    {
        [Key]
        public int personelID { get; set; }

        [StringLength(40)]
        [Display(Name = "Personel Adý")]
        public string persName { get; set; }

        [StringLength(40)]
        [Display(Name = "Personel Soyadý")]

        public string persSurName { get; set; }

        [StringLength(32)]
        public string password { get; set; }

        [ForeignKey("stocklocationmodel")]
        public int locationID { get; set; }
        [Display(Name ="Lokasyon")]
        public virtual stocklocationmodel empLocation { get; set; }

        public string userName { get; set; }

        public string connectionId{ get; set; }

        public string userRole { get; set; }

        public bool userActive { get; set; }

        public int accessFailedCount { get; set; }
               
        public int recStatus { get; set; }
    }
}
