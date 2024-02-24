using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class deleterelationInIndustrialZone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndustrialAreas_IndustiryalZoneTypes_IndustrialZoneTypeID",
                table: "IndustrialAreas");

            migrationBuilder.DropIndex(
                name: "IX_IndustrialAreas_IndustrialZoneTypeID",
                table: "IndustrialAreas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_IndustrialAreas_IndustrialZoneTypeID",
                table: "IndustrialAreas",
                column: "IndustrialZoneTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_IndustrialAreas_IndustiryalZoneTypes_IndustrialZoneTypeID",
                table: "IndustrialAreas",
                column: "IndustrialZoneTypeID",
                principalTable: "IndustiryalZoneTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
