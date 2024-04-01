using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class addInspectFactLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "InspectFactoryLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    FactoryEntityId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    IndustrialAreaId = table.Column<int>(type: "int", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFactoryEntityCorrect = table.Column<bool>(type: "bit", nullable: false),
                    IsCityCorrect = table.Column<bool>(type: "bit", nullable: false),
                    IsIndustrialAreaCorrect = table.Column<bool>(type: "bit", nullable: false),
                    NewFactoryEntityId = table.Column<int>(type: "int", nullable: false),
                    NewCityId = table.Column<int>(type: "int", nullable: false),
                    NewIndustrialAreaId = table.Column<int>(type: "int", nullable: false),
                    NewWebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectFactoryLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectFactoryLocations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectFactoryLocations_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectFactoryLocations_FactoryEntities_FactoryEntityId",
                        column: x => x.FactoryEntityId,
                        principalTable: "FactoryEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectFactoryLocations_IndustrialAreas_IndustrialAreaId",
                        column: x => x.IndustrialAreaId,
                        principalTable: "IndustrialAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectFactoryLocations_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryLocations_CityId",
                table: "InspectFactoryLocations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryLocations_FactoryEntityId",
                table: "InspectFactoryLocations",
                column: "FactoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryLocations_FactoryId",
                table: "InspectFactoryLocations",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryLocations_IndustrialAreaId",
                table: "InspectFactoryLocations",
                column: "IndustrialAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryLocations_PeriodId",
                table: "InspectFactoryLocations",
                column: "PeriodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectFactoryLocations");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "Attachments");
        }
    }
}
