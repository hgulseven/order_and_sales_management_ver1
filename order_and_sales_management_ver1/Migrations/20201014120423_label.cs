using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class label : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "labelmodels",
                columns: table => new
                {
                    productID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    productName = table.Column<string>(nullable: true),
                    productAmount = table.Column<string>(nullable: true),
                    productContents = table.Column<string>(nullable: true),
                    productLawStr = table.Column<string>(nullable: true),
                    productLotNo = table.Column<string>(nullable: true),
                    productBarcodID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labelmodels", x => x.productID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "labelmodels");
        }
    }
}
