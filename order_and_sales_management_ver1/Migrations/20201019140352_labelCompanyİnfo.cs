using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class labelCompanyİnfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "companyInfo",
                table: "labelmodels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "companyInfo",
                table: "labelmodels");
        }
    }
}
