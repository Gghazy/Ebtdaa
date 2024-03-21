using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class removerelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factories_InspectorFactories_InspectorFactoryId",
                table: "Factories");

            migrationBuilder.DropIndex(
                name: "IX_Factories_InspectorFactoryId",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "InspectorFactoryId",
                table: "Factories");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorFactories_FactoryId",
                table: "InspectorFactories",
                column: "FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectorFactories_Factories_FactoryId",
                table: "InspectorFactories",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectorFactories_Factories_FactoryId",
                table: "InspectorFactories");

            migrationBuilder.DropIndex(
                name: "IX_InspectorFactories_FactoryId",
                table: "InspectorFactories");

            migrationBuilder.AddColumn<int>(
                name: "InspectorFactoryId",
                table: "Factories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Factories_InspectorFactoryId",
                table: "Factories",
                column: "InspectorFactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factories_InspectorFactories_InspectorFactoryId",
                table: "Factories",
                column: "InspectorFactoryId",
                principalTable: "InspectorFactories",
                principalColumn: "Id");
        }
    }
}
