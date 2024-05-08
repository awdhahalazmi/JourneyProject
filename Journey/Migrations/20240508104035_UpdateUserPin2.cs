using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Journey.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserPin2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

           

         
            migrationBuilder.AddColumn<int>(
                name: "PostsId",
                table: "Pins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pins_PostsId",
                table: "Pins",
                column: "PostsId");

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pins_Posts_PostsId",
                table: "Pins");

         

            

            migrationBuilder.AddColumn<int>(
                name: "PinId",
                table: "Posts",
                type: "int",
                nullable: true);

         
           
        }
    }
}
