using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.EfSql.Migrations.Relationships
{
    public partial class ForeignShadowKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogDs",
                columns: table => new
                {
                    BlogDId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogDs", x => x.BlogDId);
                });

            migrationBuilder.CreateTable(
                name: "PostDs",
                columns: table => new
                {
                    PostDId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    BlogForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostDs", x => x.PostDId);
                    table.ForeignKey(
                        name: "FK_PostDs_BlogDs_BlogForeignKey",
                        column: x => x.BlogForeignKey,
                        principalTable: "BlogDs",
                        principalColumn: "BlogDId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostDs_BlogForeignKey",
                table: "PostDs",
                column: "BlogForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostDs");

            migrationBuilder.DropTable(
                name: "BlogDs");
        }
    }
}
