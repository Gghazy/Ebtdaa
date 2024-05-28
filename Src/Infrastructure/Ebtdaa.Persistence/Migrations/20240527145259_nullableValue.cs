using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class nullableValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryFinancialAttachments_FactoryFinancials_FactoryFinancialId",
                table: "FactoryFinancialAttachments");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryFinancialId",
                table: "FactoryFinancialAttachments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryFinancialAttachments_FactoryFinancials_FactoryFinancialId",
                table: "FactoryFinancialAttachments",
                column: "FactoryFinancialId",
                principalTable: "FactoryFinancials",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryFinancialAttachments_FactoryFinancials_FactoryFinancialId",
                table: "FactoryFinancialAttachments");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryFinancialId",
                table: "FactoryFinancialAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryFinancialAttachments_FactoryFinancials_FactoryFinancialId",
                table: "FactoryFinancialAttachments",
                column: "FactoryFinancialId",
                principalTable: "FactoryFinancials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
