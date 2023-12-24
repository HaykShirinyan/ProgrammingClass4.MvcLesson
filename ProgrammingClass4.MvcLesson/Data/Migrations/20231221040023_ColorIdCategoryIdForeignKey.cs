using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingClass4.MvcLesson.Data.Migrations
{
    /// <inheritdoc />
    public partial class ColorIdCategoryIdForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductShoppingCarts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "ProductShoppingCarts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductShoppingCarts_CategoryId",
                table: "ProductShoppingCarts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShoppingCarts_ColorId",
                table: "ProductShoppingCarts",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShoppingCarts_Categories_CategoryId",
                table: "ProductShoppingCarts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShoppingCarts_Colors_ColorId",
                table: "ProductShoppingCarts",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductShoppingCarts_Categories_CategoryId",
                table: "ProductShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductShoppingCarts_Colors_ColorId",
                table: "ProductShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ProductShoppingCarts_CategoryId",
                table: "ProductShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ProductShoppingCarts_ColorId",
                table: "ProductShoppingCarts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductShoppingCarts");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "ProductShoppingCarts");
        }
    }
}
