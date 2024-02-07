using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class Add_factory_In_ActualProductionAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActualProductionAttachments_ActualProductionAndCapacities_ActualProductionId",
                table: "ActualProductionAttachments");

            migrationBuilder.DropIndex(
                name: "IX_ActualProductionAttachments_ActualProductionId",
                table: "ActualProductionAttachments");

            migrationBuilder.DropColumn(
                name: "ActualProductionId",
                table: "ActualProductionAttachments");

            migrationBuilder.RenameColumn(
                name: "ActualProduvtionId",
                table: "ActualProductionAttachments",
                newName: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualProductionAttachments_FactoryId",
                table: "ActualProductionAttachments",
                column: "FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActualProductionAttachments_Factories_FactoryId",
                table: "ActualProductionAttachments",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActualProductionAttachments_Factories_FactoryId",
                table: "ActualProductionAttachments");

            migrationBuilder.DropIndex(
                name: "IX_ActualProductionAttachments_FactoryId",
                table: "ActualProductionAttachments");

            migrationBuilder.RenameColumn(
                name: "FactoryId",
                table: "ActualProductionAttachments",
                newName: "ActualProduvtionId");

            migrationBuilder.AddColumn<int>(
                name: "ActualProductionId",
                table: "ActualProductionAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ActualProductionAttachments_ActualProductionId",
                table: "ActualProductionAttachments",
                column: "ActualProductionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActualProductionAttachments_ActualProductionAndCapacities_ActualProductionId",
                table: "ActualProductionAttachments",
                column: "ActualProductionId",
                principalTable: "ActualProductionAndCapacities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
