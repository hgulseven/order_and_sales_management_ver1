using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class updatesales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_salesmodels",
                table: "salesmodels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_salesmodels",
                table: "salesmodels",
                columns: new[] { "saleDate", "salesID", "salesLineId", "locationID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_salesmodels",
                table: "salesmodels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_salesmodels",
                table: "salesmodels",
                columns: new[] { "saleDate", "salesID", "salesLineId" });
        }
    }
}
