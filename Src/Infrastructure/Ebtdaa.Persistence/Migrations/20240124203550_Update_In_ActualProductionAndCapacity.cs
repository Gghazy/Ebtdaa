using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class Update_In_ActualProductionAndCapacity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActualProductionAndCapacities_Factories_FactoryId",
                table: "ActualProductionAndCapacities");

            migrationBuilder.DropForeignKey(
                name: "FK_ReasonIncreasCapacities_ActualProductionAndCapacities_ActualProductionAndCapacityId",
                table: "ReasonIncreasCapacities");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_ActualProductionAndCapacities_ActualProductionAndCapacityId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_ActualProductionAndCapacityId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_ReasonIncreasCapacities_ActualProductionAndCapacityId",
                table: "ReasonIncreasCapacities");

            migrationBuilder.DropColumn(
                name: "ActualProductionAndCapacityId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "ActualProductionAndCapacityId",
                table: "ReasonIncreasCapacities");

            migrationBuilder.DropColumn(
                name: "CustomItemId_12",
                table: "ActualProductionAndCapacities");

            migrationBuilder.RenameColumn(
                name: "FactoryId",
                table: "ActualProductionAndCapacities",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ActualProductionAndCapacities_FactoryId",
                table: "ActualProductionAndCapacities",
                newName: "IX_ActualProductionAndCapacities_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualProductionAndCapacities_ActualProductionUintId",
                table: "ActualProductionAndCapacities",
                column: "ActualProductionUintId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualProductionAndCapacities_DesignedCapacityUnitId",
                table: "ActualProductionAndCapacities",
                column: "DesignedCapacityUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActualProductionAndCapacities_Products_ProductId",
                table: "ActualProductionAndCapacities",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActualProductionAndCapacities_Units_ActualProductionUintId",
                table: "ActualProductionAndCapacities",
                column: "ActualProductionUintId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActualProductionAndCapacities_Units_DesignedCapacityUnitId",
                table: "ActualProductionAndCapacities",
                column: "DesignedCapacityUnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActualProductionAndCapacities_Products_ProductId",
                table: "ActualProductionAndCapacities");

            migrationBuilder.DropForeignKey(
                name: "FK_ActualProductionAndCapacities_Units_ActualProductionUintId",
                table: "ActualProductionAndCapacities");

            migrationBuilder.DropForeignKey(
                name: "FK_ActualProductionAndCapacities_Units_DesignedCapacityUnitId",
                table: "ActualProductionAndCapacities");

            migrationBuilder.DropIndex(
                name: "IX_ActualProductionAndCapacities_ActualProductionUintId",
                table: "ActualProductionAndCapacities");

            migrationBuilder.DropIndex(
                name: "IX_ActualProductionAndCapacities_DesignedCapacityUnitId",
                table: "ActualProductionAndCapacities");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ActualProductionAndCapacities",
                newName: "FactoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ActualProductionAndCapacities_ProductId",
                table: "ActualProductionAndCapacities",
                newName: "IX_ActualProductionAndCapacities_FactoryId");

            migrationBuilder.AddColumn<int>(
                name: "ActualProductionAndCapacityId",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActualProductionAndCapacityId",
                table: "ReasonIncreasCapacities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomItemId_12",
                table: "ActualProductionAndCapacities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Units_ActualProductionAndCapacityId",
                table: "Units",
                column: "ActualProductionAndCapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonIncreasCapacities_ActualProductionAndCapacityId",
                table: "ReasonIncreasCapacities",
                column: "ActualProductionAndCapacityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActualProductionAndCapacities_Factories_FactoryId",
                table: "ActualProductionAndCapacities",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReasonIncreasCapacities_ActualProductionAndCapacities_ActualProductionAndCapacityId",
                table: "ReasonIncreasCapacities",
                column: "ActualProductionAndCapacityId",
                principalTable: "ActualProductionAndCapacities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_ActualProductionAndCapacities_ActualProductionAndCapacityId",
                table: "Units",
                column: "ActualProductionAndCapacityId",
                principalTable: "ActualProductionAndCapacities",
                principalColumn: "Id");
        }
    }
}
