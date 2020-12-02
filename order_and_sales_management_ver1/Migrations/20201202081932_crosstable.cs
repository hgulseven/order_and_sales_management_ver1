using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class crosstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrossTable",
                columns: table => new
                {
                    pname = table.Column<string>(maxLength: 255, nullable: false),
                    baseID = table.Column<int>(nullable: false),
                    packedID = table.Column<int>(nullable: false),
                    productID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrossTable", x => x.pname);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrossTable");
        }
    }
}
