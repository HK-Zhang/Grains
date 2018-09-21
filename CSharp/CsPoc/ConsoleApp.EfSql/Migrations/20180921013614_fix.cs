using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.EfSql.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_BlogMs_BlogMId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_BlogMId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "BlogMId",
                table: "Posts");

            migrationBuilder.CreateIndex(
                name: "IX_PostMs_BlogMId",
                table: "PostMs",
                column: "BlogMId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostMs_BlogMs_BlogMId",
                table: "PostMs",
                column: "BlogMId",
                principalTable: "BlogMs",
                principalColumn: "BlogMId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostMs_BlogMs_BlogMId",
                table: "PostMs");

            migrationBuilder.DropIndex(
                name: "IX_PostMs_BlogMId",
                table: "PostMs");

            migrationBuilder.AddColumn<int>(
                name: "BlogMId",
                table: "Posts",
                nullable: true);

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
    }
}
