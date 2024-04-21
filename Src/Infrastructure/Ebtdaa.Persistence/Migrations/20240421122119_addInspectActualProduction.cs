using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class addInspectActualProduction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InspectActualProductionAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectActualProductionAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectActualProductionAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectActualProductionAttachments_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectActualProductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryProductId = table.Column<int>(type: "int", nullable: false),
                    DesignedCapacity = table.Column<int>(type: "int", nullable: true),
                    ActualProduction = table.Column<int>(type: "int", nullable: true),
                    DesignedCapacityUnitId = table.Column<int>(type: "int", nullable: true),
                    ActualProductionUintId = table.Column<int>(type: "int", nullable: true),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectActualProductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectActualProductions_FactoryProducts_FactoryProductId",
                        column: x => x.FactoryProductId,
                        principalTable: "FactoryProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectActualProductions_Units_ActualProductionUintId",
                        column: x => x.ActualProductionUintId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspectActualProductions_Units_DesignedCapacityUnitId",
                        column: x => x.DesignedCapacityUnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectActualProductionAttachments_AttachmentId",
                table: "InspectActualProductionAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectActualProductionAttachments_FactoryId",
                table: "InspectActualProductionAttachments",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectActualProductions_ActualProductionUintId",
                table: "InspectActualProductions",
                column: "ActualProductionUintId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectActualProductions_DesignedCapacityUnitId",
                table: "InspectActualProductions",
                column: "DesignedCapacityUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectActualProductions_FactoryProductId",
                table: "InspectActualProductions",
                column: "FactoryProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectActualProductionAttachments");

            migrationBuilder.DropTable(
                name: "InspectActualProductions");
        }
    }
}
