using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class factoryLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "IndustrialAreas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FactoryEntityId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IndustrialAreas_CityId",
                table: "IndustrialAreas",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_FactoryEntityId",
                table: "Cities",
                column: "FactoryEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_FactoryEntities_FactoryEntityId",
                table: "Cities",
                column: "FactoryEntityId",
                principalTable: "FactoryEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_IndustrialAreas_Cities_CityId",
                table: "IndustrialAreas",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_FactoryEntities_FactoryEntityId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_IndustrialAreas_Cities_CityId",
                table: "IndustrialAreas");

            migrationBuilder.DropIndex(
                name: "IX_IndustrialAreas_CityId",
                table: "IndustrialAreas");

            migrationBuilder.DropIndex(
                name: "IX_Cities_FactoryEntityId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "IndustrialAreas");

            migrationBuilder.DropColumn(
                name: "FactoryEntityId",
                table: "Cities");
        }
    }
}
