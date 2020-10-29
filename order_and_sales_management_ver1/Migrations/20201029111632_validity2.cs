using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class validity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DropForeignKey(
                name: "FK_orderdetailsmodels_OrderModel_orderID",
                table: "orderdetailsmodels");
            
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel");
            
            migrationBuilder.DropPrimaryKey(
                name: "PK_orderdetailsmodels",
                table: "orderdetailsmodels");
            */
            migrationBuilder.AlterColumn<int>(
                name: "orderID",
                table: "OrderModel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "validTom",
                table: "OrderModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "validFromm",
                table: "OrderModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "validTom",
                table: "orderdetailsmodels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "validFromm",
                table: "orderdetailsmodels",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<int>(
                name: "orderID",
                table: "OrderModel",
                type: "int",
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
        }
    }
}
