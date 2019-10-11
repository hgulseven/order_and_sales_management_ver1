﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Order_And_Sales_Management_ver1.Data;

namespace order_and_sales_management_ver1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190911191435_check")]
    partial class check
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Order_And_Sales_Management_ver1.Models.EmployeesModels", b =>
                {
                    b.Property<int>("personelID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("accessFailedCount");

                    b.Property<string>("connectionId");

                    b.Property<int>("locationID");

                    b.Property<string>("password")
                        .HasMaxLength(32);

                    b.Property<string>("persName")
                        .HasMaxLength(40);

                    b.Property<string>("persSurName")
                        .HasMaxLength(40);

                    b.Property<int>("recStatus");

                    b.Property<bool>("userActive");

                    b.Property<string>("userName");

                    b.Property<string>("userRole");

                    b.HasKey("personelID");

                    b.HasIndex("locationID");

                    b.ToTable("employeesmodels");
                });

            modelBuilder.Entity("Order_And_Sales_Management_ver1.Models.OrderDetailsModel", b =>
                {
                    b.Property<int>("orderID");

                    b.Property<int>("orderLineNo");

                    b.Property<string>("orderCritic");

                    b.Property<int>("orderDeliveryDate");

                    b.Property<int>("productAmount");

                    b.Property<int>("productID");

                    b.Property<int>("productQualityChecker");

                    b.Property<int>("productionLotID");

                    b.Property<int>("recStatus");

                    b.HasKey("orderID", "orderLineNo");

                    b.HasIndex("productID");

                    b.ToTable("orderdetailsmodels");
                });

            modelBuilder.Entity("Order_And_Sales_Management_ver1.Models.OrderModel", b =>
                {
                    b.Property<int>("orderID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("orderDate");

                    b.Property<int>("orderLocationID");

                    b.Property<int?>("orderOwnerEmployeeModelpersonelID");

                    b.Property<int>("orderOwner_personelID");

                    b.Property<int>("recStatus");

                    b.HasKey("orderID");

                    b.HasIndex("orderLocationID");

                    b.HasIndex("orderOwnerEmployeeModelpersonelID");

                    b.HasIndex("orderOwner_personelID");

                    b.ToTable("OrderModel");
                });

            modelBuilder.Entity("Order_And_Sales_Management_ver1.Models.PackagedProductDetailsModel", b =>
                {
                    b.Property<int>("PackedProductID");

                    b.Property<int>("PackagedProductLineNo");

                    b.Property<double>("Amount");

                    b.Property<int>("ProductID");

                    b.HasKey("PackedProductID", "PackagedProductLineNo");

                    b.HasAlternateKey("PackagedProductLineNo", "PackedProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("packagedproductdetailsmodels");
                });

            modelBuilder.Entity("Order_And_Sales_Management_ver1.Models.ProductModel", b =>
                {
                    b.Property<int>("productID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProductName");

                    b.Property<string>("productBarcodeID");

                    b.Property<decimal>("productRetailPrice");

                    b.Property<decimal>("productWholesalePrice");

                    b.Property<int>("recStatus");

                    b.HasKey("productID");

                    b.ToTable("productmodels");
                });

            modelBuilder.Entity("Order_And_Sales_Management_ver1.Models.SalesModel", b =>
                {
                    b.Property<DateTime>("saleDate");

                    b.Property<int>("salesID");

                    b.Property<int>("salesLineId");

                    b.Property<float>("amount");

                    b.Property<float>("paidAmount");

                    b.Property<int>("personelID");

                    b.Property<int>("productID");

                    b.Property<int>("typeOfCollection");

                    b.HasKey("saleDate", "salesID", "salesLineId");

                    b.HasIndex("personelID");

                    b.HasIndex("productID");

                    b.ToTable("salesmodels");
                });

            modelBuilder.Entity("Order_And_Sales_Management_ver1.Models.StockItem", b =>
                {
                    b.Property<int>("productID");

                    b.Property<int>("locationID");

                    b.Property<string>("productionLotID")
                        .HasMaxLength(10);

                    b.Property<int>("recStatus");

                    b.Property<double>("stockAmount");

                    b.HasKey("productID", "locationID", "productionLotID");

                    b.HasAlternateKey("locationID", "productID", "productionLotID");

                    b.ToTable("stockitems");
                });

            modelBuilder.Entity("Order_And_Sales_Management_ver1.Models.stocklocationmodel", b =>
                {
                    b.Property<int>("locationID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("locationName");

                    b.HasKey("locationID");

                    b.ToTable("stocklocationmodel");
                });

            modelBuilder.Entity("Order_And_Sales_Management_ver1.Models.TeraziScreenMapping", b =>
                {
                    b.Property<int>("teraziID");

                    b.Property<int>("productID");

                    b.Property<int?>("screenSeqNo");

                    b.HasKey("teraziID", "productID");

                    b.HasAlternateKey("productID", "teraziID");

                    b.ToTable("TeraziScreenMapping");
                });

            modelBuilder.Entity("Order_And_Sales_Management_ver1.Models.terazitable", b =>
                {
                    b.Property<int>("teraziID");

                    b.Property<string>("TeraziName")
                        .HasMaxLength(20);

                    b.HasKey("teraziID");

                    b.ToTable("terazitable");
                });

            modelBuilder.Entity("Order_And_Sales_Management_ver1.Models.salescounter", b =>
                {
                    b.Property<DateTime>("salesDate");

                    b.Property<int>("counter");

                    b.HasKey("salesDate");

                    b.ToTable("salescounter");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Order_And_Sales_Management_ver1.Models.EmployeesModels", b =>
                {
                    b.HasOne("Order_And_Sales_Management_ver1.Models.stocklocationmodel", "empLocation")
                        .WithMany()
                        .HasForeignKey("locationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Order_And_Sales_Management_ver1.Models.OrderDetailsModel", b =>
                {
                    b.HasOne("Order_And_Sales_Management_ver1.Models.OrderModel", "OrderModel")
                        .WithMany("orderdetailsmodels")
                        .HasForeignKey("orderID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Order_And_Sales_Management_ver1.Models.ProductModel", "ProductModel")
                        .WithMany("orderdetailsmodels")
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Order_And_Sales_Management_ver1.Models.OrderModel", b =>
                {
                    b.HasOne("Order_And_Sales_Management_ver1.Models.stocklocationmodel", "orderLocation")
                        .WithMany()
                        .HasForeignKey("orderLocationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Order_And_Sales_Management_ver1.Models.EmployeesModels", "orderOwnerEmployeeModel")
                        .WithMany()
                        .HasForeignKey("orderOwnerEmployeeModelpersonelID");

                    b.HasOne("Order_And_Sales_Management_ver1.Models.EmployeesModels")
                        .WithMany()
                        .HasForeignKey("orderOwner_personelID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Order_And_Sales_Management_ver1.Models.PackagedProductDetailsModel", b =>
                {
                    b.HasOne("Order_And_Sales_Management_ver1.Models.ProductModel", "ProductModel")
                        .WithMany("packagedproductdetailsmodels")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Order_And_Sales_Management_ver1.Models.SalesModel", b =>
                {
                    b.HasOne("Order_And_Sales_Management_ver1.Models.EmployeesModels", "employeesmodels")
                        .WithMany()
                        .HasForeignKey("personelID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Order_And_Sales_Management_ver1.Models.ProductModel", "ProductModel")
                        .WithMany("salesmodels")
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Order_And_Sales_Management_ver1.Models.StockItem", b =>
                {
                    b.HasOne("Order_And_Sales_Management_ver1.Models.stocklocationmodel", "stocklocationmodel")
                        .WithMany()
                        .HasForeignKey("locationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Order_And_Sales_Management_ver1.Models.ProductModel", "product")
                        .WithMany()
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
