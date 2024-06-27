using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class newdbb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
    name: "CR",
    table: "Products",
    type: "nvarchar(max)",
    nullable: false,
    defaultValue: "",
    oldClrType: typeof(string),
    oldType: "nvarchar(max)",
    oldNullable: true);
            migrationBuilder.AlterColumn<string>(
               name: "WebSite",
               table: "FactoryLocations",
               type: "nvarchar(max)",
               nullable: true,
               oldClrType: typeof(string),
               oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "IndustrialAreaId",
                table: "FactoryLocations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryEntityId",
                table: "FactoryLocations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "FactoryLocations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
