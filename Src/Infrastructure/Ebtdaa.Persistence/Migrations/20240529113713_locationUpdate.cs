using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class locationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryLocationAttachments_Periods_PeriodId",
                table: "FactoryLocationAttachments");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "FactoryLocationAttachments");

            migrationBuilder.RenameColumn(
                name: "PeriodId",
                table: "FactoryLocationAttachments",
                newName: "FactoryLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_FactoryLocationAttachments_PeriodId",
                table: "FactoryLocationAttachments",
                newName: "IX_FactoryLocationAttachments_FactoryLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryLocationAttachments_FactoryLocations_FactoryLocationId",
                table: "FactoryLocationAttachments",
                column: "FactoryLocationId",
                principalTable: "FactoryLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryLocationAttachments_FactoryLocations_FactoryLocationId",
                table: "FactoryLocationAttachments");

            migrationBuilder.RenameColumn(
                name: "FactoryLocationId",
                table: "FactoryLocationAttachments",
                newName: "PeriodId");

            migrationBuilder.RenameIndex(
                name: "IX_FactoryLocationAttachments_FactoryLocationId",
                table: "FactoryLocationAttachments",
                newName: "IX_FactoryLocationAttachments_PeriodId");

            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "FactoryLocationAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryLocationAttachments_Periods_PeriodId",
                table: "FactoryLocationAttachments",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
