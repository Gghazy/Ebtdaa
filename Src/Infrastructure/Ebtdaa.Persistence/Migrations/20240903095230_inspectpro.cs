using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class inspectpro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectProductPhotos_Attachments_PhotoId",
                table: "InspectProductPhotos");

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "InspectProductPhotos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PaperId",
                table: "InspectProductPhotos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectProductPhotos_Attachments_PhotoId",
                table: "InspectProductPhotos",
                column: "PhotoId",
                principalTable: "Attachments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectProductPhotos_Attachments_PhotoId",
                table: "InspectProductPhotos");

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "InspectProductPhotos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaperId",
                table: "InspectProductPhotos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectProductPhotos_Attachments_PhotoId",
                table: "InspectProductPhotos",
                column: "PhotoId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
