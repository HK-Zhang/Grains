using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.EfSql.Migrations.Relationships
{
    public partial class CompositePrincipalKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarCs",
                columns: table => new
                {
                    CarCId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    State = table.Column<string>(nullable: false),
                    LicensePlate = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCs", x => x.CarCId);
                    table.UniqueConstraint("AK_CarCs_State_LicensePlate", x => new { x.State, x.LicensePlate });
                });

            migrationBuilder.CreateTable(
                name: "RecordOfSaleCs",
                columns: table => new
                {
                    RecordOfSaleCId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateSold = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    CarState = table.Column<string>(nullable: true),
                    CarLicensePlate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordOfSaleCs", x => x.RecordOfSaleCId);
                    table.ForeignKey(
                        name: "FK_RecordOfSaleCs_CarCs_CarState_CarLicensePlate",
                        columns: x => new { x.CarState, x.CarLicensePlate },
                        principalTable: "CarCs",
                        principalColumns: new[] { "State", "LicensePlate" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecordOfSaleCs_CarState_CarLicensePlate",
                table: "RecordOfSaleCs",
                columns: new[] { "CarState", "CarLicensePlate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordOfSaleCs");

            migrationBuilder.DropTable(
                name: "CarCs");
        }
    }
}
