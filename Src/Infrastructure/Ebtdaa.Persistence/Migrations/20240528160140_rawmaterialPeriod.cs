using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class rawmaterialPeriod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryLocationAttachments_FactoryLocations_FactoryLocationId",
                table: "FactoryLocationAttachments");

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "RawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FactoryLocationId",
                table: "FactoryLocationAttachments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_PeriodId",
                table: "RawMaterials",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryLocationAttachments_FactoryLocations_FactoryLocationId",
                table: "FactoryLocationAttachments",
                column: "FactoryLocationId",
                principalTable: "FactoryLocations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_Periods_PeriodId",
                table: "RawMaterials",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryLocationAttachments_FactoryLocations_FactoryLocationId",
                table: "FactoryLocationAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_Periods_PeriodId",
                table: "RawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_RawMaterials_PeriodId",
                table: "RawMaterials");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "RawMaterials");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryLocationId",
                table: "FactoryLocationAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryLocationAttachments_FactoryLocations_FactoryLocationId",
                table: "FactoryLocationAttachments",
                column: "FactoryLocationId",
                principalTable: "FactoryLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
