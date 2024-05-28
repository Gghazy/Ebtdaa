using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class productrawmaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRawMaterials_FactoryProducts_FactoryProductId",
                table: "ProductRawMaterials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRawMaterials",
                table: "ProductRawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_ProductRawMaterials_rawMaterialId",
                table: "ProductRawMaterials");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryProductId",
                table: "ProductRawMaterials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductRawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRawMaterials",
                table: "ProductRawMaterials",
                column: "rawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRawMaterials_FactoryProductId",
                table: "ProductRawMaterials",
                column: "FactoryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRawMaterials_ProductId",
                table: "ProductRawMaterials",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRawMaterials_FactoryProducts_FactoryProductId",
                table: "ProductRawMaterials",
                column: "FactoryProductId",
                principalTable: "FactoryProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRawMaterials_Products_ProductId",
                table: "ProductRawMaterials",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRawMaterials_FactoryProducts_FactoryProductId",
                table: "ProductRawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRawMaterials_Products_ProductId",
                table: "ProductRawMaterials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRawMaterials",
                table: "ProductRawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_ProductRawMaterials_FactoryProductId",
                table: "ProductRawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_ProductRawMaterials_ProductId",
                table: "ProductRawMaterials");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductRawMaterials");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryProductId",
                table: "ProductRawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRawMaterials",
                table: "ProductRawMaterials",
                columns: new[] { "FactoryProductId", "rawMaterialId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRawMaterials_rawMaterialId",
                table: "ProductRawMaterials",
                column: "rawMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRawMaterials_FactoryProducts_FactoryProductId",
                table: "ProductRawMaterials",
                column: "FactoryProductId",
                principalTable: "FactoryProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
