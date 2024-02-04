using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class add_Reason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reason",
                table: "IncreaseActualProductions");

            migrationBuilder.AddColumn<int>(
                name: "ReasonId",
                table: "IncreaseActualProductions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Reasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reasons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncreaseActualProductions_ReasonId",
                table: "IncreaseActualProductions",
                column: "ReasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncreaseActualProductions_Reasons_ReasonId",
                table: "IncreaseActualProductions",
                column: "ReasonId",
                principalTable: "Reasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncreaseActualProductions_Reasons_ReasonId",
                table: "IncreaseActualProductions");

            migrationBuilder.DropTable(
                name: "Reasons");

            migrationBuilder.DropIndex(
                name: "IX_IncreaseActualProductions_ReasonId",
                table: "IncreaseActualProductions");

            migrationBuilder.DropColumn(
                name: "ReasonId",
                table: "IncreaseActualProductions");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "IncreaseActualProductions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
