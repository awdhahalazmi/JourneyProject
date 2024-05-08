using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Journey.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserPin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pins_Users_UsersId",
                table: "Pins");

            migrationBuilder.DropIndex(
                name: "IX_Pins_UsersId",
                table: "Pins");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Pins");

            migrationBuilder.CreateIndex(
                name: "IX_Pins_UserId",
                table: "Pins",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pins_Users_UserId",
                table: "Pins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pins_Users_UserId",
                table: "Pins");

            migrationBuilder.DropIndex(
                name: "IX_Pins_UserId",
                table: "Pins");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Pins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pins_UsersId",
                table: "Pins",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pins_Users_UsersId",
                table: "Pins",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
