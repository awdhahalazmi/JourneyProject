using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Journey.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCountry1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryName" },
                values: new object[] { 1, "value" });
        }
    }
}
