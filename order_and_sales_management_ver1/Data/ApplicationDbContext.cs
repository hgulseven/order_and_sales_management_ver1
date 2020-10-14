using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using order_and_sales_management_ver1.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ProductModel> productmodels { get; set; }
        public virtual DbSet<OrderDetailsModel> orderdetailsmodels { get; set; }
        public virtual DbSet<PackagedProductDetailsModel> packagedproductdetailsmodels { get; set; }
        public virtual DbSet<SalesModel> salesmodels { get; set; }
        public virtual DbSet<StockItem> stockitems { get; set; }
        public virtual DbSet<TeraziScreenMapping> teraziscreenmappings { get; set; }
        public DbSet<EmployeesModels> employeesmodels { get; set; }
        public DbSet<stocklocationmodel> stocklocationmodel { get; set; }
        public DbSet<terazitable> terazitable { get; set; }
        public DbSet<salescounter> salescounter { get; set; }
        public DbSet<KasaMutabakat> kasamutabakat { get; set; }

        public DbSet<Expenditures> expenditures { get; set; }
        public DbSet<OrderModel> OrderModel { get; set; }
        public DbSet<PackagedProductDetailsModel> packagedProductDetails { get; set; }
        public DbSet<packagedproductsbarcode> packagedproductsbarcodes { get; set; }
        public DbSet<LabelModel> labelmodels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderDetailsModel>()
                                    .HasKey(b => new {b.orderID, b.orderLineNo });
            modelBuilder.Entity<OrderDetailsModel>()
                                      .HasOne(a=>a.ProductModel)
                                      .WithMany(b=>b.orderdetailsmodels)
                                      .HasForeignKey(a=>a.productID);
            modelBuilder.Entity<OrderDetailsModel>()
                                      .HasOne(a => a.OrderModel)
                                      .WithMany(b => b.orderdetailsmodels)
                                      .HasForeignKey("orderID");
            modelBuilder.Entity<SalesModel>()
                .HasKey(b => new { b.saleDate, b.salesID, b.salesLineId });
            modelBuilder.Entity<PackagedProductDetailsModel>()
                .HasKey(b => new { b.PackedProductID, b.PackagedProductLineNo });
            modelBuilder.Entity<StockItem>()
                .HasKey(b => new { b.productID, b.locationID, b.productionLotID });
            modelBuilder.Entity<TeraziScreenMapping>()
                .HasKey(b => new { b.teraziID, b.productID });
            modelBuilder.Entity<OrderModel>()
                                    .HasKey(b => new {b.orderID});
            modelBuilder.Entity<OrderModel>()
                                    .HasOne(typeof(EmployeesModels))
                                    .WithMany()
                                    .HasForeignKey("personelID")
                                    .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<KasaMutabakat>()
                .HasKey(b => new { b.mutabakatTimeStamp, b.locationID, b.typeOfMutabakat });
            modelBuilder.Entity<Expenditures>()
                .HasKey(b => new { b.opDate, b.locationID});
            modelBuilder.Entity<LabelModel>()
                .HasKey(b => new { b.productID});

        }



    }
}
