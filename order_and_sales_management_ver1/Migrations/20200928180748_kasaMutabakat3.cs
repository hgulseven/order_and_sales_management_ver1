using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class kasaMutabakat3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "changeMoney25KRS",
                table: "kasamutabakat",
                newName: "change25KRS");

            migrationBuilder.RenameColumn(
                name: "changeMoney10KRS",
                table: "kasamutabakat",
                newName: "change10KRS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "change25KRS",
                table: "kasamutabakat",
                newName: "changeMoney25KRS");

            migrationBuilder.RenameColumn(
                name: "change10KRS",
                table: "kasamutabakat",
                newName: "changeMoney10KRS");
        }
    }
}
