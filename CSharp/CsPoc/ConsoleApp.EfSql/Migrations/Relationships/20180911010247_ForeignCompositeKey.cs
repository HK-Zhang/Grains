using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.EfSql.Migrations.Relationships
{
    public partial class ForeignCompositeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarAs",
                columns: table => new
                {
                    State = table.Column<string>(nullable: false),
                    LicensePlate = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarAs", x => new { x.State, x.LicensePlate });
                });

            migrationBuilder.CreateTable(
                name: "RecordOfSales",
                columns: table => new
                {
                    RecordOfSaleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateSold = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    CarState = table.Column<string>(nullable: true),
                    CarLicensePlate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordOfSales", x => x.RecordOfSaleId);
                    table.ForeignKey(
                        name: "FK_RecordOfSales_CarAs_CarState_CarLicensePlate",
                        columns: x => new { x.CarState, x.CarLicensePlate },
                        principalTable: "CarAs",
                        principalColumns: new[] { "State", "LicensePlate" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecordOfSales_CarState_CarLicensePlate",
                table: "RecordOfSales",
                columns: new[] { "CarState", "CarLicensePlate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordOfSales");

            migrationBuilder.DropTable(
                name: "CarAs");
        }
    }
}
