using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class customItemRawMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomItemRawMaterialId",
                table: "RawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemNumber",
                table: "RawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "RawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CustomItemRawMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomItemRawMaterials", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_CustomItemRawMaterialId",
                table: "RawMaterials",
                column: "CustomItemRawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_PeriodId",
                table: "RawMaterials",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_CustomItemRawMaterials_CustomItemRawMaterialId",
                table: "RawMaterials",
                column: "CustomItemRawMaterialId",
                principalTable: "CustomItemRawMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_Periods_PeriodId",
                table: "RawMaterials",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_CustomItemRawMaterials_CustomItemRawMaterialId",
                table: "RawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_Periods_PeriodId",
                table: "RawMaterials");

            migrationBuilder.DropTable(
                name: "CustomItemRawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_RawMaterials_CustomItemRawMaterialId",
                table: "RawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_RawMaterials_PeriodId",
                table: "RawMaterials");

            migrationBuilder.DropColumn(
                name: "CustomItemRawMaterialId",
                table: "RawMaterials");

            migrationBuilder.DropColumn(
                name: "ItemNumber",
                table: "RawMaterials");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "RawMaterials");
        }
    }
}
