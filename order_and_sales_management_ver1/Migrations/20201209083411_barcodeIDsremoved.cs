using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class barcodeIDsremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "barcodeID",
                table: "packedProducts");

            migrationBuilder.DropColumn(
                name: "barcodProductId",
                table: "packedProductDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "barcodeID",
                table: "packedProducts",
                type: "varchar(13) CHARACTER SET utf8mb4",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "barcodProductId",
                table: "packedProductDetails",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
