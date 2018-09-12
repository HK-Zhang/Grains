using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.EfSql.Migrations.Relationships
{
    public partial class PrincipalKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarBs",
                columns: table => new
                {
                    CarBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LicensePlate = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBs", x => x.CarBId);
                    table.UniqueConstraint("AK_CarBs_LicensePlate", x => x.LicensePlate);
                });

            migrationBuilder.CreateTable(
                name: "RecordOfSaleBs",
                columns: table => new
                {
                    RecordOfSaleBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateSold = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    CarLicensePlate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordOfSaleBs", x => x.RecordOfSaleBId);
                    table.ForeignKey(
                        name: "FK_RecordOfSaleBs_CarBs_CarLicensePlate",
                        column: x => x.CarLicensePlate,
                        principalTable: "CarBs",
                        principalColumn: "LicensePlate",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecordOfSaleBs_CarLicensePlate",
                table: "RecordOfSaleBs",
                column: "CarLicensePlate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordOfSaleBs");

            migrationBuilder.DropTable(
                name: "CarBs");
        }
    }
}
