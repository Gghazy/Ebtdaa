using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class updat_table_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryMonthlyFinancial_Factories_FactoryId",
                table: "FactoryMonthlyFinancial");

            migrationBuilder.DropForeignKey(
                name: "FK_FactoryMonthlyFinancial_Periods_PeriodId",
                table: "FactoryMonthlyFinancial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FactoryMonthlyFinancial",
                table: "FactoryMonthlyFinancial");

            migrationBuilder.RenameTable(
                name: "FactoryMonthlyFinancial",
                newName: "FactoryMonthlyFinancials");

            migrationBuilder.RenameIndex(
                name: "IX_FactoryMonthlyFinancial_PeriodId",
                table: "FactoryMonthlyFinancials",
                newName: "IX_FactoryMonthlyFinancials_PeriodId");

            migrationBuilder.RenameIndex(
                name: "IX_FactoryMonthlyFinancial_FactoryId",
                table: "FactoryMonthlyFinancials",
                newName: "IX_FactoryMonthlyFinancials_FactoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FactoryMonthlyFinancials",
                table: "FactoryMonthlyFinancials",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryMonthlyFinancials_Factories_FactoryId",
                table: "FactoryMonthlyFinancials",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryMonthlyFinancials_Periods_PeriodId",
                table: "FactoryMonthlyFinancials",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryMonthlyFinancials_Factories_FactoryId",
                table: "FactoryMonthlyFinancials");

            migrationBuilder.DropForeignKey(
                name: "FK_FactoryMonthlyFinancials_Periods_PeriodId",
                table: "FactoryMonthlyFinancials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FactoryMonthlyFinancials",
                table: "FactoryMonthlyFinancials");

            migrationBuilder.RenameTable(
                name: "FactoryMonthlyFinancials",
                newName: "FactoryMonthlyFinancial");

            migrationBuilder.RenameIndex(
                name: "IX_FactoryMonthlyFinancials_PeriodId",
                table: "FactoryMonthlyFinancial",
                newName: "IX_FactoryMonthlyFinancial_PeriodId");

            migrationBuilder.RenameIndex(
                name: "IX_FactoryMonthlyFinancials_FactoryId",
                table: "FactoryMonthlyFinancial",
                newName: "IX_FactoryMonthlyFinancial_FactoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FactoryMonthlyFinancial",
                table: "FactoryMonthlyFinancial",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryMonthlyFinancial_Factories_FactoryId",
                table: "FactoryMonthlyFinancial",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryMonthlyFinancial_Periods_PeriodId",
                table: "FactoryMonthlyFinancial",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
