using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.EfSql.Migrations
{
    public partial class ConstructorReadOnlyProperty2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogLs",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    _id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogLs", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "PostLs",
                columns: table => new
                {
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    PostedOn = table.Column<DateTime>(nullable: false),
                    Blog_id = table.Column<int>(nullable: true),
                    _id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostLs", x => x._id);
                    table.ForeignKey(
                        name: "FK_PostLs_BlogLs_Blog_id",
                        column: x => x.Blog_id,
                        principalTable: "BlogLs",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostLs_Blog_id",
                table: "PostLs",
                column: "Blog_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostLs");

            migrationBuilder.DropTable(
                name: "BlogLs");
        }
    }
}
