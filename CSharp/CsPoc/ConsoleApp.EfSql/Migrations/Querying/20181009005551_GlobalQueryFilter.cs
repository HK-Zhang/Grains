using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.EfSql.Migrations.Querying
{
    public partial class GlobalQueryFilter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogVs",
                columns: table => new
                {
                    BlogVId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    TenantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogVs", x => x.BlogVId);
                });

            migrationBuilder.CreateTable(
                name: "PostV",
                columns: table => new
                {
                    PostVId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    BlogVId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostV", x => x.PostVId);
                    table.ForeignKey(
                        name: "FK_PostV_BlogVs_BlogVId",
                        column: x => x.BlogVId,
                        principalTable: "BlogVs",
                        principalColumn: "BlogVId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostV_BlogVId",
                table: "PostV",
                column: "BlogVId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostV");

            migrationBuilder.DropTable(
                name: "BlogVs");
        }
    }
}
