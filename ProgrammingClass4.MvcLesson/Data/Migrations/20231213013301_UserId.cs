using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingClass4.MvcLesson.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "shoppingCarts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCarts_UserId",
                table: "shoppingCarts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_AspNetUsers_UserId",
                table: "shoppingCarts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_AspNetUsers_UserId",
                table: "shoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_shoppingCarts_UserId",
                table: "shoppingCarts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "shoppingCarts");
        }
    }
}
