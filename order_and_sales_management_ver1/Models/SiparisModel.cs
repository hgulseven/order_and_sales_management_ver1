﻿namespace order_and_sales_management_ver1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [NotMapped]
    public partial class SiparisModel
    {
        public SiparisModel()
        {
            orderdetailsmodels = new HashSet<OrderDetailsModel>();
        }

        [Key]
        [ForeignKey("orderdetailsmodels")]
        public int orderID { get; set; }
        [Display(Name = "Sipariş Tarihi")]
        public DateTime orderDate { get; set; }
        public int recStatus { get; set; }  /* -1 : Order Deleted 1: Aktif order  2:Order Delivered */
        [ForeignKey("employeesmodels")]
        [Display(Name = "Sipariş Veren")]
        public int orderOwner_personelID { get; set; }
        public virtual EmployeesModels orderOwnerEmployeeModel { get; set; }
        public virtual ICollection<OrderDetailsModel> orderdetailsmodels { get; set; }
        [ForeignKey("stocklocationmodel")]
        [Display(Name = "Sipariş Lokasyonu")]
        public int orderLocationID { get; set; }
        public virtual stocklocationmodel orderLocation { get; set; }
        [Display(Name = "Ürün Adı")]
        public string productName { get; set; }
        [Display(Name = "Ürün Kodu")]
        public int productID { get; set; }
        //        public virtual ICollection<ProductModel> products { get; set; }

        [Display(Name = "Ürün Barkod")]
        [StringLength(13)]
        public string productBarcodeID { get; set; }

        public virtual ICollection<products> Products { get; set; }
        [Display(Name = "Üretim Lot No")]
        public string productionLotID { get; set; }
        [Display(Name = "Miktar")]
        public double productAmount { get; set; }
        public string operation { get; set; }
    }
}
