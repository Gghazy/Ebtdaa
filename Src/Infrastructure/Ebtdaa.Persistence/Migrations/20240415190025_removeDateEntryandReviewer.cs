using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class removeDateEntryandReviewer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateApprove",
                table: "BasicFactoryInfos");

            migrationBuilder.DropColumn(
                name: "EnterDate",
                table: "BasicFactoryInfos");

            migrationBuilder.DropColumn(
                name: "ReviewDate",
                table: "BasicFactoryInfos");

            migrationBuilder.AddColumn<int>(
                name: "DataStatus",
                table: "Periods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateApprove",
                table: "Periods",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EnterDate",
                table: "Periods",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewDate",
                table: "Periods",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "FactoryLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "FactoryContacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocations_PeriodId",
                table: "FactoryLocations",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryFiles_PeriodId",
                table: "FactoryFiles",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryContacts_PeriodId",
                table: "FactoryContacts",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryContacts_Periods_PeriodId",
                table: "FactoryContacts",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryFiles_Periods_PeriodId",
                table: "FactoryFiles",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryLocations_Periods_PeriodId",
                table: "FactoryLocations",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FactoryContacts_Periods_PeriodId",
                table: "FactoryContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_FactoryFiles_Periods_PeriodId",
                table: "FactoryFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_FactoryLocations_Periods_PeriodId",
                table: "FactoryLocations");

            migrationBuilder.DropIndex(
                name: "IX_FactoryLocations_PeriodId",
                table: "FactoryLocations");

            migrationBuilder.DropIndex(
                name: "IX_FactoryFiles_PeriodId",
                table: "FactoryFiles");

            migrationBuilder.DropIndex(
                name: "IX_FactoryContacts_PeriodId",
                table: "FactoryContacts");

            migrationBuilder.DropColumn(
                name: "DataStatus",
                table: "Periods");

            migrationBuilder.DropColumn(
                name: "DateApprove",
                table: "Periods");

            migrationBuilder.DropColumn(
                name: "EnterDate",
                table: "Periods");

            migrationBuilder.DropColumn(
                name: "ReviewDate",
                table: "Periods");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "FactoryLocations");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "FactoryContacts");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateApprove",
                table: "BasicFactoryInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EnterDate",
                table: "BasicFactoryInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewDate",
                table: "BasicFactoryInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
