using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class factoryInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CorrectFactoryName",
                table: "InspectBasicFactoryInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CorrectFactoryStatus",
                table: "InspectBasicFactoryInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectFactoryName",
                table: "InspectBasicFactoryInfos");

            migrationBuilder.DropColumn(
                name: "CorrectFactoryStatus",
                table: "InspectBasicFactoryInfos");
        }
    }
}
