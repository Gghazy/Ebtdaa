using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class rawsmaterialproductnwq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRawMaterials",
                table: "ProductRawMaterials");

            

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRawMaterials",
                table: "ProductRawMaterials",
                columns: new[] { "ProductId", "rawMaterialId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRawMaterials_rawMaterialId",
                table: "ProductRawMaterials",
                column: "rawMaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRawMaterials",
                table: "ProductRawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_ProductRawMaterials_rawMaterialId",
                table: "ProductRawMaterials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRawMaterials",
                table: "ProductRawMaterials",
                column: "rawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRawMaterials_ProductId",
                table: "ProductRawMaterials",
                column: "ProductId");
        }
    }
}
