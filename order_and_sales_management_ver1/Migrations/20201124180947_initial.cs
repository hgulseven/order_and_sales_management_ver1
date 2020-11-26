using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "baseProducts",
                columns: table => new
                {
                    baseId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    retailPrice = table.Column<decimal>(nullable: false),
                    wholeSalePrice = table.Column<decimal>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    sellersID = table.Column<string>(nullable: true),
                    detailsId = table.Column<int>(nullable: false),
                    barcodeID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_baseProducts", x => x.baseId);
                });

            migrationBuilder.CreateTable(
                name: "labelmodels",
                columns: table => new
                {
                    productID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    productName = table.Column<string>(nullable: true),
                    productAmount = table.Column<string>(nullable: true),
                    productContents = table.Column<string>(nullable: true),
                    productLawStr = table.Column<string>(nullable: true),
                    productStoringCond = table.Column<string>(nullable: true),
                    productShelfLife = table.Column<string>(nullable: true),
                    productLotNo = table.Column<string>(nullable: true),
                    productBarcodID = table.Column<string>(nullable: true),
                    companyInfo = table.Column<string>(nullable: true),
                    mensei = table.Column<string>(nullable: true),
                    alerji = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labelmodels", x => x.productID);
                });

            migrationBuilder.CreateTable(
                name: "ordercounters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    counter = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordercounters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "packagedproductsbarcodes",
                columns: table => new
                {
                    barcodeID = table.Column<string>(maxLength: 13, nullable: false),
                    recStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packagedproductsbarcodes", x => x.barcodeID);
                });

            migrationBuilder.CreateTable(
                name: "packedProducts",
                columns: table => new
                {
                    packedId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    packedProductName = table.Column<string>(nullable: true),
                    barcodProductId = table.Column<string>(nullable: true),
                    productRetailPrice = table.Column<decimal>(nullable: false),
                    productWholesalePrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packedProducts", x => x.packedId);
                });

            migrationBuilder.CreateTable(
                name: "productmodels",
                columns: table => new
                {
                    productID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(nullable: true),
                    productBarcodeID = table.Column<string>(maxLength: 13, nullable: true),
                    productRetailPrice = table.Column<decimal>(nullable: false),
                    productWholesalePrice = table.Column<decimal>(nullable: false),
                    recStatus = table.Column<int>(nullable: false),
                    sellersID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productmodels", x => x.productID);
                });

            migrationBuilder.CreateTable(
                name: "salescounter",
                columns: table => new
                {
                    salesDate = table.Column<DateTime>(nullable: false),
                    locationID = table.Column<int>(nullable: false),
                    counter = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salescounter", x => new { x.salesDate, x.locationID });
                });

            migrationBuilder.CreateTable(
                name: "stocklocationmodel",
                columns: table => new
                {
                    locationID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    locationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stocklocationmodel", x => x.locationID);
                });

            migrationBuilder.CreateTable(
                name: "TeraziScreenMapping",
                columns: table => new
                {
                    teraziID = table.Column<int>(nullable: false),
                    productID = table.Column<int>(nullable: false),
                    screenSeqNo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeraziScreenMapping", x => new { x.teraziID, x.productID });
                });

            migrationBuilder.CreateTable(
                name: "terazitable",
                columns: table => new
                {
                    teraziID = table.Column<int>(nullable: false),
                    TeraziName = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_terazitable", x => x.teraziID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "packedProductDetails",
                columns: table => new
                {
                    packedId = table.Column<int>(nullable: false),
                    contentLineNo = table.Column<int>(nullable: false),
                    barcodProductId = table.Column<string>(nullable: true),
                    baseId = table.Column<int>(nullable: false),
                    amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packedProductDetails", x => new { x.packedId, x.contentLineNo });
                    table.ForeignKey(
                        name: "FK_packedProductDetails_baseProducts_baseId",
                        column: x => x.baseId,
                        principalTable: "baseProducts",
                        principalColumn: "baseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_packedProductDetails_packedProducts_packedId",
                        column: x => x.packedId,
                        principalTable: "packedProducts",
                        principalColumn: "packedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackagedProductDetailsModel",
                columns: table => new
                {
                    PackedProductID = table.Column<string>(maxLength: 13, nullable: false),
                    PackagedProductLineNo = table.Column<int>(nullable: false),
                    recStatus = table.Column<int>(nullable: false),
                    recDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    productID = table.Column<int>(nullable: false),
                    customerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagedProductDetailsModel", x => new { x.PackedProductID, x.PackagedProductLineNo, x.recDate, x.recStatus });
                    table.ForeignKey(
                        name: "FK_PackagedProductDetailsModel_productmodels_productID",
                        column: x => x.productID,
                        principalTable: "productmodels",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employeesmodels",
                columns: table => new
                {
                    personelID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    persName = table.Column<string>(maxLength: 40, nullable: true),
                    persSurName = table.Column<string>(maxLength: 40, nullable: true),
                    password = table.Column<string>(maxLength: 32, nullable: true),
                    locationID = table.Column<int>(nullable: false),
                    userName = table.Column<string>(nullable: true),
                    connectionId = table.Column<string>(nullable: true),
                    userRole = table.Column<string>(nullable: true),
                    userActive = table.Column<bool>(nullable: false),
                    accessFailedCount = table.Column<int>(nullable: false),
                    recStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeesmodels", x => x.personelID);
                    table.ForeignKey(
                        name: "FK_employeesmodels_stocklocationmodel_locationID",
                        column: x => x.locationID,
                        principalTable: "stocklocationmodel",
                        principalColumn: "locationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stockitems",
                columns: table => new
                {
                    productID = table.Column<int>(nullable: false),
                    locationID = table.Column<int>(nullable: false),
                    productionLotID = table.Column<string>(maxLength: 10, nullable: false),
                    stockAmount = table.Column<double>(nullable: false),
                    recStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stockitems", x => new { x.productID, x.locationID, x.productionLotID });
                    table.ForeignKey(
                        name: "FK_stockitems_stocklocationmodel_locationID",
                        column: x => x.locationID,
                        principalTable: "stocklocationmodel",
                        principalColumn: "locationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stockitems_productmodels_productID",
                        column: x => x.productID,
                        principalTable: "productmodels",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "expenditures",
                columns: table => new
                {
                    opDate = table.Column<DateTime>(nullable: false),
                    locationID = table.Column<int>(nullable: false),
                    employeepersonelID = table.Column<int>(nullable: true),
                    aciklama = table.Column<string>(nullable: true),
                    amount = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenditures", x => new { x.opDate, x.locationID });
                    table.ForeignKey(
                        name: "FK_expenditures_employeesmodels_employeepersonelID",
                        column: x => x.employeepersonelID,
                        principalTable: "employeesmodels",
                        principalColumn: "personelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "kasamutabakat",
                columns: table => new
                {
                    mutabakatTimeStamp = table.Column<DateTime>(nullable: false),
                    locationID = table.Column<int>(nullable: false),
                    typeOfMutabakat = table.Column<string>(nullable: false),
                    mutabakatDate = table.Column<DateTime>(nullable: false),
                    employeepersonelID = table.Column<int>(nullable: true),
                    personelID = table.Column<int>(nullable: false),
                    change10KRS = table.Column<int>(nullable: false),
                    change25KRS = table.Column<int>(nullable: false),
                    change50KRS = table.Column<int>(nullable: false),
                    change1TL = table.Column<int>(nullable: false),
                    change5TL = table.Column<int>(nullable: false),
                    change10TL = table.Column<int>(nullable: false),
                    change20TL = table.Column<int>(nullable: false),
                    change50TL = table.Column<int>(nullable: false),
                    change100TL = table.Column<int>(nullable: false),
                    change200TL = table.Column<int>(nullable: false),
                    nakit10KRS = table.Column<int>(nullable: false),
                    nakit25KRS = table.Column<int>(nullable: false),
                    nakit50KRS = table.Column<int>(nullable: false),
                    nakit1TL = table.Column<int>(nullable: false),
                    nakit5TL = table.Column<int>(nullable: false),
                    nakit10TL = table.Column<int>(nullable: false),
                    nakit20TL = table.Column<int>(nullable: false),
                    nakit50TL = table.Column<int>(nullable: false),
                    nakit100TL = table.Column<int>(nullable: false),
                    nakit200TL = table.Column<int>(nullable: false),
                    diger10KRS = table.Column<int>(nullable: false),
                    diger25KRS = table.Column<int>(nullable: false),
                    diger50KRS = table.Column<int>(nullable: false),
                    diger1TL = table.Column<int>(nullable: false),
                    diger5TL = table.Column<int>(nullable: false),
                    diger10TL = table.Column<int>(nullable: false),
                    diger20TL = table.Column<int>(nullable: false),
                    diger50TL = table.Column<int>(nullable: false),
                    diger100TL = table.Column<int>(nullable: false),
                    diger200TL = table.Column<int>(nullable: false),
                    krediKartıToplam = table.Column<float>(nullable: false),
                    sistemNakitToplam = table.Column<float>(nullable: false),
                    sistemKrediKartıToplam = table.Column<float>(nullable: false),
                    sistemDigerToplam = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kasamutabakat", x => new { x.mutabakatTimeStamp, x.locationID, x.typeOfMutabakat });
                    table.ForeignKey(
                        name: "FK_kasamutabakat_employeesmodels_employeepersonelID",
                        column: x => x.employeepersonelID,
                        principalTable: "employeesmodels",
                        principalColumn: "personelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderModel",
                columns: table => new
                {
                    orderID = table.Column<int>(nullable: false),
                    validTo = table.Column<DateTime>(nullable: false),
                    orderDate = table.Column<DateTime>(nullable: false),
                    recStatus = table.Column<int>(nullable: false),
                    personelID = table.Column<int>(nullable: false),
                    orderLocationID = table.Column<int>(nullable: false),
                    validFrom = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModel", x => new { x.orderID, x.validTo });
                    table.ForeignKey(
                        name: "FK_OrderModel_stocklocationmodel_orderLocationID",
                        column: x => x.orderLocationID,
                        principalTable: "stocklocationmodel",
                        principalColumn: "locationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderModel_employeesmodels_personelID",
                        column: x => x.personelID,
                        principalTable: "employeesmodels",
                        principalColumn: "personelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "salesmodels",
                columns: table => new
                {
                    saleDate = table.Column<DateTime>(nullable: false),
                    salesID = table.Column<int>(nullable: false),
                    salesLineId = table.Column<int>(nullable: false),
                    locationID = table.Column<int>(nullable: false),
                    saleTime = table.Column<DateTime>(nullable: false),
                    personelID = table.Column<int>(nullable: false),
                    productID = table.Column<int>(nullable: false),
                    amount = table.Column<float>(nullable: false),
                    paidAmount = table.Column<float>(nullable: false),
                    typeOfCollection = table.Column<int>(nullable: false),
                    productBarcodeID = table.Column<string>(maxLength: 13, nullable: true),
                    dara = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salesmodels", x => new { x.saleDate, x.salesID, x.salesLineId, x.locationID });
                    table.ForeignKey(
                        name: "FK_salesmodels_stocklocationmodel_locationID",
                        column: x => x.locationID,
                        principalTable: "stocklocationmodel",
                        principalColumn: "locationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_salesmodels_employeesmodels_personelID",
                        column: x => x.personelID,
                        principalTable: "employeesmodels",
                        principalColumn: "personelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_salesmodels_productmodels_productID",
                        column: x => x.productID,
                        principalTable: "productmodels",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderdetailsmodels",
                columns: table => new
                {
                    orderID = table.Column<int>(nullable: false),
                    orderLineNo = table.Column<int>(nullable: false),
                    validTo = table.Column<DateTime>(nullable: false),
                    productID = table.Column<int>(nullable: false),
                    productAmount = table.Column<float>(nullable: false),
                    loadedProductAmount = table.Column<float>(nullable: false),
                    orderDeliveryDate = table.Column<int>(nullable: false),
                    productionLotID = table.Column<int>(nullable: false),
                    productQualityChecker = table.Column<int>(nullable: false),
                    orderCritic = table.Column<string>(nullable: true),
                    validFrom = table.Column<DateTime>(nullable: false),
                    recStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderdetailsmodels", x => new { x.orderID, x.orderLineNo, x.validTo });
                    table.ForeignKey(
                        name: "FK_orderdetailsmodels_productmodels_productID",
                        column: x => x.productID,
                        principalTable: "productmodels",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderdetailsmodels_OrderModel_orderID_validTo",
                        columns: x => new { x.orderID, x.validTo },
                        principalTable: "OrderModel",
                        principalColumns: new[] { "orderID", "validTo" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employeesmodels_locationID",
                table: "employeesmodels",
                column: "locationID");

            migrationBuilder.CreateIndex(
                name: "IX_expenditures_employeepersonelID",
                table: "expenditures",
                column: "employeepersonelID");

            migrationBuilder.CreateIndex(
                name: "IX_kasamutabakat_employeepersonelID",
                table: "kasamutabakat",
                column: "employeepersonelID");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetailsmodels_productID",
                table: "orderdetailsmodels",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetailsmodels_orderID_validTo",
                table: "orderdetailsmodels",
                columns: new[] { "orderID", "validTo" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_orderLocationID",
                table: "OrderModel",
                column: "orderLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_personelID",
                table: "OrderModel",
                column: "personelID");

            migrationBuilder.CreateIndex(
                name: "IX_PackagedProductDetailsModel_productID",
                table: "PackagedProductDetailsModel",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_packedProductDetails_baseId",
                table: "packedProductDetails",
                column: "baseId");

            migrationBuilder.CreateIndex(
                name: "IX_productmodels_productBarcodeID",
                table: "productmodels",
                column: "productBarcodeID");

            migrationBuilder.CreateIndex(
                name: "IX_salesmodels_locationID",
                table: "salesmodels",
                column: "locationID");

            migrationBuilder.CreateIndex(
                name: "IX_salesmodels_personelID",
                table: "salesmodels",
                column: "personelID");

            migrationBuilder.CreateIndex(
                name: "IX_salesmodels_productID",
                table: "salesmodels",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_stockitems_locationID",
                table: "stockitems",
                column: "locationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "expenditures");

            migrationBuilder.DropTable(
                name: "kasamutabakat");

            migrationBuilder.DropTable(
                name: "labelmodels");

            migrationBuilder.DropTable(
                name: "ordercounters");

            migrationBuilder.DropTable(
                name: "orderdetailsmodels");

            migrationBuilder.DropTable(
                name: "PackagedProductDetailsModel");

            migrationBuilder.DropTable(
                name: "packagedproductsbarcodes");

            migrationBuilder.DropTable(
                name: "packedProductDetails");

            migrationBuilder.DropTable(
                name: "salescounter");

            migrationBuilder.DropTable(
                name: "salesmodels");

            migrationBuilder.DropTable(
                name: "stockitems");

            migrationBuilder.DropTable(
                name: "TeraziScreenMapping");

            migrationBuilder.DropTable(
                name: "terazitable");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OrderModel");

            migrationBuilder.DropTable(
                name: "baseProducts");

            migrationBuilder.DropTable(
                name: "packedProducts");

            migrationBuilder.DropTable(
                name: "productmodels");

            migrationBuilder.DropTable(
                name: "employeesmodels");

            migrationBuilder.DropTable(
                name: "stocklocationmodel");
        }
    }
}
