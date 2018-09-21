using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.EfSql.Migrations
{
    public partial class QueryType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogMId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BlogMs",
                columns: table => new
                {
                    BlogMId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogMs", x => x.BlogMId);
                });

            migrationBuilder.CreateTable(
                name: "PostMs",
                columns: table => new
                {
                    PostMId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    BlogMId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostMs", x => x.PostMId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogMId",
                table: "Posts",
                column: "BlogMId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_BlogMs_BlogMId",
                table: "Posts",
                column: "BlogMId",
                principalTable: "BlogMs",
                principalColumn: "BlogMId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_BlogMs_BlogMId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "BlogMs");

            migrationBuilder.DropTable(
                name: "PostMs");

            migrationBuilder.DropIndex(
                name: "IX_Posts_BlogMId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "BlogMId",
                table: "Posts");
        }
    }
}
