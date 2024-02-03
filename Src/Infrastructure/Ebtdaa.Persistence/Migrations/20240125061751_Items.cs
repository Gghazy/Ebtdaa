using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class Items : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActualRawMaterialFiles_Factories_FactoryId",
                table: "ActualRawMaterialFiles");

            migrationBuilder.RenameColumn(
                name: "FactoryId",
                table: "ActualRawMaterialFiles",
                newName: "ActualRawMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_ActualRawMaterialFiles_FactoryId",
                table: "ActualRawMaterialFiles",
                newName: "IX_ActualRawMaterialFiles_ActualRawMaterialId");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "RawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ActualRawMaterialFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RawMaterialAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    RawMaterialId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterialAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RawMaterialAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RawMaterialAttachments_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_UnitId",
                table: "RawMaterials",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterialAttachments_AttachmentId",
                table: "RawMaterialAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterialAttachments_RawMaterialId",
                table: "RawMaterialAttachments",
                column: "RawMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActualRawMaterialFiles_ActualRawMaterials_ActualRawMaterialId",
                table: "ActualRawMaterialFiles",
                column: "ActualRawMaterialId",
                principalTable: "ActualRawMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_Units_UnitId",
                table: "RawMaterials",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActualRawMaterialFiles_ActualRawMaterials_ActualRawMaterialId",
                table: "ActualRawMaterialFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_Units_UnitId",
                table: "RawMaterials");

            migrationBuilder.DropTable(
                name: "RawMaterialAttachments");

            migrationBuilder.DropIndex(
                name: "IX_RawMaterials_UnitId",
                table: "RawMaterials");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "RawMaterials");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ActualRawMaterialFiles");

            migrationBuilder.RenameColumn(
                name: "ActualRawMaterialId",
                table: "ActualRawMaterialFiles",
                newName: "FactoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ActualRawMaterialFiles_ActualRawMaterialId",
                table: "ActualRawMaterialFiles",
                newName: "IX_ActualRawMaterialFiles_FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActualRawMaterialFiles_Factories_FactoryId",
                table: "ActualRawMaterialFiles",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
