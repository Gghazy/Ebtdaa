using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class updateActualProductionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "ActualProductionAndCapacities");

            migrationBuilder.RenameColumn(
                name: "ReasoneForIncreaseCapacity",
                table: "ActualProductionAndCapacities",
                newName: "MonthId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MonthId",
                table: "ActualProductionAndCapacities",
                newName: "ReasoneForIncreaseCapacity");

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "ActualProductionAndCapacities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
