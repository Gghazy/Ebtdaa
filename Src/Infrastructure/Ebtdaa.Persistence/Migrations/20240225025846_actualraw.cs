using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class actualraw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Month",
                table: "ActualRawMaterials",
                newName: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualRawMaterials_PeriodId",
                table: "ActualRawMaterials",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActualRawMaterials_Periods_PeriodId",
                table: "ActualRawMaterials",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActualRawMaterials_Periods_PeriodId",
                table: "ActualRawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_ActualRawMaterials_PeriodId",
                table: "ActualRawMaterials");

            migrationBuilder.RenameColumn(
                name: "PeriodId",
                table: "ActualRawMaterials",
                newName: "Month");
        }
    }
}
