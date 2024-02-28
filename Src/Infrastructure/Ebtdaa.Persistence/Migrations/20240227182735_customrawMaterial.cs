using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class customrawMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomItemRawMaterialId",
                table: "RawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_CustomItemRawMaterialId",
                table: "RawMaterials",
                column: "CustomItemRawMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_CustomItemRawMaterials_CustomItemRawMaterialId",
                table: "RawMaterials",
                column: "CustomItemRawMaterialId",
                principalTable: "CustomItemRawMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_CustomItemRawMaterials_CustomItemRawMaterialId",
                table: "RawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_RawMaterials_CustomItemRawMaterialId",
                table: "RawMaterials");

            migrationBuilder.DropColumn(
                name: "CustomItemRawMaterialId",
                table: "RawMaterials");
        }
    }
}
