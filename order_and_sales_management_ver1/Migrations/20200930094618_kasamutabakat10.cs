using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class kasamutabakat10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_kasamutabakat_locationID_mutabakatDate_typeOfMutabakat",
                table: "kasamutabakat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_kasamutabakat",
                table: "kasamutabakat");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_kasamutabakat_locationID_mutabakatTimeStamp_typeOfMutabakat",
                table: "kasamutabakat",
                columns: new[] { "locationID", "mutabakatTimeStamp", "typeOfMutabakat" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_kasamutabakat",
                table: "kasamutabakat",
                columns: new[] { "mutabakatTimeStamp", "locationID", "typeOfMutabakat" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_kasamutabakat_locationID_mutabakatTimeStamp_typeOfMutabakat",
                table: "kasamutabakat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_kasamutabakat",
                table: "kasamutabakat");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_kasamutabakat_locationID_mutabakatDate_typeOfMutabakat",
                table: "kasamutabakat",
                columns: new[] { "locationID", "mutabakatDate", "typeOfMutabakat" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_kasamutabakat",
                table: "kasamutabakat",
                columns: new[] { "mutabakatDate", "locationID", "typeOfMutabakat" });
        }
    }
}
