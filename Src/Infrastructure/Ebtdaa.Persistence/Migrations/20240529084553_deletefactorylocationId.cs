using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class deletefactorylocationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryLocationAttachments_FactoryLocations_FactoryLocationId",
                table: "FactoryLocationAttachments");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryLocationId",
                table: "FactoryLocationAttachments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryLocationAttachments_FactoryLocations_FactoryLocationId",
                table: "FactoryLocationAttachments",
                column: "FactoryLocationId",
                principalTable: "FactoryLocations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryLocationAttachments_Periods_PeriodId",
                table: "FactoryLocationAttachments",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryLocationAttachments_Factories_FactoryId",
                table: "FactoryLocationAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_FactoryLocationAttachments_FactoryLocations_FactoryLocationId",
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
