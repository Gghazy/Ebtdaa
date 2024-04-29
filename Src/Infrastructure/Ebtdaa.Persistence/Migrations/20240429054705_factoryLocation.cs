using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class factoryLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectFactoryLocationAttachments_FactoryLocations_FactoryLocationId",
                table: "InspectFactoryLocationAttachments");

            migrationBuilder.DropIndex(
                name: "IX_InspectFactoryLocationAttachments_FactoryLocationId",
                table: "InspectFactoryLocationAttachments");

            migrationBuilder.RenameColumn(
                name: "FactoryLocationId",
                table: "InspectFactoryLocationAttachments",
                newName: "PeriodId");

            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "InspectFactoryLocationAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryLocationAttachments_FactoryId",
                table: "InspectFactoryLocationAttachments",
                column: "FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectFactoryLocationAttachments_Factories_FactoryId",
                table: "InspectFactoryLocationAttachments",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectFactoryLocationAttachments_Factories_FactoryId",
                table: "InspectFactoryLocationAttachments");

            migrationBuilder.DropIndex(
                name: "IX_InspectFactoryLocationAttachments_FactoryId",
                table: "InspectFactoryLocationAttachments");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "InspectFactoryLocationAttachments");

            migrationBuilder.RenameColumn(
                name: "PeriodId",
                table: "InspectFactoryLocationAttachments",
                newName: "FactoryLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryLocationAttachments_FactoryLocationId",
                table: "InspectFactoryLocationAttachments",
                column: "FactoryLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectFactoryLocationAttachments_FactoryLocations_FactoryLocationId",
                table: "InspectFactoryLocationAttachments",
                column: "FactoryLocationId",
                principalTable: "FactoryLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
