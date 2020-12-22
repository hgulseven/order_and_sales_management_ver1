using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using order_and_sales_management_ver1.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Data
{
    public class ApplicationDbContext :   IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<OrderDetailsModel> orderdetailsmodels { get; set; }
        public virtual DbSet<PackagedProductDetailsModel> packagedproductdetailsmodels { get; set; }
        public virtual DbSet<SalesModel> salesmodels { get; set; }
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
        public DbSet<ordercounter> ordercounters { get; set; }
        public DbSet<baseproduct> baseProducts { get; set; }
        public DbSet<packedproduct> packedProducts{ get; set; }
        public DbSet<packedproductdetail> packedProductDetails{ get; set; }
        public DbSet<products> Products { get; set; }
        public DbSet<availableBarcodes> AvailableBarcodes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeesModels>()
                                     .HasKey(b => new { b.personelID });

            _ = modelBuilder.Entity<EmployeesModels>()
                                     .HasOne<stocklocationmodel>(b => b.empLocation)
                                     .WithMany("employees")
                                     .HasForeignKey("locationID");

            modelBuilder.Entity<OrderModel>()
                        .HasKey(b => new { b.orderID, b.validTo });

            modelBuilder.Entity<OrderModel>()
                                    .HasOne<EmployeesModels>(b => b.orderOwnerEmployeeModel)
                                    .WithMany("orders")
                                    .HasForeignKey("personelID")
                                    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderModel>()
                                    .HasMany<OrderDetailsModel>(b => b.orderdetailsmodels)
                                    .WithOne("OrderModel")
                                    .HasForeignKey("orderID", "validTo")
                                    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderModel>()
                                    .HasOne<stocklocationmodel>(b => b.orderLocation)
                                    .WithMany("orders")
                                    .HasForeignKey("orderLocationID")
                                    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderDetailsModel>()
                                    .HasKey(b => new { b.orderID, b.orderLineNo, b.validTo });
  
            modelBuilder.Entity<OrderDetailsModel>()
                                      .HasOne(a => a.OrderModel)
                                      .WithMany(b => b.orderdetailsmodels)
                                      .HasForeignKey("orderID", "validTo");

            modelBuilder.Entity<SalesModel>()
                .HasKey(b => new { b.saleDate, b.salesID, b.salesLineId, b.locationID });

            modelBuilder.Entity<SalesModel>()
                                    .HasOne(a => a.employeesmodels)
                                    .WithMany(b => b.sales)
                                    .HasForeignKey("personelID");

            modelBuilder.Entity<SalesModel>()
                        .HasOne(a => a.location)
                        .WithMany(b => b.sales)
                        .HasForeignKey("locationID");

            modelBuilder.Entity<salescounter>()
                        .HasKey(b => new { b.salesDate, b.locationID });

            modelBuilder.Entity<PackagedProductDetailsModel>()
                .HasKey(b => new { b.PackedProductID, b.PackagedProductLineNo, b.recDate, b.recStatus });

            modelBuilder.Entity<TeraziScreenMapping>()
                .HasKey(b => new { b.teraziID, b.barcodeID});

            modelBuilder.Entity<KasaMutabakat>()
                .HasKey(b => new { b.mutabakatTimeStamp, b.locationID, b.typeOfMutabakat });

            modelBuilder.Entity<KasaMutabakat>()
                                    .HasOne<EmployeesModels>(a => a.employee)
                                    .WithMany(b => b.kasamutabakat)
                                    .HasForeignKey("personelID");

            modelBuilder.Entity<Expenditures>()
                .HasKey(b => new { b.opDate, b.locationID });

            modelBuilder.Entity<LabelModel>()
                .HasKey(b => new { b.productBarcodeID});
 
            modelBuilder.Entity<baseproduct>()
                    .HasKey(b => new { b.baseId });

            modelBuilder.Entity<packedproduct>()
                    .HasKey(b => new { b.packedId });

            modelBuilder.Entity<packedproductdetail>()
                    .HasKey(b => new { b.packedId, b.contentLineNo });

            modelBuilder.Entity<packedproduct>()
                                    .HasMany<packedproductdetail>(b => b.packedProductDetails)
                                    .WithOne("packedProduct")
                                    .HasForeignKey("packedId");

            modelBuilder.Entity<packedproductdetail>()
                                    .HasOne<baseproduct>(a => a.baseProduct)
                                    .WithMany(b => b.packedProductDetail)
                                    .HasForeignKey("baseId");

            modelBuilder.Entity<products>()
                            .HasNoKey();

            modelBuilder.Entity<products>().ToView("products");

            modelBuilder.Entity<baseproduct>().HasAlternateKey("barcodeID");
            modelBuilder.Entity<packedproduct>().HasAlternateKey("packedProductBarcodeID");
            modelBuilder.Entity<packedproductdetail>().HasAlternateKey(b => new { b.packedProductBarcodeID, b.contentLineNo });
            modelBuilder.Entity<LabelModel>().HasAlternateKey("productBarcodeID");
        }
    }
}
