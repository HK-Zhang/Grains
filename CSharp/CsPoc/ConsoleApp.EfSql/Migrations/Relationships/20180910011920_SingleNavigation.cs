using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.EfSql.Migrations.Relationships
{
    public partial class SingleNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogB",
                columns: table => new
                {
                    BlogBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogB", x => x.BlogBId);
                });

            migrationBuilder.CreateTable(
                name: "PostBs",
                columns: table => new
                {
                    PostBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    BlogBId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostBs", x => x.PostBId);
                    table.ForeignKey(
                        name: "FK_PostBs_BlogB_BlogBId",
                        column: x => x.BlogBId,
                        principalTable: "BlogB",
                        principalColumn: "BlogBId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostBs_BlogBId",
                table: "PostBs",
                column: "BlogBId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostBs");

            migrationBuilder.DropTable(
                name: "BlogB");
        }
    }
}
