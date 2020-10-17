using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DropForeignKey(
                name: "FK_employeesmodels_stocklocationmodel_locationID",
                table: "employeesmodels");
            
            migrationBuilder.DropForeignKey(
                name: "FK_kasamutabakat_employeesmodels_personelID",
                table: "kasamutabakat");
            
            migrationBuilder.DropForeignKey(
                name: "FK_PackagedProductDetailsModel_productmodels_ProductID",
                table: "PackagedProductDetailsModel");
            
            migrationBuilder.DropForeignKey(
                name: "FK_salesmodels_employeesmodels_personelID",
                table: "salesmodels");
            
            migrationBuilder.DropForeignKey(
                name: "FK_salesmodels_productmodels_productID",
                table: "salesmodels");
            
            migrationBuilder.DropUniqueConstraint(
                name: "AK_TeraziScreenMapping_productID_teraziID",
                table: "TeraziScreenMapping");
            
            migrationBuilder.DropUniqueConstraint(
                name: "AK_stockitems_locationID_productID_productionLotID",
                table: "stockitems");
            
            migrationBuilder.DropIndex(
                name: "IX_salesmodels_personelID",
                table: "salesmodels");
            
            migrationBuilder.DropIndex(
                name: "IX_salesmodels_productID",
                table: "salesmodels");
            
            migrationBuilder.DropUniqueConstraint(
                name: "AK_PackagedProductDetailsModel_PackagedProductLineNo_PackedProd~",
                table: "PackagedProductDetailsModel");
            
            migrationBuilder.DropIndex(
                name: "IX_PackagedProductDetailsModel_ProductID",
                table: "PackagedProductDetailsModel");
            
            migrationBuilder.DropUniqueConstraint(
                name: "AK_kasamutabakat_locationID_mutabakatTimeStamp_typeOfMutabakat",
                table: "kasamutabakat");
            
            migrationBuilder.DropIndex(
                name: "IX_kasamutabakat_personelID",
                table: "kasamutabakat");
            
            migrationBuilder.DropUniqueConstraint(
                name: "AK_expenditures_locationID_opDate",
                table: "expenditures");
            
            migrationBuilder.DropIndex(
                name: "IX_employeesmodels_locationID",
                table: "employeesmodels");
            */
            migrationBuilder.AddColumn<int>(
                name: "ProductModelproductID",
                table: "salesmodels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "employeesmodelspersonelID",
                table: "salesmodels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductModelproductID",
                table: "PackagedProductDetailsModel",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "employeepersonelID",
                table: "kasamutabakat",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "empLocationlocationID",
                table: "employeesmodels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_stockitems_locationID",
                table: "stockitems",
                column: "locationID");

            migrationBuilder.CreateIndex(
                name: "IX_salesmodels_ProductModelproductID",
                table: "salesmodels",
                column: "ProductModelproductID");

            migrationBuilder.CreateIndex(
                name: "IX_salesmodels_employeesmodelspersonelID",
                table: "salesmodels",
                column: "employeesmodelspersonelID");

            migrationBuilder.CreateIndex(
                name: "IX_PackagedProductDetailsModel_ProductModelproductID",
                table: "PackagedProductDetailsModel",
                column: "ProductModelproductID");

            migrationBuilder.CreateIndex(
                name: "IX_kasamutabakat_employeepersonelID",
                table: "kasamutabakat",
                column: "employeepersonelID");

            migrationBuilder.CreateIndex(
                name: "IX_employeesmodels_empLocationlocationID",
                table: "employeesmodels",
                column: "empLocationlocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_employeesmodels_stocklocationmodel_empLocationlocationID",
                table: "employeesmodels",
                column: "empLocationlocationID",
                principalTable: "stocklocationmodel",
                principalColumn: "locationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_kasamutabakat_employeesmodels_employeepersonelID",
                table: "kasamutabakat",
                column: "employeepersonelID",
                principalTable: "employeesmodels",
                principalColumn: "personelID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PackagedProductDetailsModel_productmodels_ProductModelproduc~",
                table: "PackagedProductDetailsModel",
                column: "ProductModelproductID",
                principalTable: "productmodels",
                principalColumn: "productID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_salesmodels_productmodels_ProductModelproductID",
                table: "salesmodels",
                column: "ProductModelproductID",
                principalTable: "productmodels",
                principalColumn: "productID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_salesmodels_employeesmodels_employeesmodelspersonelID",
                table: "salesmodels",
                column: "employeesmodelspersonelID",
                principalTable: "employeesmodels",
                principalColumn: "personelID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeesmodels_stocklocationmodel_empLocationlocationID",
                table: "employeesmodels");

            migrationBuilder.DropForeignKey(
                name: "FK_kasamutabakat_employeesmodels_employeepersonelID",
                table: "kasamutabakat");

            migrationBuilder.DropForeignKey(
                name: "FK_PackagedProductDetailsModel_productmodels_ProductModelproduc~",
                table: "PackagedProductDetailsModel");

            migrationBuilder.DropForeignKey(
                name: "FK_salesmodels_productmodels_ProductModelproductID",
                table: "salesmodels");

            migrationBuilder.DropForeignKey(
                name: "FK_salesmodels_employeesmodels_employeesmodelspersonelID",
                table: "salesmodels");

            migrationBuilder.DropIndex(
                name: "IX_stockitems_locationID",
                table: "stockitems");

            migrationBuilder.DropIndex(
                name: "IX_salesmodels_ProductModelproductID",
                table: "salesmodels");

            migrationBuilder.DropIndex(
                name: "IX_salesmodels_employeesmodelspersonelID",
                table: "salesmodels");

            migrationBuilder.DropIndex(
                name: "IX_PackagedProductDetailsModel_ProductModelproductID",
                table: "PackagedProductDetailsModel");

            migrationBuilder.DropIndex(
                name: "IX_kasamutabakat_employeepersonelID",
                table: "kasamutabakat");

            migrationBuilder.DropIndex(
                name: "IX_employeesmodels_empLocationlocationID",
                table: "employeesmodels");

            migrationBuilder.DropColumn(
                name: "ProductModelproductID",
                table: "salesmodels");

            migrationBuilder.DropColumn(
                name: "employeesmodelspersonelID",
                table: "salesmodels");

            migrationBuilder.DropColumn(
                name: "ProductModelproductID",
                table: "PackagedProductDetailsModel");

            migrationBuilder.DropColumn(
                name: "employeepersonelID",
                table: "kasamutabakat");

            migrationBuilder.DropColumn(
                name: "empLocationlocationID",
                table: "employeesmodels");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TeraziScreenMapping_productID_teraziID",
                table: "TeraziScreenMapping",
                columns: new[] { "productID", "teraziID" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_stockitems_locationID_productID_productionLotID",
                table: "stockitems",
                columns: new[] { "locationID", "productID", "productionLotID" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PackagedProductDetailsModel_PackagedProductLineNo_PackedProd~",
                table: "PackagedProductDetailsModel",
                columns: new[] { "PackagedProductLineNo", "PackedProductID", "recDate", "recStatus" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_kasamutabakat_locationID_mutabakatTimeStamp_typeOfMutabakat",
                table: "kasamutabakat",
                columns: new[] { "locationID", "mutabakatTimeStamp", "typeOfMutabakat" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_expenditures_locationID_opDate",
                table: "expenditures",
                columns: new[] { "locationID", "opDate" });

            migrationBuilder.CreateIndex(
                name: "IX_salesmodels_personelID",
                table: "salesmodels",
                column: "personelID");

            migrationBuilder.CreateIndex(
                name: "IX_salesmodels_productID",
                table: "salesmodels",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_PackagedProductDetailsModel_ProductID",
                table: "PackagedProductDetailsModel",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_kasamutabakat_personelID",
                table: "kasamutabakat",
                column: "personelID");

            migrationBuilder.CreateIndex(
                name: "IX_employeesmodels_locationID",
                table: "employeesmodels",
                column: "locationID");

            migrationBuilder.AddForeignKey(
                name: "FK_employeesmodels_stocklocationmodel_locationID",
                table: "employeesmodels",
                column: "locationID",
                principalTable: "stocklocationmodel",
                principalColumn: "locationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kasamutabakat_employeesmodels_personelID",
                table: "kasamutabakat",
                column: "personelID",
                principalTable: "employeesmodels",
                principalColumn: "personelID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackagedProductDetailsModel_productmodels_ProductID",
                table: "PackagedProductDetailsModel",
                column: "ProductID",
                principalTable: "productmodels",
                principalColumn: "productID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_salesmodels_employeesmodels_personelID",
                table: "salesmodels",
                column: "personelID",
                principalTable: "employeesmodels",
                principalColumn: "personelID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_salesmodels_productmodels_productID",
                table: "salesmodels",
                column: "productID",
                principalTable: "productmodels",
                principalColumn: "productID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
