using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class ff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "productWholesalePrice",
                table: "ProductModels",
                type: "money",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "productRetailPrice",
                table: "ProductModels",
                type: "money",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "productWholesalePrice",
                table: "ProductModels",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<double>(
                name: "productRetailPrice",
                table: "ProductModels",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }
    }
}
