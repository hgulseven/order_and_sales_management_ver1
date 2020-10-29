using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class validity3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DropForeignKey(
                name: "FK_orderdetailsmodels_OrderModel_orderID_validTom",
                table: "orderdetailsmodels");
       
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel");
       
            migrationBuilder.DropPrimaryKey(
                name: "PK_orderdetailsmodels",
                table: "orderdetailsmodels");
       
            migrationBuilder.DropIndex(
                name: "IX_orderdetailsmodels_orderID_validTom",
                table: "orderdetailsmodels");
           

            migrationBuilder.DropColumn(
                name: "validTom",
                table: "OrderModel");

            migrationBuilder.DropColumn(
                name: "validFromm",
                table: "OrderModel");

            migrationBuilder.DropColumn(
                name: "validTom",
                table: "orderdetailsmodels");

            migrationBuilder.DropColumn(
                name: "validFromm",
                table: "orderdetailsmodels");
            
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
            */
            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel",
                columns: new[] { "orderID", "validTo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderdetailsmodels",
                table: "orderdetailsmodels",
                columns: new[] { "orderID", "orderLineNo", "validTo" });

            migrationBuilder.CreateIndex(
                name: "IX_orderdetailsmodels_orderID_validTo",
                table: "orderdetailsmodels",
                columns: new[] { "orderID", "validTo" });

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetailsmodels_OrderModel_orderID_validTo",
                table: "orderdetailsmodels",
                columns: new[] { "orderID", "validTo" },
                principalTable: "OrderModel",
                principalColumns: new[] { "orderID", "validTo" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderdetailsmodels_OrderModel_orderID_validTo",
                table: "orderdetailsmodels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderdetailsmodels",
                table: "orderdetailsmodels");

            migrationBuilder.DropIndex(
                name: "IX_orderdetailsmodels_orderID_validTo",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "validTom",
                table: "OrderModel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "validFromm",
                table: "OrderModel",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "validTom",
                table: "orderdetailsmodels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "validFromm",
                table: "orderdetailsmodels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel",
                columns: new[] { "orderID", "validTom" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderdetailsmodels",
                table: "orderdetailsmodels",
                columns: new[] { "orderID", "orderLineNo", "validTom" });

            migrationBuilder.CreateIndex(
                name: "IX_orderdetailsmodels_orderID_validTom",
                table: "orderdetailsmodels",
                columns: new[] { "orderID", "validTom" });

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetailsmodels_OrderModel_orderID_validTom",
                table: "orderdetailsmodels",
                columns: new[] { "orderID", "validTom" },
                principalTable: "OrderModel",
                principalColumns: new[] { "orderID", "validTom" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
