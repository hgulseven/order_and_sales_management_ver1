using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class wholesaleadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "wholsaleamount",
                table: "salesmodels",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "wholsaleamount",
                table: "salesmodels");
        }
    }
}
