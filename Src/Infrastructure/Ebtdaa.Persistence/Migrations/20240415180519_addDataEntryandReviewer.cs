using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class addDataEntryandReviewer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataApprover",
                table: "BasicFactoryInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataEntry",
                table: "BasicFactoryInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataReviewer",
                table: "BasicFactoryInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataApprover",
                table: "BasicFactoryInfos");

            migrationBuilder.DropColumn(
                name: "DataEntry",
                table: "BasicFactoryInfos");

            migrationBuilder.DropColumn(
                name: "DataReviewer",
                table: "BasicFactoryInfos");

            migrationBuilder.DropColumn(
                name: "DateApprove",
                table: "BasicFactoryInfos");

            migrationBuilder.DropColumn(
                name: "EnterDate",
                table: "BasicFactoryInfos");

            migrationBuilder.DropColumn(
                name: "ReviewDate",
                table: "BasicFactoryInfos");
        }
    }
}
