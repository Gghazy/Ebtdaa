using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class updateScreenStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScreenStatuses_Periods_PeriodId",
                table: "ScreenStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodId",
                table: "ScreenStatuses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ScreenStatuses_Periods_PeriodId",
                table: "ScreenStatuses",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScreenStatuses_Periods_PeriodId",
                table: "ScreenStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "PeriodId",
                table: "ScreenStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ScreenStatuses_Periods_PeriodId",
                table: "ScreenStatuses",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
