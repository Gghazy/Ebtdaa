using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class rawMat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RawMaterialName",
                table: "RawMaterials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "AcuKilograms_Per_Unit",
                table: "ActualProductionAndCapacities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "AcuProductName",
                table: "ActualProductionAndCapacities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RawMaterialName",
                table: "RawMaterials");

            migrationBuilder.DropColumn(
                name: "AcuKilograms_Per_Unit",
                table: "ActualProductionAndCapacities");

            migrationBuilder.DropColumn(
                name: "AcuProductName",
                table: "ActualProductionAndCapacities");
        }
    }
}
