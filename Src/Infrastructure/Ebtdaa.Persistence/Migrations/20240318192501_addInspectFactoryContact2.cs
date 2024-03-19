using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class addInspectFactoryContact2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InspectFactoryContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    OldOfficerPhoneId = table.Column<int>(type: "int", nullable: false),
                    OldOfficerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOfficerPhoneCorrect = table.Column<bool>(type: "bit", nullable: false),
                    IsOfficerMailCorrect = table.Column<bool>(type: "bit", nullable: false),
                    NewOfficerPhoneId = table.Column<int>(type: "int", nullable: false),
                    NewOfficerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectFactoryContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectFactoryContacts_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectFactoryContacts_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryContacts_FactoryId",
                table: "InspectFactoryContacts",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryContacts_PeriodId",
                table: "InspectFactoryContacts",
                column: "PeriodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectFactoryContacts");
        }
    }
}
