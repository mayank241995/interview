using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class manyTOManyRelation_manual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.CreateTable(
                name: "BookAuthorMap",
                columns: table => new
                {
                    IDBook = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthorMap", x => new { x.Author_Id, x.IDBook });
                    table.ForeignKey(
                        name: "FK_BookAuthorMap_Authors_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "Authors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthorMap_Books_IDBook",
                        column: x => x.IDBook,
                        principalTable: "Books",
                        principalColumn: "IDBook",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorMap_IDBook",
                table: "BookAuthorMap",
                column: "IDBook");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthorMap");

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsAuthor_Id = table.Column<int>(type: "int", nullable: false),
                    BooksIDBook = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsAuthor_Id, x.BooksIDBook });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_AuthorsAuthor_Id",
                        column: x => x.AuthorsAuthor_Id,
                        principalTable: "Authors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BooksIDBook",
                        column: x => x.BooksIDBook,
                        principalTable: "Books",
                        principalColumn: "IDBook",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksIDBook",
                table: "AuthorBook",
                column: "BooksIDBook");
        }
    }
}
