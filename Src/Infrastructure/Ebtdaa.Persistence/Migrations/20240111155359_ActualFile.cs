using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class ActualFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "RawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ActualRawMaterialFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualRawMaterialFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualRawMaterialFiles_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActualRawMaterialFiles_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_ProductId",
                table: "RawMaterials",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualRawMaterialFiles_AttachmentId",
                table: "ActualRawMaterialFiles",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualRawMaterialFiles_FactoryId",
                table: "ActualRawMaterialFiles",
                column: "FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_Products_ProductId",
                table: "RawMaterials",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_Products_ProductId",
                table: "RawMaterials");

            migrationBuilder.DropTable(
                name: "ActualRawMaterialFiles");

            migrationBuilder.DropIndex(
                name: "IX_RawMaterials_ProductId",
                table: "RawMaterials");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "RawMaterials");
        }
    }
}
