using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.EfSql.Migrations.Relationships
{
    public partial class Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogAs",
                columns: table => new
                {
                    BlogAId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogAs", x => x.BlogAId);
                });

            migrationBuilder.CreateTable(
                name: "PostAs",
                columns: table => new
                {
                    PostAId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    BlogAId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostAs", x => x.PostAId);
                    table.ForeignKey(
                        name: "FK_PostAs_BlogAs_BlogAId",
                        column: x => x.BlogAId,
                        principalTable: "BlogAs",
                        principalColumn: "BlogAId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostAs_BlogAId",
                table: "PostAs",
                column: "BlogAId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostAs");

            migrationBuilder.DropTable(
                name: "BlogAs");
        }
    }
}
