using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Order_And_Sales_Management_ver1.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using order_and_sales_management_ver1.Models;

namespace order_and_sales_management_ver1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ProductModel> ProductModels { get; set; }
        public virtual DbSet<OrderDetailsModel> OrderDetailsModels { get; set; }
        public virtual DbSet<PackagedProductDetailsModel> PackagedProductDetailsModels { get; set; }
        public virtual DbSet<SalesModel> SalesModels { get; set; }
        public virtual DbSet<StockItem> StockItems { get; set; }
        public virtual DbSet<TeraziScreenMapping> TeraziScreenMappings { get; set; }
        public DbSet<Order_And_Sales_Management_ver1.Models.EmployeesModels> EmployeesModels { get; set; }
        public DbSet<Order_And_Sales_Management_ver1.Models.StockLocationModel> StockLocationModel { get; set; }
        public DbSet<TeraziTable> TeraziTable { get; set; }
        public DbSet<salesCounter> salesCounter { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderDetailsModel>()
                .HasKey(b => new { b.orderID, b.orderLineNo });
            modelBuilder.Entity<SalesModel>()
                .HasKey(b => new { b.saleDate, b.salesID, b.salesLineId });
            modelBuilder.Entity<PackagedProductDetailsModel>()
                .HasKey(b => new { b.PackedProductID, b.PackagedProductLineNo });
            modelBuilder.Entity<StockItem>()
                .HasKey(b => new { b.productID, b.locationID, b.productionLotID });
            modelBuilder.Entity<TeraziScreenMapping>()
                .HasKey(b => new { b.teraziID, b.productID });
            modelBuilder.Entity<OrderModel>()
                                    .HasOne(typeof(EmployeesModels))
                                    .WithMany()
                                    .HasForeignKey("orderOwner_personelID")
                                    .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Order_And_Sales_Management_ver1.Models.OrderModel> OrderModel { get; set; }



    }
}
