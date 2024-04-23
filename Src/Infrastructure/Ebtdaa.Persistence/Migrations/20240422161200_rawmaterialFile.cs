using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class rawmaterialFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "InspectorRawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "InspectorRawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InspectorRawMaterialFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RawMaterialId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectorRawMaterialFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectorRawMaterialFiles_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectorRawMaterialFiles_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectorRawMaterialFiles_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectorRawMaterials_FactoryId",
                table: "InspectorRawMaterials",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorRawMaterials_PeriodId",
                table: "InspectorRawMaterials",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorRawMaterialFiles_AttachmentId",
                table: "InspectorRawMaterialFiles",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorRawMaterialFiles_FactoryId",
                table: "InspectorRawMaterialFiles",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorRawMaterialFiles_RawMaterialId",
                table: "InspectorRawMaterialFiles",
                column: "RawMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectorRawMaterials_Factories_FactoryId",
                table: "InspectorRawMaterials",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectorRawMaterials_Periods_PeriodId",
                table: "InspectorRawMaterials",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectorRawMaterials_Factories_FactoryId",
                table: "InspectorRawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectorRawMaterials_Periods_PeriodId",
                table: "InspectorRawMaterials");

            migrationBuilder.DropTable(
                name: "InspectorRawMaterialFiles");

            migrationBuilder.DropIndex(
                name: "IX_InspectorRawMaterials_FactoryId",
                table: "InspectorRawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_InspectorRawMaterials_PeriodId",
                table: "InspectorRawMaterials");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "InspectorRawMaterials");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "InspectorRawMaterials");
        }
    }
}
