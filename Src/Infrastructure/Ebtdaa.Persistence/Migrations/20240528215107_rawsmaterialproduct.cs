using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class rawsmaterialproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRawMaterials_FactoryProducts_FactoryProductId",
                table: "ProductRawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_ProductRawMaterials_FactoryProductId",
                table: "ProductRawMaterials");

            migrationBuilder.DropColumn(
                name: "FactoryProductId",
                table: "ProductRawMaterials");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FactoryProductId",
                table: "ProductRawMaterials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductRawMaterials_FactoryProductId",
                table: "ProductRawMaterials",
                column: "FactoryProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRawMaterials_FactoryProducts_FactoryProductId",
                table: "ProductRawMaterials",
                column: "FactoryProductId",
                principalTable: "FactoryProducts",
                principalColumn: "Id");
        }
    }
}
