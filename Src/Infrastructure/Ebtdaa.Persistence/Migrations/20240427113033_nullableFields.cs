using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class nullableFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectActualProductions_Units_ActualProductionUintId",
                table: "InspectActualProductions");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectActualProductions_Units_DesignedCapacityUnitId",
                table: "InspectActualProductions");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectProductPhotos_Attachments_PhotoId",
                table: "InspectProductPhotos");
           

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "InspectProductPhotos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "InspectProductDataAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "InspectProductDataAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0);

                  

            migrationBuilder.AlterColumn<string>(
                name: "OwnerIdentity",
                table: "InspectBasicFactoryInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "FactoryStatus",
                table: "InspectBasicFactoryInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FactoryName",
                table: "InspectBasicFactoryInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DesignedCapacityUnitId",
                table: "InspectActualProductions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DesignedCapacity",
                table: "InspectActualProductions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActualProductionUintId",
                table: "InspectActualProductions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActualProduction",
                table: "InspectActualProductions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "InspectActualProductions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CorrectActualProduction",
                table: "InspectActualProductions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CorrectDesignedCapacity",
                table: "InspectActualProductions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActualProductionCorrect",
                table: "InspectActualProductions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDesignedCapacityCorrect",
                table: "InspectActualProductions",
                type: "bit",
                nullable: false,
                defaultValue: false);

           
       
            migrationBuilder.CreateIndex(
                name: "IX_InspectProductDataAttachments_FactoryId",
                table: "InspectProductDataAttachments",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectProductDataAttachments_PeriodId",
                table: "InspectProductDataAttachments",
                column: "PeriodId");


            migrationBuilder.AddForeignKey(
                name: "FK_InspectActualProductions_Units_ActualProductionUintId",
                table: "InspectActualProductions",
                column: "ActualProductionUintId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectActualProductions_Units_DesignedCapacityUnitId",
                table: "InspectActualProductions",
                column: "DesignedCapacityUnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            
            migrationBuilder.AddForeignKey(
                name: "FK_InspectProductDataAttachments_Factories_FactoryId",
                table: "InspectProductDataAttachments",
                column: "FactoryId",
                principalTable: "Factories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectProductDataAttachments_Periods_PeriodId",
                table: "InspectProductDataAttachments",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectProductPhotos_Attachments_PhotoId",
                table: "InspectProductPhotos",
                column: "PhotoId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectActualProductions_Units_ActualProductionUintId",
                table: "InspectActualProductions");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectActualProductions_Units_DesignedCapacityUnitId",
                table: "InspectActualProductions");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectorRawMaterials_Factories_FactoryId",
                table: "InspectorRawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectorRawMaterials_Periods_PeriodId",
                table: "InspectorRawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspectors_FactoryEntities_FactoryEntityId",
                table: "Inspectors");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectProductDataAttachments_Factories_FactoryId",
                table: "InspectProductDataAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectProductDataAttachments_Periods_PeriodId",
                table: "InspectProductDataAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectProductPhotos_Attachments_PhotoId",
                table: "InspectProductPhotos");

            migrationBuilder.DropTable(
                name: "InspectorRawMaterialFiles");

            migrationBuilder.DropIndex(
                name: "IX_InspectProductDataAttachments_FactoryId",
                table: "InspectProductDataAttachments");

            migrationBuilder.DropIndex(
                name: "IX_InspectProductDataAttachments_PeriodId",
                table: "InspectProductDataAttachments");

            migrationBuilder.DropIndex(
                name: "IX_Inspectors_FactoryEntityId",
                table: "Inspectors");

            migrationBuilder.DropIndex(
                name: "IX_InspectorRawMaterials_FactoryId",
                table: "InspectorRawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_InspectorRawMaterials_PeriodId",
                table: "InspectorRawMaterials");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "InspectProductDataAttachments");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "InspectProductDataAttachments");

            migrationBuilder.DropColumn(
                name: "FactoryEntityId",
                table: "Inspectors");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "InspectorRawMaterials");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "InspectorRawMaterials");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "InspectFactoryContacts");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "InspectActualProductions");

            migrationBuilder.DropColumn(
                name: "CorrectActualProduction",
                table: "InspectActualProductions");

            migrationBuilder.DropColumn(
                name: "CorrectDesignedCapacity",
                table: "InspectActualProductions");

            migrationBuilder.DropColumn(
                name: "IsActualProductionCorrect",
                table: "InspectActualProductions");

            migrationBuilder.DropColumn(
                name: "IsDesignedCapacityCorrect",
                table: "InspectActualProductions");

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

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "InspectProductPhotos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<string>(
                name: "OwnerIdentity",
                table: "InspectBasicFactoryInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FactoryStatus",
                table: "InspectBasicFactoryInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FactoryName",
                table: "InspectBasicFactoryInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DesignedCapacityUnitId",
                table: "InspectActualProductions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DesignedCapacity",
                table: "InspectActualProductions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActualProductionUintId",
                table: "InspectActualProductions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActualProduction",
                table: "InspectActualProductions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectActualProductions_Units_ActualProductionUintId",
                table: "InspectActualProductions",
                column: "ActualProductionUintId",
                principalTable: "Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectActualProductions_Units_DesignedCapacityUnitId",
                table: "InspectActualProductions",
                column: "DesignedCapacityUnitId",
                principalTable: "Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectProductPhotos_Attachments_PhotoId",
                table: "InspectProductPhotos",
                column: "PhotoId",
                principalTable: "Attachments",
                principalColumn: "Id");
        }
    }
}
