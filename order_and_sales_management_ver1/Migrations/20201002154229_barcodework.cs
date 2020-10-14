using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class barcodework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_packagedproductdetailsmodels_productmodels_ProductID",
                table: "packagedproductdetailsmodels");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_packagedproductdetailsmodels_PackagedProductLineNo_PackedPro~",
                table: "packagedproductdetailsmodels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_packagedproductdetailsmodels",
                table: "packagedproductdetailsmodels");

            migrationBuilder.RenameTable(
                name: "packagedproductdetailsmodels",
                newName: "PackagedProductDetailsModel");

            migrationBuilder.RenameIndex(
                name: "IX_packagedproductdetailsmodels_ProductID",
                table: "PackagedProductDetailsModel",
                newName: "IX_PackagedProductDetailsModel_ProductID");

            migrationBuilder.AddColumn<string>(
                name: "productBarcodeID",
                table: "salesmodels",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PackedProductID",
                table: "PackagedProductDetailsModel",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PackagedProductDetailsModel_PackagedProductLineNo_PackedProd~",
                table: "PackagedProductDetailsModel",
                columns: new[] { "PackagedProductLineNo", "PackedProductID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackagedProductDetailsModel",
                table: "PackagedProductDetailsModel",
                columns: new[] { "PackedProductID", "PackagedProductLineNo" });

            migrationBuilder.CreateTable(
                name: "packagedproductsbarcodes",
                columns: table => new
                {
                    barcodeID = table.Column<string>(maxLength: 13, nullable: false),
                    recStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packagedproductsbarcodes", x => x.barcodeID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PackagedProductDetailsModel_productmodels_ProductID",
                table: "PackagedProductDetailsModel",
                column: "ProductID",
                principalTable: "productmodels",
                principalColumn: "productID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackagedProductDetailsModel_productmodels_ProductID",
                table: "PackagedProductDetailsModel");

            migrationBuilder.DropTable(
                name: "packagedproductsbarcodes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_PackagedProductDetailsModel_PackagedProductLineNo_PackedProd~",
                table: "PackagedProductDetailsModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackagedProductDetailsModel",
                table: "PackagedProductDetailsModel");

            migrationBuilder.DropColumn(
                name: "productBarcodeID",
                table: "salesmodels");

            migrationBuilder.RenameTable(
                name: "PackagedProductDetailsModel",
                newName: "packagedproductdetailsmodels");

            migrationBuilder.RenameIndex(
                name: "IX_PackagedProductDetailsModel_ProductID",
                table: "packagedproductdetailsmodels",
                newName: "IX_packagedproductdetailsmodels_ProductID");

            migrationBuilder.AlterColumn<int>(
                name: "PackedProductID",
                table: "packagedproductdetailsmodels",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 13);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_packagedproductdetailsmodels_PackagedProductLineNo_PackedPro~",
                table: "packagedproductdetailsmodels",
                columns: new[] { "PackagedProductLineNo", "PackedProductID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_packagedproductdetailsmodels",
                table: "packagedproductdetailsmodels",
                columns: new[] { "PackedProductID", "PackagedProductLineNo" });

            migrationBuilder.AddForeignKey(
                name: "FK_packagedproductdetailsmodels_productmodels_ProductID",
                table: "packagedproductdetailsmodels",
                column: "ProductID",
                principalTable: "productmodels",
                principalColumn: "productID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
