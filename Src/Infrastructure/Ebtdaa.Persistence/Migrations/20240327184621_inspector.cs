using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class inspector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FactoryEntityId",
                table: "Inspectors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IndustiryalZoneTypeId",
                table: "Inspectors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inspectors_FactoryEntityId",
                table: "Inspectors",
                column: "FactoryEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspectors_FactoryEntities_FactoryEntityId",
                table: "Inspectors",
                column: "FactoryEntityId",
                principalTable: "FactoryEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspectors_FactoryEntities_FactoryEntityId",
                table: "Inspectors");

            migrationBuilder.DropIndex(
                name: "IX_Inspectors_FactoryEntityId",
                table: "Inspectors");

            migrationBuilder.DropColumn(
                name: "FactoryEntityId",
                table: "Inspectors");

            migrationBuilder.DropColumn(
                name: "IndustiryalZoneTypeId",
                table: "Inspectors");
        }
    }
}
