using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Infrastructure.Migrations
{
    public partial class update_ProductIntegration_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeasureUnitID",
                table: "ProductIntegrations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasureUnitID",
                table: "ProductIntegrations");
        }
    }
}
