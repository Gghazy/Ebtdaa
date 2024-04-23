using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class inspectorFactoyEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndustiryalZoneTypeId",
                table: "Inspectors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndustiryalZoneTypeId",
                table: "Inspectors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
