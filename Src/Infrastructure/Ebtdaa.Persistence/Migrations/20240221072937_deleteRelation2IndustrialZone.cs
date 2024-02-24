using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class deleteRelation2IndustrialZone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndustiryalZoneTypeId",
                table: "FactoryLocations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndustiryalZoneTypeId",
                table: "FactoryLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
