using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammingClass4.MvcLesson.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductMeasureId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeasureId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MeasureId",
                table: "Products",
                column: "MeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UnitOfMeasures_MeasureId",
                table: "Products",
                column: "MeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UnitOfMeasures_MeasureId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MeasureId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MeasureId",
                table: "Products");
        }
    }
}
