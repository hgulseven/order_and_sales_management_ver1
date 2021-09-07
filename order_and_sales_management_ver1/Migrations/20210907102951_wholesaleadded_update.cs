using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class wholesaleadded_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "wholsaleamount",
                table: "salesmodels");

            migrationBuilder.AddColumn<decimal>(
                name: "wholesaleamount",
                table: "salesmodels",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "wholesaleamount",
                table: "salesmodels");

            migrationBuilder.AddColumn<decimal>(
                name: "wholsaleamount",
                table: "salesmodels",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
