using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.EfSql.Migrations
{
    public partial class Index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogFs",
                columns: table => new
                {
                    BlogFId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogFs", x => x.BlogFId);
                });

            migrationBuilder.CreateTable(
                name: "PersonB",
                columns: table => new
                {
                    PersonBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonB", x => x.PersonBId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogFs_Url",
                table: "BlogFs",
                column: "Url");

            migrationBuilder.CreateIndex(
                name: "IX_PersonB_FirstName_LastName",
                table: "PersonB",
                columns: new[] { "FirstName", "LastName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogFs");

            migrationBuilder.DropTable(
                name: "PersonB");
        }
    }
}
