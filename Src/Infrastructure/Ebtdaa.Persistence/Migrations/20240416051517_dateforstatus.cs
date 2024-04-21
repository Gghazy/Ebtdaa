using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class dateforstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "CreatedBy",
                table: "InspectorFactories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "InspectorFactories");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "InspectorFactories");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "InspectorFactories");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedAt",
                table: "FactoryUpdateStatuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DataStatus",
                table: "FactoryUpdateStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EnteredAt",
                table: "FactoryUpdateStatuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewedAt",
                table: "FactoryUpdateStatuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedAt",
                table: "FactoryUpdateStatuses");

            migrationBuilder.DropColumn(
                name: "DataStatus",
                table: "FactoryUpdateStatuses");

            migrationBuilder.DropColumn(
                name: "EnteredAt",
                table: "FactoryUpdateStatuses");

            migrationBuilder.DropColumn(
                name: "ReviewedAt",
                table: "FactoryUpdateStatuses");

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

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "InspectorFactories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "InspectorFactories",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "InspectorFactories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "InspectorFactories",
                type: "smalldatetime",
                nullable: true);
        }
    }
}
