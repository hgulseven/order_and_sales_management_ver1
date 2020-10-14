using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class barcodeupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_PackagedProductDetailsModel_PackagedProductLineNo_PackedProd~",
                table: "PackagedProductDetailsModel");

            migrationBuilder.AddColumn<DateTime>(
                name: "recDate",
                table: "PackagedProductDetailsModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PackagedProductDetailsModel_PackagedProductLineNo_PackedProd~",
                table: "PackagedProductDetailsModel",
                columns: new[] { "PackagedProductLineNo", "PackedProductID", "recDate", "recStatus" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_PackagedProductDetailsModel_PackagedProductLineNo_PackedProd~",
                table: "PackagedProductDetailsModel");

            migrationBuilder.DropColumn(
                name: "recDate",
                table: "PackagedProductDetailsModel");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PackagedProductDetailsModel_PackagedProductLineNo_PackedProd~",
                table: "PackagedProductDetailsModel",
                columns: new[] { "PackagedProductLineNo", "PackedProductID", "recStatus" });
        }
    }
}
