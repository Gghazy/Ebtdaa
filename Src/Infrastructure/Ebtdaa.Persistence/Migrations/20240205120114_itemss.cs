using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class itemss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ProductRawMaterial");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductRawMaterial",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    RawMaterialsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRawMaterial", x => new { x.ProductsId, x.RawMaterialsId });
                    table.ForeignKey(
                        name: "FK_ProductRawMaterial_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductRawMaterial_RawMaterials_RawMaterialsId",
                        column: x => x.RawMaterialsId,
                        principalTable: "RawMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRawMaterial_RawMaterialsId",
                table: "ProductRawMaterial",
                column: "RawMaterialsId");
        }
    }
}
