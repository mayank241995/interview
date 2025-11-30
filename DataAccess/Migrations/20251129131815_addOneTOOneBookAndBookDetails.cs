using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addOneTOOneBookAndBookDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDBook",
                table: "BookDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookDetails_IDBook",
                table: "BookDetails",
                column: "IDBook",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetails_Books_IDBook",
                table: "BookDetails",
                column: "IDBook",
                principalTable: "Books",
                principalColumn: "IDBook",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDetails_Books_IDBook",
                table: "BookDetails");

            migrationBuilder.DropIndex(
                name: "IX_BookDetails_IDBook",
                table: "BookDetails");

            migrationBuilder.DropColumn(
                name: "IDBook",
                table: "BookDetails");
        }
    }
}
