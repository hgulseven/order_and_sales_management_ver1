using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class emplocation3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "employeeLocationID",
                table: "EmployeesModel",
                newName: "locationID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesModel_locationID",
                table: "EmployeesModel",
                column: "locationID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesModel_StockLocationModel_locationID",
                table: "EmployeesModel",
                column: "locationID",
                principalTable: "StockLocationModel",
                principalColumn: "locationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesModel_StockLocationModel_locationID",
                table: "EmployeesModel");

            migrationBuilder.DropIndex(
                name: "IX_EmployeesModel_locationID",
                table: "EmployeesModel");

            migrationBuilder.RenameColumn(
                name: "locationID",
                table: "EmployeesModel",
                newName: "employeeLocationID");

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
    }
}
