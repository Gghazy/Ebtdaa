using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class addBasicFactoryInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CityNameAr",
                table: "IndustrialAreas",
                newName: "NameEn");

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodEndDate",
                table: "Periods",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "IndustrialAreas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "FactoryLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "FactoryContacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BasicFactoryInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    FactoryStatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicFactoryInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasicFactoryInfos_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasicFactoryInfos_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocations_PeriodId",
                table: "FactoryLocations",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryContacts_PeriodId",
                table: "FactoryContacts",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_BasicFactoryInfos_FactoryId",
                table: "BasicFactoryInfos",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BasicFactoryInfos_PeriodId",
                table: "BasicFactoryInfos",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryContacts_Periods_PeriodId",
                table: "FactoryContacts",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryLocations_Periods_PeriodId",
                table: "FactoryLocations",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryContacts_Periods_PeriodId",
                table: "FactoryContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_FactoryLocations_Periods_PeriodId",
                table: "FactoryLocations");

            migrationBuilder.DropTable(
                name: "BasicFactoryInfos");

            migrationBuilder.DropIndex(
                name: "IX_FactoryLocations_PeriodId",
                table: "FactoryLocations");

            migrationBuilder.DropIndex(
                name: "IX_FactoryContacts_PeriodId",
                table: "FactoryContacts");

            migrationBuilder.DropColumn(
                name: "PeriodEndDate",
                table: "Periods");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "IndustrialAreas");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "FactoryLocations");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "FactoryContacts");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "IndustrialAreas",
                newName: "CityNameAr");
        }
    }
}
