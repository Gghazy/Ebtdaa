using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class deleteIndustrialZone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndustiryalZoneTypes");

            migrationBuilder.DropColumn(
                name: "IndustiryalZoneTypeId",
                table: "Inspectors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndustiryalZoneTypeId",
                table: "Inspectors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IndustiryalZoneTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectorId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustiryalZoneTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndustiryalZoneTypes_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndustiryalZoneTypes_InspectorId",
                table: "IndustiryalZoneTypes",
                column: "InspectorId");
        }
    }
}
