using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class kasaMutabakat5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "kerdiKartıToplam",
                table: "kasamutabakat",
                newName: "krediKartıToplam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "krediKartıToplam",
                table: "kasamutabakat",
                newName: "kerdiKartıToplam");
        }
    }
}
