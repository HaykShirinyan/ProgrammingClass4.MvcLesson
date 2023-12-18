using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingClass4.MvcLesson.Data.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartColors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCartColors",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartColors", x => new { x.ShoppingCartId, x.ColorId });
                    table.ForeignKey(
                        name: "FK_ShoppingCartColors_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartColors_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartColors_ColorId",
                table: "ShoppingCartColors",
                column: "ColorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartColors");
        }
    }
}
