using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class droplocationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "FK_FactoryLocationAttachments_FactoryLocations_FactoryLocationId",
               table: "FactoryLocationAttachments");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
