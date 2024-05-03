using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class paperIdInProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewProductPaperId",
                table: "InspectProductPhotos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaperId",
                table: "InspectProductPhotos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewProductPaperId",
                table: "InspectProductPhotos");

            migrationBuilder.DropColumn(
                name: "PaperId",
                table: "InspectProductPhotos");
        }
    }
}
