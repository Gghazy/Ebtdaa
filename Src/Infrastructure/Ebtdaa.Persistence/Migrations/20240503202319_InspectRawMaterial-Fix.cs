using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class InspectRawMaterialFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsClearImage",
                table: "InspectorRawMaterials",
                newName: "IsPaperClear");

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "InspectorRawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaperId",
                table: "InspectorRawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CorrectPaperId",
                table: "InspectorRawMaterials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CorrectPhotoId",
                table: "InspectorRawMaterials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsImageClear",
                table: "InspectorRawMaterials",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectPaperId",
                table: "InspectorRawMaterials");

            migrationBuilder.DropColumn(
                name: "CorrectPhotoId",
                table: "InspectorRawMaterials");

            migrationBuilder.DropColumn(
                name: "IsImageClear",
                table: "InspectorRawMaterials");

            migrationBuilder.RenameColumn(
                name: "IsPaperClear",
                table: "InspectorRawMaterials",
                newName: "IsClearImage");

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "InspectorRawMaterials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PaperId",
                table: "InspectorRawMaterials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
