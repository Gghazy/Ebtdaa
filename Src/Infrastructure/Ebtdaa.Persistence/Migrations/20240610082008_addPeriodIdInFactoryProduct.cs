using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class addPeriodIdInFactoryProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<int>(
                name: "periodId",
                table: "FactoryProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductPeriodActives_FactoryId",
                table: "ProductPeriodActives",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryProducts_periodId",
                table: "FactoryProducts",
                column: "periodId");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryProducts_Periods_periodId",
                table: "FactoryProducts",
                column: "periodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPeriodActives_Factories_FactoryId",
                table: "ProductPeriodActives",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryProducts_Periods_periodId",
                table: "FactoryProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPeriodActives_Factories_FactoryId",
                table: "ProductPeriodActives");

            migrationBuilder.DropIndex(
                name: "IX_ProductPeriodActives_FactoryId",
                table: "ProductPeriodActives");

            migrationBuilder.DropIndex(
                name: "IX_FactoryProducts_periodId",
                table: "FactoryProducts");

            migrationBuilder.DropColumn(
                name: "periodId",
                table: "FactoryProducts");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "smalldatetime",
                nullable: true);
        }
    }
}
