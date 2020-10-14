using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class kasaMutabakat9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_kasamutabakat",
                table: "kasamutabakat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_expenditures",
                table: "expenditures");

            migrationBuilder.AddColumn<int>(
                name: "locationID",
                table: "expenditures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_kasamutabakat",
                table: "kasamutabakat",
                columns: new[] { "mutabakatDate", "locationID", "typeOfMutabakat" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_expenditures_locationID_opDate",
                table: "expenditures",
                columns: new[] { "locationID", "opDate" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_expenditures",
                table: "expenditures",
                columns: new[] { "opDate", "locationID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_kasamutabakat",
                table: "kasamutabakat");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_expenditures_locationID_opDate",
                table: "expenditures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_expenditures",
                table: "expenditures");

            migrationBuilder.DropColumn(
                name: "locationID",
                table: "expenditures");

            migrationBuilder.AddPrimaryKey(
                name: "PK_kasamutabakat",
                table: "kasamutabakat",
                columns: new[] { "mutabakatDate", "typeOfMutabakat" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_expenditures",
                table: "expenditures",
                column: "opDate");
        }
    }
}
