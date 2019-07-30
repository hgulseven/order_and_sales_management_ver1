namespace Order_And_Sales_Management_ver1.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class EmployeesModel
    {
        [Key]
        public int personelID { get; set; }

        [StringLength(40)]
        [Display(Name = "Personel Ad�")]
        public string persName { get; set; }

        [StringLength(40)]
        public string persSurName { get; set; }

        [StringLength(32)]
        public string password { get; set; }

        public string userName { get; set; }

        public string connectionId{ get; set; }

        public string userRole { get; set; }

        public bool userActive { get; set; }

        public int accessFailedCount { get; set; }
    }
}