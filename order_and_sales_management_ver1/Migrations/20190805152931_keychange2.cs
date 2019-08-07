using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class keychange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StockItems",
                table: "StockItems");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_StockItems_locationID_productID_productionLotID",
                table: "StockItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockItems",
                table: "StockItems",
                columns: new[] { "productID", "locationID", "productionLotID" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_StockItems_locationID_productID_productionLotID",
                table: "StockItems",
                columns: new[] { "locationID", "productID", "productionLotID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StockItems",
                table: "StockItems");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_StockItems_locationID_productID_productionLotID",
                table: "StockItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockItems",
                table: "StockItems",
                columns: new[] { "productID", "locationID", "productionLotID" });
        }
    }
}
