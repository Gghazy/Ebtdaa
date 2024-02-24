using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class deleteColInIndustrialZone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityCode",
                table: "IndustrialAreas");

            migrationBuilder.DropColumn(
                name: "IndustrialCityName_LandAuthority",
                table: "IndustrialAreas");

            migrationBuilder.DropColumn(
                name: "IndustrialZoneTypeID",
                table: "IndustrialAreas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityCode",
                table: "IndustrialAreas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IndustrialCityName_LandAuthority",
                table: "IndustrialAreas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IndustrialZoneTypeID",
                table: "IndustrialAreas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
