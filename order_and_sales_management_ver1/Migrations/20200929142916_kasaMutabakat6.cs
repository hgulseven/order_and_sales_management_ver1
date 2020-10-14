using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class kasaMutabakat6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "locationID",
                table: "kasamutabakat",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_kasamutabakat_locationID_opDate_typeOfMutabakat",
                table: "kasamutabakat",
                columns: new[] { "locationID", "opDate", "typeOfMutabakat" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_kasamutabakat_locationID_opDate_typeOfMutabakat",
                table: "kasamutabakat");

            migrationBuilder.DropColumn(
                name: "locationID",
                table: "kasamutabakat");
        }
    }
}
