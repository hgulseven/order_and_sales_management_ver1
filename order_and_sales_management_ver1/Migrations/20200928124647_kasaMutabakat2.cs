using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace order_and_sales_management_ver1.Migrations
{
    public partial class kasaMutabakat2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "expenditures",
                columns: table => new
                {
                    opDate = table.Column<DateTime>(nullable: false),
                    employeepersonelID = table.Column<int>(nullable: true),
                    aciklama = table.Column<string>(nullable: true),
                    amount = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenditures", x => x.opDate);
                    table.ForeignKey(
                        name: "FK_expenditures_employeesmodels_employeepersonelID",
                        column: x => x.employeepersonelID,
                        principalTable: "employeesmodels",
                        principalColumn: "personelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "kasamutabakat",
                columns: table => new
                {
                    opDate = table.Column<DateTime>(nullable: false),
                    typeOfMutabakat = table.Column<string>(nullable: false),
                    employeepersonelID = table.Column<int>(nullable: true),
                    changeMoney10KRS = table.Column<int>(nullable: false),
                    changeMoney25KRS = table.Column<int>(nullable: false),
                    change50KRS = table.Column<int>(nullable: false),
                    change1TL = table.Column<int>(nullable: false),
                    change5TL = table.Column<int>(nullable: false),
                    change10TL = table.Column<int>(nullable: false),
                    change20TL = table.Column<int>(nullable: false),
                    change50TL = table.Column<int>(nullable: false),
                    change100TL = table.Column<int>(nullable: false),
                    nakit10KRS = table.Column<int>(nullable: false),
                    nakit25KRS = table.Column<int>(nullable: false),
                    nakit50KRS = table.Column<int>(nullable: false),
                    nakit1TL = table.Column<int>(nullable: false),
                    nakit5TL = table.Column<int>(nullable: false),
                    nakit10TL = table.Column<int>(nullable: false),
                    nakit20TL = table.Column<int>(nullable: false),
                    nakit50TL = table.Column<int>(nullable: false),
                    nakit100TL = table.Column<int>(nullable: false),
                    nakit200TL = table.Column<int>(nullable: false),
                    diger10KRS = table.Column<int>(nullable: false),
                    diger25KRS = table.Column<int>(nullable: false),
                    diger50KRS = table.Column<int>(nullable: false),
                    diger1TL = table.Column<int>(nullable: false),
                    diger5TL = table.Column<int>(nullable: false),
                    diger10TL = table.Column<int>(nullable: false),
                    diger20TL = table.Column<int>(nullable: false),
                    diger50TL = table.Column<int>(nullable: false),
                    diger100TL = table.Column<int>(nullable: false),
                    diger200TL = table.Column<int>(nullable: false),
                    kerdiKartıToplam = table.Column<float>(nullable: false),
                    sistemNakitToplam = table.Column<float>(nullable: false),
                    sistemKrediKartıToplam = table.Column<float>(nullable: false),
                    sistemDigerToplam = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kasamutabakat", x => new { x.opDate, x.typeOfMutabakat });
                    table.ForeignKey(
                        name: "FK_kasamutabakat_employeesmodels_employeepersonelID",
                        column: x => x.employeepersonelID,
                        principalTable: "employeesmodels",
                        principalColumn: "personelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_expenditures_employeepersonelID",
                table: "expenditures",
                column: "employeepersonelID");

            migrationBuilder.CreateIndex(
                name: "IX_kasamutabakat_employeepersonelID",
                table: "kasamutabakat",
                column: "employeepersonelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "expenditures");

            migrationBuilder.DropTable(
                name: "kasamutabakat");
        }
    }
}
