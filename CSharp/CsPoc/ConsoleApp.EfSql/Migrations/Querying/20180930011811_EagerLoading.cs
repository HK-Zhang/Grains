using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.EfSql.Migrations.Querying
{
    public partial class EagerLoading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    PictureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.PictureId);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ren",
                columns: table => new
                {
                    RenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhotoPictureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ren", x => x.RenId);
                    table.ForeignKey(
                        name: "FK_Ren_Picture_PhotoPictureId",
                        column: x => x.PhotoPictureId,
                        principalTable: "Picture",
                        principalColumn: "PictureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RenMen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    SchoolId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RenMen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RenMen_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QBlogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true),
                    OwnerRenId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QBlogs", x => x.BlogId);
                    table.ForeignKey(
                        name: "FK_QBlogs_Ren_OwnerRenId",
                        column: x => x.OwnerRenId,
                        principalTable: "Ren",
                        principalColumn: "RenId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QPost",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorRenId = table.Column<int>(nullable: true),
                    BlogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QPost", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_QPost_Ren_AuthorRenId",
                        column: x => x.AuthorRenId,
                        principalTable: "Ren",
                        principalColumn: "RenId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QPost_QBlogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "QBlogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PTag",
                columns: table => new
                {
                    PTagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PTag", x => x.PTagId);
                    table.ForeignKey(
                        name: "FK_PTag_QPost_PostId",
                        column: x => x.PostId,
                        principalTable: "QPost",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PTag_PostId",
                table: "PTag",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_QBlogs_OwnerRenId",
                table: "QBlogs",
                column: "OwnerRenId");

            migrationBuilder.CreateIndex(
                name: "IX_QPost_AuthorRenId",
                table: "QPost",
                column: "AuthorRenId");

            migrationBuilder.CreateIndex(
                name: "IX_QPost_BlogId",
                table: "QPost",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Ren_PhotoPictureId",
                table: "Ren",
                column: "PhotoPictureId");

            migrationBuilder.CreateIndex(
                name: "IX_RenMen_SchoolId",
                table: "RenMen",
                column: "SchoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PTag");

            migrationBuilder.DropTable(
                name: "RenMen");

            migrationBuilder.DropTable(
                name: "QPost");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "QBlogs");

            migrationBuilder.DropTable(
                name: "Ren");

            migrationBuilder.DropTable(
                name: "Picture");
        }
    }
}
