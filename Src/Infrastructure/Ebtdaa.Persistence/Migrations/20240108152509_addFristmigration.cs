using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class addFristmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActualProductionAndCapacities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomItemId_12 = table.Column<int>(type: "int", nullable: false),
                    DesignedCapacity = table.Column<int>(type: "int", nullable: false),
                    DesignedCapacityUnitId = table.Column<int>(type: "int", nullable: false),
                    ActualProduction = table.Column<int>(type: "int", nullable: false),
                    ActualProductionUintId = table.Column<int>(type: "int", nullable: false),
                    ActualProductionWeight = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    ReasoneForIncreaseCapacity = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualProductionAndCapacities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualProductionAndCapacities_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomsItemUpdates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    ActiveProductsCount = table.Column<int>(type: "int", nullable: false),
                    IsActiveProduct = table.Column<bool>(type: "bit", nullable: false),
                    CustomsItem10_Id = table.Column<int>(type: "int", nullable: false),
                    CustomsItem12_Id = table.Column<int>(type: "int", nullable: false),
                    ValidtyCustomsClassification = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomsItemUpdates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomsItemUpdates_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomItemId_12 = table.Column<int>(type: "int", nullable: false),
                    CommericalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    WiegthInKgm = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReasonIncreasCapacities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActualProductionAndCapacityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonIncreasCapacities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReasonIncreasCapacities_ActualProductionAndCapacities_ActualProductionAndCapacityId",
                        column: x => x.ActualProductionAndCapacityId,
                        principalTable: "ActualProductionAndCapacities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomsItemLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    CustomsItemUpdateId = table.Column<int>(type: "int", nullable: true),
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
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActualProductionAndCapacityId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_ActualProductionAndCapacities_ActualProductionAndCapacityId",
                        column: x => x.ActualProductionAndCapacityId,
                        principalTable: "ActualProductionAndCapacities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Unit_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActualProductionAndCapacities_FactoryId",
                table: "ActualProductionAndCapacities",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomsItemLevels_CustomsItemUpdateId",
                table: "CustomsItemLevels",
                column: "CustomsItemUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomsItemLevels_ProductId",
                table: "CustomsItemLevels",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomsItemUpdates_FactoryId",
                table: "CustomsItemUpdates",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FactoryId",
                table: "Products",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonIncreasCapacities_ActualProductionAndCapacityId",
                table: "ReasonIncreasCapacities",
                column: "ActualProductionAndCapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_ActualProductionAndCapacityId",
                table: "Unit",
                column: "ActualProductionAndCapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_ProductId",
                table: "Unit",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomsItemLevels");

            migrationBuilder.DropTable(
                name: "ReasonIncreasCapacities");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "CustomsItemUpdates");

            migrationBuilder.DropTable(
                name: "ActualProductionAndCapacities");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
