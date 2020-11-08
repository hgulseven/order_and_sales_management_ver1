using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class barcodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "barcodProductId",
                table: "packedProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "barcodProductId",
                table: "packedProductDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "barcodProductId",
                table: "packedProducts");

            migrationBuilder.DropColumn(
                name: "barcodProductId",
                table: "packedProductDetails");
        }
    }
}
