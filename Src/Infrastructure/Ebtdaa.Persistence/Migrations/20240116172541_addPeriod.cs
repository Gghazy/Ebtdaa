using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class addPeriod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Factories_FactoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "FactoryId",
                table: "Products",
                newName: "FactoryProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_FactoryId",
                table: "Products",
                newName: "IX_Products_FactoryProductId");

            migrationBuilder.CreateTable(
                name: "FactoryProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodStartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_FactoryProducts_FactoryProductId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "FactoryProducts");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.RenameColumn(
                name: "FactoryProductId",
                table: "Products",
                newName: "FactoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_FactoryProductId",
                table: "Products",
                newName: "IX_Products_FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Factories_FactoryId",
                table: "Products",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id");
        }
    }
}
