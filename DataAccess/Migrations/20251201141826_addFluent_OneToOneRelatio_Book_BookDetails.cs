using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFluent_OneToOneRelatio_Book_BookDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDBook",
                table: "fluent_BookDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_fluent_BookDetail_IDBook",
                table: "fluent_BookDetail",
                column: "IDBook",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_fluent_BookDetail_fluent_Books_IDBook",
                table: "fluent_BookDetail",
                column: "IDBook",
                principalTable: "fluent_Books",
                principalColumn: "IDBook",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fluent_BookDetail_fluent_Books_IDBook",
                table: "fluent_BookDetail");

            migrationBuilder.DropIndex(
                name: "IX_fluent_BookDetail_IDBook",
                table: "fluent_BookDetail");

            migrationBuilder.DropColumn(
                name: "IDBook",
                table: "fluent_BookDetail");
        }
    }
}
