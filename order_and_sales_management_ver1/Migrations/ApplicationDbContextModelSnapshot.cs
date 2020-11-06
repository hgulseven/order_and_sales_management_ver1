﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using order_and_sales_management_ver1.Data;

namespace order_and_sales_management_ver1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.EmployeesModels", b =>
                {
                    b.Property<int>("personelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("accessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("connectionId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("locationID")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .HasColumnType("varchar(32) CHARACTER SET utf8mb4")
                        .HasMaxLength(32);

                    b.Property<string>("persName")
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.Property<string>("persSurName")
                        .HasColumnType("varchar(40) CHARACTER SET utf8mb4")
                        .HasMaxLength(40);

                    b.Property<int>("recStatus")
                        .HasColumnType("int");

                    b.Property<bool>("userActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("userName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("userRole")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("personelID");

                    b.HasIndex("locationID");

                    b.ToTable("employeesmodels");
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.Expenditures", b =>
                {
                    b.Property<DateTime>("opDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("locationID")
                        .HasColumnType("int");

                    b.Property<string>("aciklama")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<float>("amount")
                        .HasColumnType("float");

                    b.Property<int?>("employeepersonelID")
                        .HasColumnType("int");

                    b.HasKey("opDate", "locationID");

                    b.HasIndex("employeepersonelID");

                    b.ToTable("expenditures");
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.KasaMutabakat", b =>
                {
                    b.Property<DateTime>("mutabakatTimeStamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("locationID")
                        .HasColumnType("int");

                    b.Property<string>("typeOfMutabakat")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("change100TL")
                        .HasColumnType("int");

                    b.Property<int>("change10KRS")
                        .HasColumnType("int");

                    b.Property<int>("change10TL")
                        .HasColumnType("int");

                    b.Property<int>("change1TL")
                        .HasColumnType("int");

                    b.Property<int>("change200TL")
                        .HasColumnType("int");

                    b.Property<int>("change20TL")
                        .HasColumnType("int");

                    b.Property<int>("change25KRS")
                        .HasColumnType("int");

                    b.Property<int>("change50KRS")
                        .HasColumnType("int");

                    b.Property<int>("change50TL")
                        .HasColumnType("int");

                    b.Property<int>("change5TL")
                        .HasColumnType("int");

                    b.Property<int>("diger100TL")
                        .HasColumnType("int");

                    b.Property<int>("diger10KRS")
                        .HasColumnType("int");

                    b.Property<int>("diger10TL")
                        .HasColumnType("int");

                    b.Property<int>("diger1TL")
                        .HasColumnType("int");

                    b.Property<int>("diger200TL")
                        .HasColumnType("int");

                    b.Property<int>("diger20TL")
                        .HasColumnType("int");

                    b.Property<int>("diger25KRS")
                        .HasColumnType("int");

                    b.Property<int>("diger50KRS")
                        .HasColumnType("int");

                    b.Property<int>("diger50TL")
                        .HasColumnType("int");

                    b.Property<int>("diger5TL")
                        .HasColumnType("int");

                    b.Property<int?>("employeepersonelID")
                        .HasColumnType("int");

                    b.Property<float>("krediKartıToplam")
                        .HasColumnType("float");

                    b.Property<DateTime>("mutabakatDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("nakit100TL")
                        .HasColumnType("int");

                    b.Property<int>("nakit10KRS")
                        .HasColumnType("int");

                    b.Property<int>("nakit10TL")
                        .HasColumnType("int");

                    b.Property<int>("nakit1TL")
                        .HasColumnType("int");

                    b.Property<int>("nakit200TL")
                        .HasColumnType("int");

                    b.Property<int>("nakit20TL")
                        .HasColumnType("int");

                    b.Property<int>("nakit25KRS")
                        .HasColumnType("int");

                    b.Property<int>("nakit50KRS")
                        .HasColumnType("int");

                    b.Property<int>("nakit50TL")
                        .HasColumnType("int");

                    b.Property<int>("nakit5TL")
                        .HasColumnType("int");

                    b.Property<int>("personelID")
                        .HasColumnType("int");

                    b.Property<float>("sistemDigerToplam")
                        .HasColumnType("float");

                    b.Property<float>("sistemKrediKartıToplam")
                        .HasColumnType("float");

                    b.Property<float>("sistemNakitToplam")
                        .HasColumnType("float");

                    b.HasKey("mutabakatTimeStamp", "locationID", "typeOfMutabakat");

                    b.HasIndex("employeepersonelID");

                    b.ToTable("kasamutabakat");
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.LabelModel", b =>
                {
                    b.Property<int>("productID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("alerji")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("companyInfo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("mensei")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("productAmount")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("productBarcodID")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("productContents")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("productLawStr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("productLotNo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("productName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("productShelfLife")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("productStoringCond")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("productID");

                    b.ToTable("labelmodels");
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.OrderDetailsModel", b =>
                {
                    b.Property<int>("orderID")
                        .HasColumnType("int");

                    b.Property<int>("orderLineNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("validTo")
                        .HasColumnType("datetime(6)");

                    b.Property<float>("loadedProductAmount")
                        .HasColumnType("float");

                    b.Property<string>("orderCritic")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("orderDeliveryDate")
                        .HasColumnType("int");

                    b.Property<float>("productAmount")
                        .HasColumnType("float");

                    b.Property<int>("productID")
                        .HasColumnType("int");

                    b.Property<int>("productQualityChecker")
                        .HasColumnType("int");

                    b.Property<int>("productionLotID")
                        .HasColumnType("int");

                    b.Property<int>("recStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("validFrom")
                        .HasColumnType("datetime(6)");

                    b.HasKey("orderID", "orderLineNo", "validTo");

                    b.HasIndex("productID");

                    b.HasIndex("orderID", "validTo");

                    b.ToTable("orderdetailsmodels");
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.OrderModel", b =>
                {
                    b.Property<int>("orderID")
                        .HasColumnType("int");

                    b.Property<DateTime>("validTo")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("orderLocationID")
                        .HasColumnType("int");

                    b.Property<int>("personelID")
                        .HasColumnType("int");

                    b.Property<int>("recStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("validFrom")
                        .HasColumnType("datetime(6)");

                    b.HasKey("orderID", "validTo");

                    b.HasIndex("orderLocationID");

                    b.HasIndex("personelID");

                    b.ToTable("OrderModel");
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.PackagedProductDetailsModel", b =>
                {
                    b.Property<string>("PackedProductID")
                        .HasColumnType("varchar(13) CHARACTER SET utf8mb4")
                        .HasMaxLength(13);

                    b.Property<int>("PackagedProductLineNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("recDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("recStatus")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("double");

                    b.Property<int>("productID")
                        .HasColumnType("int");

                    b.HasKey("PackedProductID", "PackagedProductLineNo", "recDate", "recStatus");

                    b.HasIndex("productID");

                    b.ToTable("PackagedProductDetailsModel");
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.ProductModel", b =>
                {
                    b.Property<int>("productID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("productBarcodeID")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("productRetailPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("productWholesalePrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("recStatus")
                        .HasColumnType("int");

                    b.Property<string>("sellersID")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("productID");

                    b.ToTable("productmodels");
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.SalesModel", b =>
                {
                    b.Property<DateTime>("saleDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("salesID")
                        .HasColumnType("int");

                    b.Property<int>("salesLineId")
                        .HasColumnType("int");

                    b.Property<int>("locationID")
                        .HasColumnType("int");

                    b.Property<float>("amount")
                        .HasColumnType("float");

                    b.Property<float>("paidAmount")
                        .HasColumnType("float");

                    b.Property<int>("personelID")
                        .HasColumnType("int");

                    b.Property<string>("productBarcodeID")
                        .HasColumnType("varchar(13) CHARACTER SET utf8mb4")
                        .HasMaxLength(13);

                    b.Property<int>("productID")
                        .HasColumnType("int");

                    b.Property<DateTime>("saleTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("typeOfCollection")
                        .HasColumnType("int");

                    b.HasKey("saleDate", "salesID", "salesLineId", "locationID");

                    b.HasIndex("locationID");

                    b.HasIndex("personelID");

                    b.HasIndex("productID");

                    b.ToTable("salesmodels");
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.StockItem", b =>
                {
                    b.Property<int>("productID")
                        .HasColumnType("int");

                    b.Property<int>("locationID")
                        .HasColumnType("int");

                    b.Property<string>("productionLotID")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<int>("recStatus")
                        .HasColumnType("int");

                    b.Property<double>("stockAmount")
                        .HasColumnType("double");

                    b.HasKey("productID", "locationID", "productionLotID");

                    b.HasIndex("locationID");

                    b.ToTable("stockitems");
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.TeraziScreenMapping", b =>
                {
                    b.Property<int>("teraziID")
                        .HasColumnType("int");

                    b.Property<int>("productID")
                        .HasColumnType("int");

                    b.Property<int?>("screenSeqNo")
                        .HasColumnType("int");

                    b.HasKey("teraziID", "productID");

                    b.ToTable("TeraziScreenMapping");
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.ordercounter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("counter")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ordercounters");
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.packagedproductsbarcode", b =>
                {
                    b.Property<string>("barcodeID")
                        .HasColumnType("varchar(13) CHARACTER SET utf8mb4")
                        .HasMaxLength(13);

                    b.Property<int>("recStatus")
                        .HasColumnType("int");

                    b.HasKey("barcodeID");

                    b.ToTable("packagedproductsbarcodes");
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.salescounter", b =>
                {
                    b.Property<DateTime>("salesDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("locationID")
                        .HasColumnType("int");

                    b.Property<int>("counter")
                        .HasColumnType("int");

                    b.HasKey("salesDate", "locationID");

                    b.ToTable("salescounter");
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.stocklocationmodel", b =>
                {
                    b.Property<int>("locationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("locationName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("locationID");

                    b.ToTable("stocklocationmodel");
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.terazitable", b =>
                {
                    b.Property<int>("teraziID")
                        .HasColumnType("int");

                    b.Property<string>("TeraziName")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.HasKey("teraziID");

                    b.ToTable("terazitable");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.EmployeesModels", b =>
                {
                    b.HasOne("order_and_sales_management_ver1.Models.stocklocationmodel", "empLocation")
                        .WithMany("employees")
                        .HasForeignKey("locationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.Expenditures", b =>
                {
                    b.HasOne("order_and_sales_management_ver1.Models.EmployeesModels", "employee")
                        .WithMany()
                        .HasForeignKey("employeepersonelID");
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.KasaMutabakat", b =>
                {
                    b.HasOne("order_and_sales_management_ver1.Models.EmployeesModels", "employee")
                        .WithMany()
                        .HasForeignKey("employeepersonelID");
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.OrderDetailsModel", b =>
                {
                    b.HasOne("order_and_sales_management_ver1.Models.ProductModel", "ProductModel")
                        .WithMany("orderdetailsmodels")
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("order_and_sales_management_ver1.Models.OrderModel", "OrderModel")
                        .WithMany("orderdetailsmodels")
                        .HasForeignKey("orderID", "validTo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.OrderModel", b =>
                {
                    b.HasOne("order_and_sales_management_ver1.Models.stocklocationmodel", "orderLocation")
                        .WithMany("orders")
                        .HasForeignKey("orderLocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("order_and_sales_management_ver1.Models.EmployeesModels", "orderOwnerEmployeeModel")
                        .WithMany("orders")
                        .HasForeignKey("personelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.PackagedProductDetailsModel", b =>
                {
                    b.HasOne("order_and_sales_management_ver1.Models.ProductModel", "ProductModel")
                        .WithMany("packagedproductdetailsmodels")
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.SalesModel", b =>
                {
                    b.HasOne("order_and_sales_management_ver1.Models.stocklocationmodel", "location")
                        .WithMany("sales")
                        .HasForeignKey("locationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("order_and_sales_management_ver1.Models.EmployeesModels", "employeesmodels")
                        .WithMany("sales")
                        .HasForeignKey("personelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("order_and_sales_management_ver1.Models.ProductModel", "ProductModel")
                        .WithMany("salesmodels")
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("order_and_sales_management_ver1.Models.StockItem", b =>
                {
                    b.HasOne("order_and_sales_management_ver1.Models.stocklocationmodel", "stocklocationmodel")
                        .WithMany()
                        .HasForeignKey("locationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("order_and_sales_management_ver1.Models.ProductModel", "product")
                        .WithMany()
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
