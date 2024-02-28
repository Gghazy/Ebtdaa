using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MonthId",
                table: "IncreaseActualProductions",
                newName: "PeriodId");

            migrationBuilder.RenameColumn(
                name: "MonthId",
                table: "ActualProductionAndCapacities",
                newName: "PeriodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PeriodId",
                table: "IncreaseActualProductions",
                newName: "MonthId");

            migrationBuilder.RenameColumn(
                name: "PeriodId",
                table: "ActualProductionAndCapacities",
                newName: "MonthId");
        }
    }
}
