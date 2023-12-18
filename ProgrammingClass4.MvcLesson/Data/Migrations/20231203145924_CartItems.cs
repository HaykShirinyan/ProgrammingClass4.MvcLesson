using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingClass4.MvcLesson.Data.Migrations
{
    /// <inheritdoc />
    public partial class CartItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Colors_ColorId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Sizes_SizeId",
                table: "CartItems");

            migrationBuilder.AlterColumn<int>(
                name: "SizeId",
                table: "CartItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "CartItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Colors_ColorId",
                table: "CartItems",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Sizes_SizeId",
                table: "CartItems",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Colors_ColorId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Sizes_SizeId",
                table: "CartItems");

            migrationBuilder.AlterColumn<int>(
                name: "SizeId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Colors_ColorId",
                table: "CartItems",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Sizes_SizeId",
                table: "CartItems",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
