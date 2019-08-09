using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class terazitableadded3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeraziTables",
                table: "TeraziTables");

            migrationBuilder.RenameTable(
                name: "TeraziTables",
                newName: "TeraziTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeraziTable",
                table: "TeraziTable",
                column: "teraziID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeraziTable",
                table: "TeraziTable");

            migrationBuilder.RenameTable(
                name: "TeraziTable",
                newName: "TeraziTables");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeraziTables",
                table: "TeraziTables",
                column: "teraziID");
        }
    }
}
