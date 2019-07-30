using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeesModel",
                columns: table => new
                {
                    personelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    persName = table.Column<string>(maxLength: 40, nullable: true),
                    persSurName = table.Column<string>(maxLength: 40, nullable: true),
                    password = table.Column<string>(maxLength: 32, nullable: true),
                    userName = table.Column<string>(nullable: true),
                    connectionId = table.Column<string>(nullable: true),
                    userRole = table.Column<string>(nullable: true),
                    userActive = table.Column<bool>(nullable: false),
                    accessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesModel", x => x.personelID);
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
                    productWholesalePrice = table.Column<double>(nullable: false)
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
                name: "OrderModel",
                columns: table => new
                {
                    orderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    orderDate = table.Column<DateTime>(nullable: false),
                    orderOwnerEmployeeModelpersonelID = table.Column<int>(nullable: true),
                    orderOwner_personelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModel", x => x.orderID);
                    table.ForeignKey(
                        name: "FK_OrderModel_EmployeesModel_orderOwnerEmployeeModelpersonelID",
                        column: x => x.orderOwnerEmployeeModelpersonelID,
                        principalTable: "EmployeesModel",
                        principalColumn: "personelID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderModel_EmployeesModel_orderOwner_personelID",
                        column: x => x.orderOwner_personelID,
                        principalTable: "EmployeesModel",
                        principalColumn: "personelID",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_SalesModels_EmployeesModel_personelID",
                        column: x => x.personelID,
                        principalTable: "EmployeesModel",
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
                name: "StockItems",
                columns: table => new
                {
                    productID = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: false),
                    stockAmount = table.Column<double>(nullable: false),
                    productionLotID = table.Column<int>(nullable: false),
                    StockLocationModellocationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItems", x => new { x.productID, x.LocationID });
                    table.UniqueConstraint("AK_StockItems_LocationID_productID", x => new { x.LocationID, x.productID });
                    table.ForeignKey(
                        name: "FK_StockItems_StockLocationModel_StockLocationModellocationID",
                        column: x => x.StockLocationModellocationID,
                        principalTable: "StockLocationModel",
                        principalColumn: "locationID",
                        onDelete: ReferentialAction.Restrict);
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
                    OrderModelorderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailsModels", x => new { x.orderID, x.orderLineNo });
                    table.ForeignKey(
                        name: "FK_OrderDetailsModels_OrderModel_OrderModelorderID",
                        column: x => x.OrderModelorderID,
                        principalTable: "OrderModel",
                        principalColumn: "orderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetailsModels_ProductModels_productID",
                        column: x => x.productID,
                        principalTable: "ProductModels",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailsModels_OrderModelorderID",
                table: "OrderDetailsModels",
                column: "OrderModelorderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailsModels_productID",
                table: "OrderDetailsModels",
                column: "productID");

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

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_StockLocationModellocationID",
                table: "StockItems",
                column: "StockLocationModellocationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "OrderModel");

            migrationBuilder.DropTable(
                name: "ProductModels");

            migrationBuilder.DropTable(
                name: "StockLocationModel");

            migrationBuilder.DropTable(
                name: "EmployeesModel");
        }
    }
}
