using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class FactoryProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRawMaterials_Products_ProductId",
                table: "ProductRawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_CustomItemRawMaterials_CustomItemRawMaterialId",
                table: "RawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_Factories_FactoryId",
                table: "RawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_RawMaterials_CustomItemRawMaterialId",
                table: "RawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_RawMaterials_FactoryId",
                table: "RawMaterials");

            migrationBuilder.DropColumn(
                name: "CustomItemRawMaterialId",
                table: "RawMaterials");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "RawMaterials");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductRawMaterials",
                newName: "FactoryProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRawMaterials_FactoryProducts_FactoryProductId",
                table: "ProductRawMaterials",
                column: "FactoryProductId",
                principalTable: "FactoryProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRawMaterials_FactoryProducts_FactoryProductId",
                table: "ProductRawMaterials");

            migrationBuilder.RenameColumn(
                name: "FactoryProductId",
                table: "ProductRawMaterials",
                newName: "ProductId");

            migrationBuilder.AddColumn<int>(
                name: "CustomItemRawMaterialId",
                table: "RawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "RawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_CustomItemRawMaterialId",
                table: "RawMaterials",
                column: "CustomItemRawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_FactoryId",
                table: "RawMaterials",
                column: "FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRawMaterials_Products_ProductId",
                table: "ProductRawMaterials",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_CustomItemRawMaterials_CustomItemRawMaterialId",
                table: "RawMaterials",
                column: "CustomItemRawMaterialId",
                principalTable: "CustomItemRawMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_Factories_FactoryId",
                table: "RawMaterials",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
