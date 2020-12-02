using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class barcodeupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "barcodProductId",
                table: "packedProducts");

            migrationBuilder.AddColumn<string>(
                name: "barcodeID",
                table: "packedProducts",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "barcodeID",
                table: "baseProducts",
                maxLength: 13,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "barcodeID",
                table: "packedProducts");

            migrationBuilder.AddColumn<string>(
                name: "barcodProductId",
                table: "packedProducts",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "barcodeID",
                table: "baseProducts",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 13,
                oldNullable: true);
        }
    }
}
