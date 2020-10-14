using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class orderflowupdate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderdetailsmodels_OrderModel_orderID",
                table: "orderdetailsmodels");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_employeesmodels_orderOwner_personelID",
                table: "OrderModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderdetailsmodels",
                table: "orderdetailsmodels");

            migrationBuilder.RenameColumn(
                name: "orderOwner_personelID",
                table: "OrderModel",
                newName: "personelID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModel_orderOwner_personelID",
                table: "OrderModel",
                newName: "IX_OrderModel_personelID");

            migrationBuilder.AlterColumn<int>(
                name: "orderID",
                table: "OrderModel",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "validTo",
                table: "OrderModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "validFrom",
                table: "OrderModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "validTo",
                table: "orderdetailsmodels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "validFrom",
                table: "orderdetailsmodels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_OrderModel_orderID_validTo",
                table: "OrderModel",
                columns: new[] { "orderID", "validTo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel",
                columns: new[] { "validTo", "orderID" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_orderdetailsmodels_orderID_orderLineNo_validTo",
                table: "orderdetailsmodels",
                columns: new[] { "orderID", "orderLineNo", "validTo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderdetailsmodels",
                table: "orderdetailsmodels",
                columns: new[] { "validTo", "orderID", "orderLineNo" });

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetailsmodels_OrderModel_validTo_orderID",
                table: "orderdetailsmodels",
                columns: new[] { "validTo", "orderID" },
                principalTable: "OrderModel",
                principalColumns: new[] { "validTo", "orderID" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_employeesmodels_personelID",
                table: "OrderModel",
                column: "personelID",
                principalTable: "employeesmodels",
                principalColumn: "personelID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderdetailsmodels_OrderModel_validTo_orderID",
                table: "orderdetailsmodels");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_employeesmodels_personelID",
                table: "OrderModel");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_OrderModel_orderID_validTo",
                table: "OrderModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_orderdetailsmodels_orderID_orderLineNo_validTo",
                table: "orderdetailsmodels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderdetailsmodels",
                table: "orderdetailsmodels");

            migrationBuilder.DropColumn(
                name: "validTo",
                table: "OrderModel");

            migrationBuilder.DropColumn(
                name: "validFrom",
                table: "OrderModel");

            migrationBuilder.DropColumn(
                name: "validTo",
                table: "orderdetailsmodels");

            migrationBuilder.DropColumn(
                name: "validFrom",
                table: "orderdetailsmodels");

            migrationBuilder.RenameColumn(
                name: "personelID",
                table: "OrderModel",
                newName: "orderOwner_personelID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModel_personelID",
                table: "OrderModel",
                newName: "IX_OrderModel_orderOwner_personelID");

            migrationBuilder.AlterColumn<int>(
                name: "orderID",
                table: "OrderModel",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel",
                column: "orderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderdetailsmodels",
                table: "orderdetailsmodels",
                columns: new[] { "orderID", "orderLineNo" });

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetailsmodels_OrderModel_orderID",
                table: "orderdetailsmodels",
                column: "orderID",
                principalTable: "OrderModel",
                principalColumn: "orderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_employeesmodels_orderOwner_personelID",
                table: "OrderModel",
                column: "orderOwner_personelID",
                principalTable: "employeesmodels",
                principalColumn: "personelID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
