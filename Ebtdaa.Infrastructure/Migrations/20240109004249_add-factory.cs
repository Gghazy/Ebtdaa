using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Infrastructure.Migrations
{
    public partial class addfactory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FactoryIntegrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactoryName_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactoryName_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerIdentity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactoryNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseExpirDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryIntegrations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactoryIntegrations");
        }
    }
}
