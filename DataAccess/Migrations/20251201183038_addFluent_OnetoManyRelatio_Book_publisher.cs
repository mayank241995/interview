using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFluent_OnetoManyRelatio_Book_publisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_Id",
                table: "fluent_Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_fluent_Books_Publisher_Id",
                table: "fluent_Books",
                column: "Publisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_fluent_Books_fluent_Publishers_Publisher_Id",
                table: "fluent_Books",
                column: "Publisher_Id",
                principalTable: "fluent_Publishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fluent_Books_fluent_Publishers_Publisher_Id",
                table: "fluent_Books");

            migrationBuilder.DropIndex(
                name: "IX_fluent_Books_Publisher_Id",
                table: "fluent_Books");

            migrationBuilder.DropColumn(
                name: "Publisher_Id",
                table: "fluent_Books");
        }
    }
}
