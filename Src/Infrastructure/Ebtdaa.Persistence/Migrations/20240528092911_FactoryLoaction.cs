using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class FactoryLoaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "FactoryLocationAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "FactoryLocationAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocationAttachments_FactoryId",
                table: "FactoryLocationAttachments",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocationAttachments_PeriodId",
                table: "FactoryLocationAttachments",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryLocationAttachments_Factories_FactoryId",
                table: "FactoryLocationAttachments",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryLocationAttachments_Periods_PeriodId",
                table: "FactoryLocationAttachments",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryLocationAttachments_Factories_FactoryId",
                table: "FactoryLocationAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_FactoryLocationAttachments_Periods_PeriodId",
                table: "FactoryLocationAttachments");

            migrationBuilder.DropIndex(
                name: "IX_FactoryLocationAttachments_FactoryId",
                table: "FactoryLocationAttachments");

            migrationBuilder.DropIndex(
                name: "IX_FactoryLocationAttachments_PeriodId",
                table: "FactoryLocationAttachments");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "FactoryLocationAttachments");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "FactoryLocationAttachments");
        }
    }
}
