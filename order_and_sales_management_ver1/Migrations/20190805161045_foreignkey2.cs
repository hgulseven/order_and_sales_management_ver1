using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class foreignkey2 : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
