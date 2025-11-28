using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedBookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "IDBook", "ISBN", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "123-4567890123", 19.99000m, "Sample Book" },
                    { 2, "987-6543210987", 29.99500m, "Another Book" },
                    { 3, "111-2223334445", 39.99000m, "C# Programming" },
                    { 4, "555-6667778889", 49.99500m, "ASP.NET Core Guide" },
                    { 5, "999-0001112223", 59.99000m, "Entity Framework Core" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IDBook",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IDBook",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IDBook",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IDBook",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "IDBook",
                keyValue: 5);
        }
    }
}
