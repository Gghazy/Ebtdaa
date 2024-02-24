using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class addIndustrialZone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "IndustrialAreas",
                newName: "IndustrialCityName_LandAuthority");

            migrationBuilder.RenameColumn(
                name: "NameAr",
                table: "IndustrialAreas",
                newName: "CityNameAr");

            migrationBuilder.AddColumn<int>(
                name: "CityCode",
                table: "IndustrialAreas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IndustrialZoneTypeID",
                table: "IndustrialAreas",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndustrialAreas_IndustiryalZoneTypes_IndustrialZoneTypeID",
                table: "IndustrialAreas");

            migrationBuilder.DropIndex(
                name: "IX_IndustrialAreas_IndustrialZoneTypeID",
                table: "IndustrialAreas");

            migrationBuilder.DropColumn(
                name: "CityCode",
                table: "IndustrialAreas");

            migrationBuilder.DropColumn(
                name: "IndustrialZoneTypeID",
                table: "IndustrialAreas");

            migrationBuilder.RenameColumn(
                name: "IndustrialCityName_LandAuthority",
                table: "IndustrialAreas",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "CityNameAr",
                table: "IndustrialAreas",
                newName: "NameAr");
        }
    }
}
