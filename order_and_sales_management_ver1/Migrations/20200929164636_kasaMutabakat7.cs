using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class kasaMutabakat7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kasamutabakat_employeesmodels_employeepersonelID",
                table: "kasamutabakat");

            migrationBuilder.DropIndex(
                name: "IX_kasamutabakat_employeepersonelID",
                table: "kasamutabakat");

            migrationBuilder.DropColumn(
                name: "employeepersonelID",
                table: "kasamutabakat");

            migrationBuilder.AddColumn<int>(
                name: "personelID",
                table: "kasamutabakat",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_kasamutabakat_personelID",
                table: "kasamutabakat",
                column: "personelID");

            migrationBuilder.AddForeignKey(
                name: "FK_kasamutabakat_employeesmodels_personelID",
                table: "kasamutabakat",
                column: "personelID",
                principalTable: "employeesmodels",
                principalColumn: "personelID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kasamutabakat_employeesmodels_personelID",
                table: "kasamutabakat");

            migrationBuilder.DropIndex(
                name: "IX_kasamutabakat_personelID",
                table: "kasamutabakat");

            migrationBuilder.DropColumn(
                name: "personelID",
                table: "kasamutabakat");

            migrationBuilder.AddColumn<int>(
                name: "employeepersonelID",
                table: "kasamutabakat",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_kasamutabakat_employeepersonelID",
                table: "kasamutabakat",
                column: "employeepersonelID");

            migrationBuilder.AddForeignKey(
                name: "FK_kasamutabakat_employeesmodels_employeepersonelID",
                table: "kasamutabakat",
                column: "employeepersonelID",
                principalTable: "employeesmodels",
                principalColumn: "personelID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
