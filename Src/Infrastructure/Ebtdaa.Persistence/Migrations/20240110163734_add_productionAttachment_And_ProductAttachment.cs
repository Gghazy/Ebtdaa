using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class add_productionAttachment_And_ProductAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unit_ActualProductionAndCapacities_ActualProductionAndCapacityId",
                table: "Unit");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Products_ProductId",
                table: "Unit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Unit",
                table: "Unit");

            migrationBuilder.RenameTable(
                name: "Unit",
                newName: "Units");

            migrationBuilder.RenameIndex(
                name: "IX_Unit_ProductId",
                table: "Units",
                newName: "IX_Units_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Unit_ActualProductionAndCapacityId",
                table: "Units",
                newName: "IX_Units_ActualProductionAndCapacityId");

            migrationBuilder.AddColumn<bool>(
                name: "AnyNewProducts",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProductCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ActualProductionAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    ActualProduvtionId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ActualProductionId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualProductionAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualProductionAttachments_ActualProductionAndCapacities_ActualProductionId",
                        column: x => x.ActualProductionId,
                        principalTable: "ActualProductionAndCapacities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActualProductionAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttachments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActualProductionAttachments_ActualProductionId",
                table: "ActualProductionAttachments",
                column: "ActualProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualProductionAttachments_AttachmentId",
                table: "ActualProductionAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttachments_AttachmentId",
                table: "ProductAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttachments_ProductId",
                table: "ProductAttachments",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_ActualProductionAndCapacities_ActualProductionAndCapacityId",
                table: "Units",
                column: "ActualProductionAndCapacityId",
                principalTable: "ActualProductionAndCapacities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Products_ProductId",
                table: "Units",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_ActualProductionAndCapacities_ActualProductionAndCapacityId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Products_ProductId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "ActualProductionAttachments");

            migrationBuilder.DropTable(
                name: "ProductAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "AnyNewProducts",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "Unit");

            migrationBuilder.RenameIndex(
                name: "IX_Units_ProductId",
                table: "Unit",
                newName: "IX_Unit_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Units_ActualProductionAndCapacityId",
                table: "Unit",
                newName: "IX_Unit_ActualProductionAndCapacityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unit",
                table: "Unit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_ActualProductionAndCapacities_ActualProductionAndCapacityId",
                table: "Unit",
                column: "ActualProductionAndCapacityId",
                principalTable: "ActualProductionAndCapacities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Products_ProductId",
                table: "Unit",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
