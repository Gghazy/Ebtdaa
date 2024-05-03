using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class InspectActual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IncreaseReasonCorrect",
                table: "InspectActualProductions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IncreaseReasonId",
                table: "InspectActualProductions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncreaseReasonCorrect",
                table: "InspectActualProductions");

            migrationBuilder.DropColumn(
                name: "IncreaseReasonId",
                table: "InspectActualProductions");
        }
    }
}
