using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class renamePeriodIdInFactoryProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryProducts_Periods_periodId",
                table: "FactoryProducts");

            migrationBuilder.RenameColumn(
                name: "periodId",
                table: "FactoryProducts",
                newName: "PeriodId");

            migrationBuilder.RenameIndex(
                name: "IX_FactoryProducts_periodId",
                table: "FactoryProducts",
                newName: "IX_FactoryProducts_PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryProducts_Periods_PeriodId",
                table: "FactoryProducts",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryProducts_Periods_PeriodId",
                table: "FactoryProducts");

            migrationBuilder.RenameColumn(
                name: "PeriodId",
                table: "FactoryProducts",
                newName: "periodId");

            migrationBuilder.RenameIndex(
                name: "IX_FactoryProducts_PeriodId",
                table: "FactoryProducts",
                newName: "IX_FactoryProducts_periodId");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryProducts_Periods_periodId",
                table: "FactoryProducts",
                column: "periodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
