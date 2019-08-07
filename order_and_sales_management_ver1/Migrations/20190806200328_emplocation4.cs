using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class emplocation4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_orderLocationID",
                table: "OrderModel",
                column: "orderLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_StockLocationModel_orderLocationID",
                table: "OrderModel",
                column: "orderLocationID",
                principalTable: "StockLocationModel",
                principalColumn: "locationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_StockLocationModel_orderLocationID",
                table: "OrderModel");

            migrationBuilder.DropIndex(
                name: "IX_OrderModel_orderLocationID",
                table: "OrderModel");
        }
    }
}
