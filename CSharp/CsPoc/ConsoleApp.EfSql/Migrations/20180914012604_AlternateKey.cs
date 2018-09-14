using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.EfSql.Migrations
{
    public partial class AlternateKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarDs",
                columns: table => new
                {
                    CarDId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LicensePlate = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDs", x => x.CarDId);
                    table.UniqueConstraint("AK_CarDs_LicensePlate", x => x.LicensePlate);
                });

            migrationBuilder.CreateTable(
                name: "CarEs",
                columns: table => new
                {
                    CarEId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    State = table.Column<string>(nullable: false),
                    LicensePlate = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarEs", x => x.CarEId);
                    table.UniqueConstraint("AK_CarEs_State_LicensePlate", x => new { x.State, x.LicensePlate });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarDs");

            migrationBuilder.DropTable(
                name: "CarEs");
        }
    }
}
