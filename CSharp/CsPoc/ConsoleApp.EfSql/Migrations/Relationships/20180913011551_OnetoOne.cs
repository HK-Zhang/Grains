using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.EfSql.Migrations.Relationships
{
    public partial class OnetoOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogEs",
                columns: table => new
                {
                    BlogEId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogEs", x => x.BlogEId);
                });

            migrationBuilder.CreateTable(
                name: "BlogImageS",
                columns: table => new
                {
                    BlogImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<byte[]>(nullable: true),
                    Caption = table.Column<string>(nullable: true),
                    BlogForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogImageS", x => x.BlogImageId);
                    table.ForeignKey(
                        name: "FK_BlogImageS_BlogEs_BlogForeignKey",
                        column: x => x.BlogForeignKey,
                        principalTable: "BlogEs",
                        principalColumn: "BlogEId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogImageS_BlogForeignKey",
                table: "BlogImageS",
                column: "BlogForeignKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogImageS");

            migrationBuilder.DropTable(
                name: "BlogEs");
        }
    }
}
