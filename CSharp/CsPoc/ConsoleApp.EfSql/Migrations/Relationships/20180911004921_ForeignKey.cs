using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.EfSql.Migrations.Relationships
{
    public partial class ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogCs",
                columns: table => new
                {
                    BlogCId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCs", x => x.BlogCId);
                });

            migrationBuilder.CreateTable(
                name: "PostCs",
                columns: table => new
                {
                    PostCId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    BlogForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCs", x => x.PostCId);
                    table.ForeignKey(
                        name: "FK_PostCs_BlogCs_BlogForeignKey",
                        column: x => x.BlogForeignKey,
                        principalTable: "BlogCs",
                        principalColumn: "BlogCId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostCs_BlogForeignKey",
                table: "PostCs",
                column: "BlogForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostCs");

            migrationBuilder.DropTable(
                name: "BlogCs");
        }
    }
}
