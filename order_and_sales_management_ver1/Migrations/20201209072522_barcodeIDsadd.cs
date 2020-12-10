using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class barcodeIDsadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "packedProductBarcodeID",
                table: "packedProducts",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "baseProductBarcodeID",
                table: "packedProductDetails",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "packedProductBarcodeID",
                table: "packedProductDetails",
                maxLength: 13,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "packedProductBarcodeID",
                table: "packedProducts");

            migrationBuilder.DropColumn(
                name: "baseProductBarcodeID",
                table: "packedProductDetails");

            migrationBuilder.DropColumn(
                name: "packedProductBarcodeID",
                table: "packedProductDetails");
        }
    }
}
