using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class deleteRelationIndustrialZone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryLocations_IndustiryalZoneTypes_IndustiryalZoneTypeId",
                table: "FactoryLocations");

            migrationBuilder.DropIndex(
                name: "IX_FactoryLocations_IndustiryalZoneTypeId",
                table: "FactoryLocations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocations_IndustiryalZoneTypeId",
                table: "FactoryLocations",
                column: "IndustiryalZoneTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryLocations_IndustiryalZoneTypes_IndustiryalZoneTypeId",
                table: "FactoryLocations",
                column: "IndustiryalZoneTypeId",
                principalTable: "IndustiryalZoneTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
