using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class locationFactoy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryLocationAttachments_Factories_FactoryId",
                table: "FactoryLocationAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_FactoryLocationAttachments_FactoryLocations_FactoryLocationId",
                table: "FactoryLocationAttachments");

            migrationBuilder.DropIndex(
                name: "IX_FactoryLocationAttachments_FactoryId",
                table: "FactoryLocationAttachments");

            migrationBuilder.DropIndex(
                name: "IX_FactoryLocationAttachments_FactoryLocationId",
                table: "FactoryLocationAttachments");

            migrationBuilder.DropColumn(
                name: "FactoryLocationId",
                table: "FactoryLocationAttachments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FactoryLocationId",
                table: "FactoryLocationAttachments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocationAttachments_FactoryId",
                table: "FactoryLocationAttachments",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocationAttachments_FactoryLocationId",
                table: "FactoryLocationAttachments",
                column: "FactoryLocationId");

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
        }
    }
}
