using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class foreignkey5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_StockLocationModel_StockLocationModellocationID",
                table: "StockItems");

            migrationBuilder.DropIndex(
                name: "IX_StockItems_StockLocationModellocationID",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "StockLocationModellocationID",
                table: "StockItems");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_StockLocationModel_locationID",
                table: "StockItems",
                column: "locationID",
                principalTable: "StockLocationModel",
                principalColumn: "locationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_StockLocationModel_locationID",
                table: "StockItems");

            migrationBuilder.AddColumn<int>(
                name: "StockLocationModellocationID",
                table: "StockItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_StockLocationModellocationID",
                table: "StockItems",
                column: "StockLocationModellocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_StockLocationModel_StockLocationModellocationID",
                table: "StockItems",
                column: "StockLocationModellocationID",
                principalTable: "StockLocationModel",
                principalColumn: "locationID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
