using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class Updatee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRawMaterial_Products_ProductId",
                table: "ProductRawMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRawMaterial_RawMaterials_rawMaterialId",
                table: "ProductRawMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRawMaterial",
                table: "ProductRawMaterial");

            migrationBuilder.RenameTable(
                name: "ProductRawMaterial",
                newName: "ProductRawMaterials");

            migrationBuilder.RenameIndex(
                name: "IX_ProductRawMaterial_rawMaterialId",
                table: "ProductRawMaterials",
                newName: "IX_ProductRawMaterials_rawMaterialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRawMaterials",
                table: "ProductRawMaterials",
                columns: new[] { "ProductId", "rawMaterialId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRawMaterials_Products_ProductId",
                table: "ProductRawMaterials",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRawMaterials_RawMaterials_rawMaterialId",
                table: "ProductRawMaterials",
                column: "rawMaterialId",
                principalTable: "RawMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRawMaterials_Products_ProductId",
                table: "ProductRawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRawMaterials_RawMaterials_rawMaterialId",
                table: "ProductRawMaterials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRawMaterials",
                table: "ProductRawMaterials");

            migrationBuilder.RenameTable(
                name: "ProductRawMaterials",
                newName: "ProductRawMaterial");

            migrationBuilder.RenameIndex(
                name: "IX_ProductRawMaterials_rawMaterialId",
                table: "ProductRawMaterial",
                newName: "IX_ProductRawMaterial_rawMaterialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRawMaterial",
                table: "ProductRawMaterial",
                columns: new[] { "ProductId", "rawMaterialId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRawMaterial_Products_ProductId",
                table: "ProductRawMaterial",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRawMaterial_RawMaterials_rawMaterialId",
                table: "ProductRawMaterial",
                column: "rawMaterialId",
                principalTable: "RawMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
