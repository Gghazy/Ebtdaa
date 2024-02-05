using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class ActualRawMaterialUpatee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "UsedQuantity_KG",
                table: "ActualRawMaterials",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "IncreasedUsageReason",
                table: "ActualRawMaterials",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "CurrentStockQuantity_KG",
                table: "ActualRawMaterials",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "CurrentStockQuantity",
                table: "ActualRawMaterials",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "StockUnitId",
                table: "ActualRawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsageUnitId",
                table: "ActualRawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "UsedQuantity",
                table: "ActualRawMaterials",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentStockQuantity",
                table: "ActualRawMaterials");

            migrationBuilder.DropColumn(
                name: "StockUnitId",
                table: "ActualRawMaterials");

            migrationBuilder.DropColumn(
                name: "UsageUnitId",
                table: "ActualRawMaterials");

            migrationBuilder.DropColumn(
                name: "UsedQuantity",
                table: "ActualRawMaterials");

            migrationBuilder.AlterColumn<int>(
                name: "UsedQuantity_KG",
                table: "ActualRawMaterials",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "IncreasedUsageReason",
                table: "ActualRawMaterials",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentStockQuantity_KG",
                table: "ActualRawMaterials",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
