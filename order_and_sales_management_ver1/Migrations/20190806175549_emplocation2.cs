using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class emplocation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "empLocationlocationID",
                table: "EmployeesModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesModel_empLocationlocationID",
                table: "EmployeesModel",
                column: "empLocationlocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesModel_StockLocationModel_empLocationlocationID",
                table: "EmployeesModel",
                column: "empLocationlocationID",
                principalTable: "StockLocationModel",
                principalColumn: "locationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesModel_StockLocationModel_empLocationlocationID",
                table: "EmployeesModel");

            migrationBuilder.DropIndex(
                name: "IX_EmployeesModel_empLocationlocationID",
                table: "EmployeesModel");

            migrationBuilder.DropColumn(
                name: "empLocationlocationID",
                table: "EmployeesModel");
        }
    }
}
