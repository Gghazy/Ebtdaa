using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class fixConflict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sign",
                table: "Inspectors");

            migrationBuilder.DropColumn(
                name: "conversionToKG",
                table: "Inspectors");

            migrationBuilder.AlterColumn<int>(
                name: "conversionToKG",
                table: "Units",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Sign",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sign",
                table: "Units");

            migrationBuilder.AlterColumn<string>(
                name: "conversionToKG",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Sign",
                table: "Inspectors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "conversionToKG",
                table: "Inspectors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
