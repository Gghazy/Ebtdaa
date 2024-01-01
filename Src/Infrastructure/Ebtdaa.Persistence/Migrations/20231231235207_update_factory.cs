using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class update_factory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factories_FactoryContacts_FactoryContactId",
                table: "Factories");

            migrationBuilder.DropForeignKey(
                name: "FK_Factories_FactoryFinancials_FactoryFinancialId",
                table: "Factories");

            migrationBuilder.DropForeignKey(
                name: "FK_Factories_FactoryLocations_FactoryLocationId",
                table: "Factories");

            migrationBuilder.DropIndex(
                name: "IX_Factories_FactoryContactId",
                table: "Factories");

            migrationBuilder.DropIndex(
                name: "IX_Factories_FactoryFinancialId",
                table: "Factories");

            migrationBuilder.DropIndex(
                name: "IX_Factories_FactoryLocationId",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "FactoryContactId",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "FactoryFinancialId",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "FactoryLocationId",
                table: "Factories");

            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "FactoryLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "FactoryFinancials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "FactoryContacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocations_FactoryId",
                table: "FactoryLocations",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryFinancials_FactoryId",
                table: "FactoryFinancials",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryContacts_FactoryId",
                table: "FactoryContacts",
                column: "FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryContacts_Factories_FactoryId",
                table: "FactoryContacts",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryFinancials_Factories_FactoryId",
                table: "FactoryFinancials",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryLocations_Factories_FactoryId",
                table: "FactoryLocations",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryContacts_Factories_FactoryId",
                table: "FactoryContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_FactoryFinancials_Factories_FactoryId",
                table: "FactoryFinancials");

            migrationBuilder.DropForeignKey(
                name: "FK_FactoryLocations_Factories_FactoryId",
                table: "FactoryLocations");

            migrationBuilder.DropIndex(
                name: "IX_FactoryLocations_FactoryId",
                table: "FactoryLocations");

            migrationBuilder.DropIndex(
                name: "IX_FactoryFinancials_FactoryId",
                table: "FactoryFinancials");

            migrationBuilder.DropIndex(
                name: "IX_FactoryContacts_FactoryId",
                table: "FactoryContacts");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "FactoryLocations");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "FactoryFinancials");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "FactoryContacts");

            migrationBuilder.AddColumn<int>(
                name: "FactoryContactId",
                table: "Factories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FactoryFinancialId",
                table: "Factories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FactoryLocationId",
                table: "Factories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Factories_FactoryContactId",
                table: "Factories",
                column: "FactoryContactId",
                unique: true,
                filter: "[FactoryContactId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Factories_FactoryFinancialId",
                table: "Factories",
                column: "FactoryFinancialId",
                unique: true,
                filter: "[FactoryFinancialId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Factories_FactoryLocationId",
                table: "Factories",
                column: "FactoryLocationId",
                unique: true,
                filter: "[FactoryLocationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Factories_FactoryContacts_FactoryContactId",
                table: "Factories",
                column: "FactoryContactId",
                principalTable: "FactoryContacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Factories_FactoryFinancials_FactoryFinancialId",
                table: "Factories",
                column: "FactoryFinancialId",
                principalTable: "FactoryFinancials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Factories_FactoryLocations_FactoryLocationId",
                table: "Factories",
                column: "FactoryLocationId",
                principalTable: "FactoryLocations",
                principalColumn: "Id");
        }
    }
}
