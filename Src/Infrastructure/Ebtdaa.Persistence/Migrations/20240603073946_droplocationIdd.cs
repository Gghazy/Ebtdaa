using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class droplocationIdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
            name: "IX_FactoryLocationAttachments_FactoryLocationId",
            table: "FactoryLocationAttachments");
            migrationBuilder.DropColumn(
               name: "FactoryLocationId",
               table: "FactoryLocationAttachments");
          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
