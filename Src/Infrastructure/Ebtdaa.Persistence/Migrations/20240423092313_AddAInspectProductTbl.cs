using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class AddAInspectProductTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectProductPhotos_Attachments_PhototId",
                table: "InspectProductPhotos");

            migrationBuilder.DropIndex(
                name: "IX_InspectProductPhotos_PhototId",
                table: "InspectProductPhotos");

            migrationBuilder.DropColumn(
                name: "PhototId",
                table: "InspectProductPhotos");

            migrationBuilder.CreateIndex(
                name: "IX_InspectProductPhotos_PhotoId",
                table: "InspectProductPhotos",
                column: "PhotoId");

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

            migrationBuilder.DropIndex(
                name: "IX_InspectProductPhotos_PhotoId",
                table: "InspectProductPhotos");

            migrationBuilder.AddColumn<int>(
                name: "PhototId",
                table: "InspectProductPhotos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InspectProductPhotos_PhototId",
                table: "InspectProductPhotos",
                column: "PhototId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectProductPhotos_Attachments_PhototId",
                table: "InspectProductPhotos",
                column: "PhototId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
