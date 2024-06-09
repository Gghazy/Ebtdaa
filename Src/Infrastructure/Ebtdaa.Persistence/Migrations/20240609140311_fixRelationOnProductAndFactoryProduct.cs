using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class fixRelationOnProductAndFactoryProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPeriodActives_FactoryProducts_FactoryProductId",
                table: "ProductPeriodActives");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryProductId",
                table: "ProductPeriodActives",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "ProductPeriodActives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductPeriodActives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductPeriodActives_ProductId",
                table: "ProductPeriodActives",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPeriodActives_FactoryProducts_FactoryProductId",
                table: "ProductPeriodActives",
                column: "FactoryProductId",
                principalTable: "FactoryProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPeriodActives_Products_ProductId",
                table: "ProductPeriodActives",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPeriodActives_FactoryProducts_FactoryProductId",
                table: "ProductPeriodActives");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPeriodActives_Products_ProductId",
                table: "ProductPeriodActives");

            migrationBuilder.DropIndex(
                name: "IX_ProductPeriodActives_ProductId",
                table: "ProductPeriodActives");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "ProductPeriodActives");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductPeriodActives");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryProductId",
                table: "ProductPeriodActives",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPeriodActives_FactoryProducts_FactoryProductId",
                table: "ProductPeriodActives",
                column: "FactoryProductId",
                principalTable: "FactoryProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
