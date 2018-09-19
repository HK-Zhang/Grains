using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.EfSql.Migrations
{
    public partial class Constructor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogJs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogJs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostJs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    PostedOn = table.Column<DateTime>(nullable: false),
                    BlogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostJs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostJs_BlogJs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "BlogJs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "BlogId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "BlogId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_PostJs_BlogId",
                table: "PostJs",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostJs");

            migrationBuilder.DropTable(
                name: "BlogJs");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "BlogId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "BlogId",
                value: 1);
        }
    }
}
