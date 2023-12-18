using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingClass4.MvcLesson.Data.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartSizes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCartSizes",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartSizes", x => new { x.ShoppingCartId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_ShoppingCartSizes_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartSizes_SizeId",
                table: "ShoppingCartSizes",
                column: "SizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartSizes");
        }
    }
}
