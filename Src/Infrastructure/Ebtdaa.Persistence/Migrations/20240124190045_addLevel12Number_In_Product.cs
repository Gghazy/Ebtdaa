using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class addLevel12Number_In_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Products_ProductId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_ProductId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Units");

            migrationBuilder.AddColumn<string>(
                name: "Level12Number",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitId",
                table: "Products",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Units_UnitId",
                table: "Products",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Units_UnitId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UnitId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Level12Number",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_ProductId",
                table: "Units",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Products_ProductId",
                table: "Units",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
