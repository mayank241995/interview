using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addOneTOManyBookAndPublishers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_Id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "IDBook",
                keyValue: 1,
                column: "Publisher_Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "IDBook",
                keyValue: 2,
                column: "Publisher_Id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "IDBook",
                keyValue: 3,
                column: "Publisher_Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "IDBook",
                keyValue: 4,
                column: "Publisher_Id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "IDBook",
                keyValue: 5,
                column: "Publisher_Id",
                value: 3);

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Publisher_Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Chicago", "pub 1 jimmy" },
                    { 2, "New York", "pub 2 jhon" },
                    { 3, "New York", "pub 2 jhon" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Publisher_Id",
                table: "Books",
                column: "Publisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_Publisher_Id",
                table: "Books",
                column: "Publisher_Id",
                principalTable: "Publishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_Publisher_Id",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Publisher_Id",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Publisher_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Publisher_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Publisher_Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Publisher_Id",
                table: "Books");
        }
    }
}
