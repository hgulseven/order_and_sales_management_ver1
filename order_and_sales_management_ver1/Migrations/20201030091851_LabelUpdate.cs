using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class LabelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "alerji",
                table: "labelmodels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mensei",
                table: "labelmodels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "alerji",
                table: "labelmodels");

            migrationBuilder.DropColumn(
                name: "mensei",
                table: "labelmodels");
        }
    }
}
