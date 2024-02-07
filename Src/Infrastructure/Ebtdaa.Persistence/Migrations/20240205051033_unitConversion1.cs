using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class unitConversion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
              name: "conversionToKG",
              table: "Units",
              type: "int",
              nullable: false,
              oldClrType: typeof(string),
              oldType: "nvarchar(max)");

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "conversionToKG",
                table: "Units");
        }
    }
}
