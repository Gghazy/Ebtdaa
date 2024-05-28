using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class addAttachmentsValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "FactoryFinancialAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "FactoryFinancialAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FactoryFinancialAttachments_FactoryId",
                table: "FactoryFinancialAttachments",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryFinancialAttachments_PeriodId",
                table: "FactoryFinancialAttachments",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryFinancialAttachments_Factories_FactoryId",
                table: "FactoryFinancialAttachments",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryFinancialAttachments_Periods_PeriodId",
                table: "FactoryFinancialAttachments",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryFinancialAttachments_Factories_FactoryId",
                table: "FactoryFinancialAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_FactoryFinancialAttachments_Periods_PeriodId",
                table: "FactoryFinancialAttachments");

            migrationBuilder.DropIndex(
                name: "IX_FactoryFinancialAttachments_FactoryId",
                table: "FactoryFinancialAttachments");

            migrationBuilder.DropIndex(
                name: "IX_FactoryFinancialAttachments_PeriodId",
                table: "FactoryFinancialAttachments");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "FactoryFinancialAttachments");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "FactoryFinancialAttachments");
        }
    }
}
