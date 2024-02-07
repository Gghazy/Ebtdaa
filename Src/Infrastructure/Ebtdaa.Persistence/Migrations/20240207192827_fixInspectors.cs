using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class fixInspectors : Migration
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
                name: "Sign",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "ActualProductionId",
                table: "ActualProductionAttachments");

            migrationBuilder.RenameColumn(
                name: "Month",
                table: "IncreaseActualProductions",
                newName: "MonthId");

            migrationBuilder.RenameColumn(
                name: "ActualProduvtionId",
                table: "ActualProductionAttachments",
                newName: "FactoryId");

            migrationBuilder.AlterColumn<int>(
                name: "conversionToKG",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "IncreaseActualProductions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ActualProductionAttachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_IncreaseActualProductions_FactoryId",
                table: "IncreaseActualProductions",
                column: "FactoryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_IncreaseActualProductions_Factories_FactoryId",
                table: "IncreaseActualProductions",
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

            migrationBuilder.DropForeignKey(
                name: "FK_IncreaseActualProductions_Factories_FactoryId",
                table: "IncreaseActualProductions");

            migrationBuilder.DropIndex(
                name: "IX_IncreaseActualProductions_FactoryId",
                table: "IncreaseActualProductions");

            migrationBuilder.DropIndex(
                name: "IX_ActualProductionAttachments_FactoryId",
                table: "ActualProductionAttachments");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "IncreaseActualProductions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ActualProductionAttachments");

            migrationBuilder.RenameColumn(
                name: "MonthId",
                table: "IncreaseActualProductions",
                newName: "Month");

            migrationBuilder.RenameColumn(
                name: "FactoryId",
                table: "ActualProductionAttachments",
                newName: "ActualProduvtionId");

            migrationBuilder.AlterColumn<int>(
                name: "conversionToKG",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sign",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
