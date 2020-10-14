using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class barcodeupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_PackagedProductDetailsModel_PackagedProductLineNo_PackedProd~",
                table: "PackagedProductDetailsModel");

            migrationBuilder.AddColumn<int>(
                name: "recStatus",
                table: "PackagedProductDetailsModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PackagedProductDetailsModel_PackagedProductLineNo_PackedProd~",
                table: "PackagedProductDetailsModel",
                columns: new[] { "PackagedProductLineNo", "PackedProductID", "recStatus" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_PackagedProductDetailsModel_PackagedProductLineNo_PackedProd~",
                table: "PackagedProductDetailsModel");

            migrationBuilder.DropColumn(
                name: "recStatus",
                table: "PackagedProductDetailsModel");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PackagedProductDetailsModel_PackagedProductLineNo_PackedProd~",
                table: "PackagedProductDetailsModel",
                columns: new[] { "PackagedProductLineNo", "PackedProductID" });
        }
    }
}
