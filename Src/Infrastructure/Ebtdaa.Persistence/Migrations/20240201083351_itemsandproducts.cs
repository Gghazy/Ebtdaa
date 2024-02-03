using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class itemsandproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropForeignKey(
                name: "FK_ActualRawMaterialFiles_ActualRawMaterials_ActualRawMaterialId",
                table: "ActualRawMaterialFiles");

           
           
           
            migrationBuilder.DropIndex(
                name: "IX_ActualRawMaterialFiles_ActualRawMaterialId",
                table: "ActualRawMaterialFiles");

         


           
           
            migrationBuilder.RenameColumn(
                name: "ActualRawMaterialId",
                table: "ActualRawMaterialFiles",
                newName: "Month");

           
            
          
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ActualRawMaterialFiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ActualRawMaterialFiles",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "ActualRawMaterialFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ActualRawMaterialFiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ActualRawMaterialFiles",
                type: "smalldatetime",
                nullable: true);

          

            migrationBuilder.CreateIndex(
                name: "IX_ActualRawMaterialFiles_FactoryId",
                table: "ActualRawMaterialFiles",
                column: "FactoryId");


            migrationBuilder.AddForeignKey(
                name: "FK_ActualRawMaterialFiles_Factories_FactoryId",
                table: "ActualRawMaterialFiles",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActualProductionAndCapacities_Products_ProductId",
                table: "ActualProductionAndCapacities");

            migrationBuilder.DropForeignKey(
                name: "FK_ActualProductionAndCapacities_Units_ActualProductionUintId",
                table: "ActualProductionAndCapacities");

            migrationBuilder.DropForeignKey(
                name: "FK_ActualProductionAndCapacities_Units_DesignedCapacityUnitId",
                table: "ActualProductionAndCapacities");

            migrationBuilder.DropForeignKey(
                name: "FK_ActualRawMaterialFiles_Factories_FactoryId",
                table: "ActualRawMaterialFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Factories_FactoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_ParentId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Units_UnitId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FactoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UnitId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ActualRawMaterialFiles_FactoryId",
                table: "ActualRawMaterialFiles");

            migrationBuilder.DropIndex(
                name: "IX_ActualProductionAndCapacities_ActualProductionUintId",
                table: "ActualProductionAndCapacities");

            migrationBuilder.DropIndex(
                name: "IX_ActualProductionAndCapacities_DesignedCapacityUnitId",
                table: "ActualProductionAndCapacities");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Kilograms_Per_Unit",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Level12Number",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Review",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ActualRawMaterialFiles");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ActualRawMaterialFiles");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "ActualRawMaterialFiles");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ActualRawMaterialFiles");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ActualRawMaterialFiles");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Products",
                newName: "FactoryProductId");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Products",
                newName: "CustomItemId_12");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ParentId",
                table: "Products",
                newName: "IX_Products_FactoryProductId");

            migrationBuilder.RenameColumn(
                name: "Month",
                table: "ActualRawMaterialFiles",
                newName: "ActualRawMaterialId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ActualProductionAndCapacities",
                newName: "FactoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ActualProductionAndCapacities_ProductId",
                table: "ActualProductionAndCapacities",
                newName: "IX_ActualProductionAndCapacities_FactoryId");

            migrationBuilder.AddColumn<int>(
                name: "ActualProductionAndCapacityId",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActualProductionAndCapacityId",
                table: "ReasonIncreasCapacities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomItemId_12",
                table: "ActualProductionAndCapacities",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_Units_ActualProductionAndCapacityId",
                table: "Units",
                column: "ActualProductionAndCapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ProductId",
                table: "Units",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonIncreasCapacities_ActualProductionAndCapacityId",
                table: "ReasonIncreasCapacities",
                column: "ActualProductionAndCapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualRawMaterialFiles_ActualRawMaterialId",
                table: "ActualRawMaterialFiles",
                column: "ActualRawMaterialId");

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
                name: "FK_ActualProductionAndCapacities_Factories_FactoryId",
                table: "ActualProductionAndCapacities",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActualRawMaterialFiles_ActualRawMaterials_ActualRawMaterialId",
                table: "ActualRawMaterialFiles",
                column: "ActualRawMaterialId",
                principalTable: "ActualRawMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FactoryProducts_FactoryProductId",
                table: "Products",
                column: "FactoryProductId",
                principalTable: "FactoryProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReasonIncreasCapacities_ActualProductionAndCapacities_ActualProductionAndCapacityId",
                table: "ReasonIncreasCapacities",
                column: "ActualProductionAndCapacityId",
                principalTable: "ActualProductionAndCapacities",
                principalColumn: "Id");

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
    }
}
