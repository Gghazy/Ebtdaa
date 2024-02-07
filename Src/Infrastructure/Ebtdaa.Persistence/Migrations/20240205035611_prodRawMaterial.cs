using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class prodRawMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_Products_ProductId",
                table: "RawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_RawMaterials_ProductId",
                table: "RawMaterials");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "RawMaterials");

            migrationBuilder.AddColumn<string>(
                name: "Sign",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            //migrationBuilder.CreateTable(
            //    name: "ProductRawMaterial",
            //    columns: table => new
            //    {
            //        ProductsId = table.Column<int>(type: "int", nullable: false),
            //        RawMaterialsId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductRawMaterial", x => new { x.ProductsId, x.RawMaterialsId });
            //        table.ForeignKey(
            //            name: "FK_ProductRawMaterial_Products_ProductsId",
            //            column: x => x.ProductsId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProductRawMaterial_RawMaterials_RawMaterialsId",
            //            column: x => x.RawMaterialsId,
            //            principalTable: "RawMaterials",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductRawMaterials",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductId = table.Column<int>(type: "int", nullable: false),
            //        rawMaterialId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductRawMaterials", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ProductRawMaterials_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProductRawMaterials_RawMaterials_rawMaterialId",
            //            column: x => x.rawMaterialId,
            //            principalTable: "RawMaterials",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductRawMaterial_RawMaterialsId",
            //    table: "ProductRawMaterial",
            //    column: "RawMaterialsId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductRawMaterials_ProductId",
            //    table: "ProductRawMaterials",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductRawMaterials_rawMaterialId",
            //    table: "ProductRawMaterials",
            //    column: "rawMaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductRawMaterial");

            migrationBuilder.DropTable(
                name: "ProductRawMaterials");

            migrationBuilder.DropColumn(
                name: "Sign",
                table: "Units");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "RawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_ProductId",
                table: "RawMaterials",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_Products_ProductId",
                table: "RawMaterials",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
