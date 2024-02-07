using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class addfactoryIdinIncreaseActualProduction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "IncreaseActualProductions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IncreaseActualProductions_FactoryId",
                table: "IncreaseActualProductions",
                column: "FactoryId");

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
                name: "FK_IncreaseActualProductions_Factories_FactoryId",
                table: "IncreaseActualProductions");

            migrationBuilder.DropIndex(
                name: "IX_IncreaseActualProductions_FactoryId",
                table: "IncreaseActualProductions");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "IncreaseActualProductions");
        }
    }
}
