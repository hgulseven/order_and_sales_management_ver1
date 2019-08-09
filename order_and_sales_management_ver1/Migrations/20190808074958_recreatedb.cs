using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class recreatedb : Migration
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
                name: "ProductModels",
                columns: table => new
                {
                    productID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(nullable: true),
                    productBarcodeID = table.Column<string>(nullable: true),
                    productRetailPrice = table.Column<double>(nullable: false),
                    productWholesalePrice = table.Column<double>(nullable: false),
                    recStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModels", x => x.productID);
                });

            migrationBuilder.CreateTable(
                name: "StockLocationModel",
                columns: table => new
                {
                    locationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    locationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockLocationModel", x => x.locationID);
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
                    table.UniqueConstraint("AK_TeraziScreenMapping_productID_teraziID", x => new { x.productID, x.teraziID });
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                name: "PackagedProductDetailsModels",
                columns: table => new
                {
                    PackedProductID = table.Column<int>(nullable: false),
                    PackagedProductLineNo = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagedProductDetailsModels", x => new { x.PackedProductID, x.PackagedProductLineNo });
                    table.UniqueConstraint("AK_PackagedProductDetailsModels_PackagedProductLineNo_PackedProductID", x => new { x.PackagedProductLineNo, x.PackedProductID });
                    table.ForeignKey(
                        name: "FK_PackagedProductDetailsModels_ProductModels_ProductID",
                        column: x => x.ProductID,
                        principalTable: "ProductModels",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesModels",
                columns: table => new
                {
                    personelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    persName = table.Column<string>(maxLength: 40, nullable: true),
                    persSurName = table.Column<string>(maxLength: 40, nullable: true),
                    password = table.Column<string>(maxLength: 32, nullable: true),
                    locationID = table.Column<int>(nullable: false),
                    userName = table.Column<string>(nullable: true),
                    connectionId = table.Column<string>(nullable: true),
                    userRole = table.Column<string>(nullable: true),
                    userActive = table.Column<bool>(nullable: false),
                    accessFailedCount = table.Column<int>(nullable: false),
                    recStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesModels", x => x.personelID);
                    table.ForeignKey(
                        name: "FK_EmployeesModels_StockLocationModel_locationID",
                        column: x => x.locationID,
                        principalTable: "StockLocationModel",
                        principalColumn: "locationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockItems",
                columns: table => new
                {
                    productID = table.Column<int>(nullable: false),
                    locationID = table.Column<int>(nullable: false),
                    productionLotID = table.Column<string>(maxLength: 10, nullable: false),
                    stockAmount = table.Column<double>(nullable: false),
                    recStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItems", x => new { x.productID, x.locationID, x.productionLotID });
                    table.UniqueConstraint("AK_StockItems_locationID_productID_productionLotID", x => new { x.locationID, x.productID, x.productionLotID });
                    table.ForeignKey(
                        name: "FK_StockItems_StockLocationModel_locationID",
                        column: x => x.locationID,
                        principalTable: "StockLocationModel",
                        principalColumn: "locationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockItems_ProductModels_productID",
                        column: x => x.productID,
                        principalTable: "ProductModels",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderModel",
                columns: table => new
                {
                    orderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    orderDate = table.Column<DateTime>(nullable: false),
                    recStatus = table.Column<bool>(nullable: false),
                    orderOwner_personelID = table.Column<int>(nullable: false),
                    orderOwnerEmployeeModelpersonelID = table.Column<int>(nullable: true),
                    orderLocationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModel", x => x.orderID);
                    table.ForeignKey(
                        name: "FK_OrderModel_StockLocationModel_orderLocationID",
                        column: x => x.orderLocationID,
                        principalTable: "StockLocationModel",
                        principalColumn: "locationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderModel_EmployeesModels_orderOwnerEmployeeModelpersonelID",
                        column: x => x.orderOwnerEmployeeModelpersonelID,
                        principalTable: "EmployeesModels",
                        principalColumn: "personelID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderModel_EmployeesModels_orderOwner_personelID",
                        column: x => x.orderOwner_personelID,
                        principalTable: "EmployeesModels",
                        principalColumn: "personelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesModels",
                columns: table => new
                {
                    saleDate = table.Column<DateTime>(nullable: false),
                    salesID = table.Column<int>(nullable: false),
                    salesLineId = table.Column<int>(nullable: false),
                    personelID = table.Column<int>(nullable: false),
                    productID = table.Column<int>(nullable: false),
                    amount = table.Column<int>(nullable: false),
                    typeOfCollection = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesModels", x => new { x.saleDate, x.salesID, x.salesLineId });
                    table.ForeignKey(
                        name: "FK_SalesModels_EmployeesModels_personelID",
                        column: x => x.personelID,
                        principalTable: "EmployeesModels",
                        principalColumn: "personelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesModels_ProductModels_productID",
                        column: x => x.productID,
                        principalTable: "ProductModels",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailsModels",
                columns: table => new
                {
                    orderID = table.Column<int>(nullable: false),
                    orderLineNo = table.Column<int>(nullable: false),
                    productID = table.Column<int>(nullable: false),
                    productAmount = table.Column<int>(nullable: false),
                    orderDeliveryDate = table.Column<int>(nullable: false),
                    productionLotID = table.Column<int>(nullable: false),
                    productQualityChecker = table.Column<int>(nullable: false),
                    orderCritic = table.Column<string>(nullable: true),
                    recStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailsModels", x => new { x.orderID, x.orderLineNo });
                    table.ForeignKey(
                        name: "FK_OrderDetailsModels_OrderModel_orderID",
                        column: x => x.orderID,
                        principalTable: "OrderModel",
                        principalColumn: "orderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetailsModels_ProductModels_productID",
                        column: x => x.productID,
                        principalTable: "ProductModels",
                        principalColumn: "productID",
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
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesModels_locationID",
                table: "EmployeesModels",
                column: "locationID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailsModels_productID",
                table: "OrderDetailsModels",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_orderLocationID",
                table: "OrderModel",
                column: "orderLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_orderOwnerEmployeeModelpersonelID",
                table: "OrderModel",
                column: "orderOwnerEmployeeModelpersonelID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_orderOwner_personelID",
                table: "OrderModel",
                column: "orderOwner_personelID");

            migrationBuilder.CreateIndex(
                name: "IX_PackagedProductDetailsModels_ProductID",
                table: "PackagedProductDetailsModels",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesModels_personelID",
                table: "SalesModels",
                column: "personelID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesModels_productID",
                table: "SalesModels",
                column: "productID");
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
                name: "OrderDetailsModels");

            migrationBuilder.DropTable(
                name: "PackagedProductDetailsModels");

            migrationBuilder.DropTable(
                name: "SalesModels");

            migrationBuilder.DropTable(
                name: "StockItems");

            migrationBuilder.DropTable(
                name: "TeraziScreenMapping");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OrderModel");

            migrationBuilder.DropTable(
                name: "ProductModels");

            migrationBuilder.DropTable(
                name: "EmployeesModels");

            migrationBuilder.DropTable(
                name: "StockLocationModel");
        }
    }
}
