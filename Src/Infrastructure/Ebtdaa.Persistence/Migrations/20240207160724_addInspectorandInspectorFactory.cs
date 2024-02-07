using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class addInspectorandInspectorFactory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "conversionToKG",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InspectorFactoryId",
                table: "Factories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inspectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerIdentity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InspectorFactories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    InspectorId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectorFactories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectorFactories_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factories_InspectorFactoryId",
                table: "Factories",
                column: "InspectorFactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorFactories_InspectorId",
                table: "InspectorFactories",
                column: "InspectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factories_InspectorFactories_InspectorFactoryId",
                table: "Factories",
                column: "InspectorFactoryId",
                principalTable: "InspectorFactories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factories_InspectorFactories_InspectorFactoryId",
                table: "Factories");

            migrationBuilder.DropTable(
                name: "InspectorFactories");

            migrationBuilder.DropTable(
                name: "Inspectors");

            migrationBuilder.DropIndex(
                name: "IX_Factories_InspectorFactoryId",
                table: "Factories");

            migrationBuilder.DropColumn(
                name: "conversionToKG",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "InspectorFactoryId",
                table: "Factories");
        }
    }
}
