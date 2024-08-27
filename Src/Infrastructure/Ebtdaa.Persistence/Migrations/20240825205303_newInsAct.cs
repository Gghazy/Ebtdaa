using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class newInsAct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InspectAcuProductName",
                table: "InspectActualProductions",
                newName: "InspectAcutProdName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InspectAcutProdName",
                table: "InspectActualProductions",
                newName: "InspectAcuProductName");
        }
    }
}
