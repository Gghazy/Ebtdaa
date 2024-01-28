using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class UpdateProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_FactoryProducts_FactoryProductId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "CustomsItemLevels");

            migrationBuilder.DropTable(
                name: "FactoryProducts");

            migrationBuilder.RenameColumn(
                name: "FactoryProductId",
                table: "Products",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "CustomItemId_12",
                table: "Products",
                newName: "LevelId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_FactoryProductId",
                table: "Products",
                newName: "IX_Products_ParentId");

            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_FactoryId",
                table: "Products",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LevelId",
                table: "Products",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Factories_FactoryId",
                table: "Products",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Levels_LevelId",
                table: "Products",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_ParentId",
                table: "Products",
                column: "ParentId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Factories_FactoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Levels_LevelId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_ParentId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropIndex(
                name: "IX_Products_FactoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_LevelId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Products",
                newName: "FactoryProductId");

            migrationBuilder.RenameColumn(
                name: "LevelId",
                table: "Products",
                newName: "CustomItemId_12");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ParentId",
                table: "Products",
                newName: "IX_Products_FactoryProductId");

            migrationBuilder.CreateTable(
                name: "CustomsItemLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomsItemUpdateId = table.Column<int>(type: "int", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomsItemLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomsItemLevels_CustomsItemUpdates_CustomsItemUpdateId",
                        column: x => x.CustomsItemUpdateId,
                        principalTable: "CustomsItemUpdates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomsItemLevels_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FactoryProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactoryProducts_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomsItemLevels_CustomsItemUpdateId",
                table: "CustomsItemLevels",
                column: "CustomsItemUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomsItemLevels_ProductId",
                table: "CustomsItemLevels",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryProducts_FactoryId",
                table: "FactoryProducts",
                column: "FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FactoryProducts_FactoryProductId",
                table: "Products",
                column: "FactoryProductId",
                principalTable: "FactoryProducts",
                principalColumn: "Id");
        }
    }
}
