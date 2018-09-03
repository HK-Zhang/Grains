using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.EfSql.Migrations
{
    public partial class CarKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarComKeys",
                columns: table => new
                {
                    State = table.Column<string>(nullable: false),
                    LicensePlate = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarComKeys", x => new { x.State, x.LicensePlate });
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    LicensePlate = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.LicensePlate);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarComKeys");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
