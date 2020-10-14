using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class kasaMutabakat8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_kasamutabakat",
                table: "kasamutabakat");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_kasamutabakat_locationID_opDate_typeOfMutabakat",
                table: "kasamutabakat");

            migrationBuilder.RenameColumn(
                name: "opDate",
                table: "kasamutabakat",
                newName: "mutabakatTimeStamp");

            migrationBuilder.AddColumn<DateTime>(
                name: "mutabakatDate",
                table: "kasamutabakat",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_kasamutabakat",
                table: "kasamutabakat",
                columns: new[] { "mutabakatDate", "typeOfMutabakat" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_kasamutabakat_locationID_mutabakatDate_typeOfMutabakat",
                table: "kasamutabakat",
                columns: new[] { "locationID", "mutabakatDate", "typeOfMutabakat" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_kasamutabakat",
                table: "kasamutabakat");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_kasamutabakat_locationID_mutabakatDate_typeOfMutabakat",
                table: "kasamutabakat");

            migrationBuilder.DropColumn(
                name: "mutabakatDate",
                table: "kasamutabakat");

            migrationBuilder.RenameColumn(
                name: "mutabakatTimeStamp",
                table: "kasamutabakat",
                newName: "opDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_kasamutabakat",
                table: "kasamutabakat",
                columns: new[] { "opDate", "typeOfMutabakat" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_kasamutabakat_locationID_opDate_typeOfMutabakat",
                table: "kasamutabakat",
                columns: new[] { "locationID", "opDate", "typeOfMutabakat" });
        }
    }
}
