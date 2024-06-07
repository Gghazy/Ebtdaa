using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialRegister = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactoryNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseExpirDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactoryEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MappingProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hs10Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hs10NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hs10NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hs12Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hs12NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hs12NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MappingProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MappingUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HS6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitOfMeasurement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MappingUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DialCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    E164Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternationalNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReasonIncreasCapacities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonIncreasCapacities", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitOfMeasurement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActualProductionAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualProductionAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualProductionAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActualProductionAttachments_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActualRawMaterialFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualRawMaterialFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualRawMaterialFiles_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActualRawMaterialFiles_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomsItemUpdates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    ActiveProductsCount = table.Column<int>(type: "int", nullable: false),
                    IsActiveProduct = table.Column<bool>(type: "bit", nullable: false),
                    CustomsItem10_Id = table.Column<int>(type: "int", nullable: false),
                    CustomsItem12_Id = table.Column<int>(type: "int", nullable: false),
                    ValidtyCustomsClassification = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomsItemUpdates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomsItemUpdates_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactoryFinancials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Revenues = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WaterExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ElectricityExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FuelExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RawMterialExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmploymentExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherOperatingExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Assets = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NonCurrentAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NonCurrentLiabilities = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryFinancials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactoryFinancials_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectActualProductionAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectActualProductionAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectActualProductionAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectActualProductionAttachments_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectFactoryFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectFactoryFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectFactoryFiles_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectFactoryFiles_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectFactoryLocationAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectFactoryLocationAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectFactoryLocationAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectFactoryLocationAttachments_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityCode = table.Column<int>(type: "int", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactoryEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_FactoryEntities_FactoryEntityId",
                        column: x => x.FactoryEntityId,
                        principalTable: "FactoryEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inspectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerIdentity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactoryEntityId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspectors_FactoryEntities_FactoryEntityId",
                        column: x => x.FactoryEntityId,
                        principalTable: "FactoryEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasicFactoryInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    FactoryStatusId = table.Column<int>(type: "int", nullable: false),
                    DataEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataReviewer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataApprover = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicFactoryInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasicFactoryInfos_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasicFactoryInfos_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactoryFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactoryFiles_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactoryFiles_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactoryFiles_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactoryMonthlyFinancials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaterExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ElectricityExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FuelExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RawMterialExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmploymentExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherOperatingExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryMonthlyFinancials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactoryMonthlyFinancials_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactoryMonthlyFinancials_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactoryUpdateStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    UpdateStatus = table.Column<bool>(type: "bit", nullable: false),
                    EnteredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryUpdateStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactoryUpdateStatuses_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactoryUpdateStatuses_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectBasicFactoryInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    IsFactNameCorrect = table.Column<bool>(type: "bit", nullable: false),
                    IsFactStatusCorrect = table.Column<bool>(type: "bit", nullable: false),
                    FactoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectFactoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectFactoryStatus = table.Column<int>(type: "int", nullable: true),
                    FactoryStatus = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectBasicFactoryInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectBasicFactoryInfos_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectBasicFactoryInfos_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectFactoryContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    OldOfficerPhoneId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldOfficerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOfficerPhoneCorrect = table.Column<bool>(type: "bit", nullable: false),
                    IsOfficerMailCorrect = table.Column<bool>(type: "bit", nullable: false),
                    NewOfficerPhoneId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewOfficerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "InspectorUpdateStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    UpdateStatus = table.Column<bool>(type: "bit", nullable: false),
                    EnteredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectorUpdateStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectorUpdateStatuses_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectorUpdateStatuses_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScreenStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: true),
                    ScreenStatusId = table.Column<int>(type: "int", nullable: false),
                    UpdateStatus = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScreenStatuses_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScreenStatuses_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FactoryContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficerPhoneId = table.Column<int>(type: "int", nullable: false),
                    OfficerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionManagerPhoneId = table.Column<int>(type: "int", nullable: false),
                    ProductionManagerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinanceManagerPhoneId = table.Column<int>(type: "int", nullable: false),
                    FinanceManagerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactoryContacts_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactoryContacts_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactoryContacts_Phone_FinanceManagerPhoneId",
                        column: x => x.FinanceManagerPhoneId,
                        principalTable: "Phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactoryContacts_Phone_OfficerPhoneId",
                        column: x => x.OfficerPhoneId,
                        principalTable: "Phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactoryContacts_Phone_ProductionManagerPhoneId",
                        column: x => x.ProductionManagerPhoneId,
                        principalTable: "Phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncreaseActualProductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    ReasonId = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncreaseActualProductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncreaseActualProductions_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncreaseActualProductions_Reasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "Reasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Review = table.Column<bool>(type: "bit", nullable: true),
                    Level12Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level12ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kilograms_Per_Unit = table.Column<double>(type: "float", nullable: true),
                    FactoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RawMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaximumMonthlyConsumption = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    AverageWeightKG = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoId = table.Column<int>(type: "int", nullable: true),
                    PaperId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RawMaterials_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RawMaterials_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RawMaterials_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactoryFinancialAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    FactoryFinancialId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryFinancialAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactoryFinancialAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactoryFinancialAttachments_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactoryFinancialAttachments_FactoryFinancials_FactoryFinancialId",
                        column: x => x.FactoryFinancialId,
                        principalTable: "FactoryFinancials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FactoryFinancialAttachments_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndustrialAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustrialAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndustrialAreas_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectorFactories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    InspectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectorFactories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectorFactories_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectorFactories_Inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "Inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactoryProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeperId = table.Column<int>(type: "int", nullable: true),
                    PhototId = table.Column<int>(type: "int", nullable: true),
                    CommericalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactoryProducts_Attachments_PeperId",
                        column: x => x.PeperId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactoryProducts_Attachments_PhototId",
                        column: x => x.PhototId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactoryProducts_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactoryProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectProductDataAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectProductDataAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectProductDataAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectProductDataAttachments_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectProductDataAttachments_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectProductDataAttachments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectProductPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    PhotoId = table.Column<int>(type: "int", nullable: false),
                    PaperId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IsProductPhotoCorrect = table.Column<bool>(type: "bit", nullable: false),
                    NewProductPhotoId = table.Column<int>(type: "int", nullable: true),
                    NewProductPaperId = table.Column<int>(type: "int", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommericalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectProductPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectProductPhotos_Attachments_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectProductPhotos_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectProductPhotos_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectProductPhotos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActualRawMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    RawMaterialId = table.Column<int>(type: "int", nullable: false),
                    CurrentStockQuantity_KG = table.Column<double>(type: "float", nullable: false),
                    UsedQuantity_KG = table.Column<double>(type: "float", nullable: false),
                    IncreasedUsageReason = table.Column<double>(type: "float", nullable: false),
                    UsedQuantity = table.Column<double>(type: "float", nullable: false),
                    CurrentStockQuantity = table.Column<double>(type: "float", nullable: false),
                    StockUnitId = table.Column<int>(type: "int", nullable: false),
                    UsageUnitId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualRawMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualRawMaterials_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ActualRawMaterials_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "InspectorRawMaterialFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RawMaterialId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectorRawMaterialFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectorRawMaterialFiles_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InspectorRawMaterialFiles_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InspectorRawMaterialFiles_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "InspectorRawMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    RawMaterialId = table.Column<int>(type: "int", nullable: false),
                    IsImageClear = table.Column<bool>(type: "bit", nullable: false),
                    IsPaperClear = table.Column<bool>(type: "bit", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoId = table.Column<int>(type: "int", nullable: false),
                    PaperId = table.Column<int>(type: "int", nullable: false),
                    CorrectPhotoId = table.Column<int>(type: "int", nullable: true),
                    CorrectPaperId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectorRawMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectorRawMaterials_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InspectorRawMaterials_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InspectorRawMaterials_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProductRawMaterials",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    rawMaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRawMaterials", x => new { x.ProductId, x.rawMaterialId });
                    table.ForeignKey(
                        name: "FK_ProductRawMaterials_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductRawMaterials_RawMaterials_rawMaterialId",
                        column: x => x.rawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RawMaterialAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    RawMaterialId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterialAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RawMaterialAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RawMaterialAttachments_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactoryLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryEntityId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    IndustrialAreaId = table.Column<int>(type: "int", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactoryLocations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactoryLocations_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactoryLocations_FactoryEntities_FactoryEntityId",
                        column: x => x.FactoryEntityId,
                        principalTable: "FactoryEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactoryLocations_IndustrialAreas_IndustrialAreaId",
                        column: x => x.IndustrialAreaId,
                        principalTable: "IndustrialAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FactoryLocations_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectFactoryLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    FactoryEntityId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    IndustrialAreaId = table.Column<int>(type: "int", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFactoryEntityCorrect = table.Column<bool>(type: "bit", nullable: false),
                    IsCityCorrect = table.Column<bool>(type: "bit", nullable: false),
                    IsIndustrialAreaCorrect = table.Column<bool>(type: "bit", nullable: false),
                    IsWebSiteCorrect = table.Column<bool>(type: "bit", nullable: false),
                    NewFactoryEntityId = table.Column<int>(type: "int", nullable: true),
                    NewCityId = table.Column<int>(type: "int", nullable: true),
                    NewIndustrialAreaId = table.Column<int>(type: "int", nullable: true),
                    NewWebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectFactoryLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectFactoryLocations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InspectFactoryLocations_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InspectFactoryLocations_FactoryEntities_FactoryEntityId",
                        column: x => x.FactoryEntityId,
                        principalTable: "FactoryEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InspectFactoryLocations_IndustrialAreas_IndustrialAreaId",
                        column: x => x.IndustrialAreaId,
                        principalTable: "IndustrialAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InspectFactoryLocations_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ActualProductionAndCapacities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryProductId = table.Column<int>(type: "int", nullable: false),
                    DesignedCapacity = table.Column<int>(type: "int", nullable: true),
                    DesignedCapacityUnitId = table.Column<int>(type: "int", nullable: true),
                    ActualProduction = table.Column<int>(type: "int", nullable: true),
                    ActualProductionUintId = table.Column<int>(type: "int", nullable: true),
                    ActualProductionWeight = table.Column<int>(type: "int", nullable: true),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualProductionAndCapacities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualProductionAndCapacities_FactoryProducts_FactoryProductId",
                        column: x => x.FactoryProductId,
                        principalTable: "FactoryProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActualProductionAndCapacities_Units_ActualProductionUintId",
                        column: x => x.ActualProductionUintId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActualProductionAndCapacities_Units_DesignedCapacityUnitId",
                        column: x => x.DesignedCapacityUnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectActualProductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryProductId = table.Column<int>(type: "int", nullable: false),
                    DesignedCapacity = table.Column<int>(type: "int", nullable: false),
                    ActualProduction = table.Column<int>(type: "int", nullable: false),
                    DesignedCapacityUnitId = table.Column<int>(type: "int", nullable: false),
                    ActualProductionUintId = table.Column<int>(type: "int", nullable: false),
                    IsDesignedCapacityCorrect = table.Column<bool>(type: "bit", nullable: false),
                    IsActualProductionCorrect = table.Column<bool>(type: "bit", nullable: false),
                    CorrectDesignedCapacity = table.Column<int>(type: "int", nullable: true),
                    CorrectActualProduction = table.Column<int>(type: "int", nullable: true),
                    IncreaseReasonId = table.Column<int>(type: "int", nullable: false),
                    IncreaseReasonCorrect = table.Column<int>(type: "int", nullable: true),
                    IsIncreaseReasonCorrect = table.Column<bool>(type: "bit", nullable: false),
                    ActualProductionWeight = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectActualProductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectActualProductions_FactoryProducts_FactoryProductId",
                        column: x => x.FactoryProductId,
                        principalTable: "FactoryProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InspectActualProductions_Units_ActualProductionUintId",
                        column: x => x.ActualProductionUintId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InspectActualProductions_Units_DesignedCapacityUnitId",
                        column: x => x.DesignedCapacityUnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProductPeriodActives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryProductId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPeriodActives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPeriodActives_FactoryProducts_FactoryProductId",
                        column: x => x.FactoryProductId,
                        principalTable: "FactoryProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPeriodActives_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactoryLocationAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    FactoryLocationId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryLocationAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactoryLocationAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactoryLocationAttachments_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactoryLocationAttachments_FactoryLocations_FactoryLocationId",
                        column: x => x.FactoryLocationId,
                        principalTable: "FactoryLocations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FactoryLocationAttachments_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActualProductionAndCapacities_ActualProductionUintId",
                table: "ActualProductionAndCapacities",
                column: "ActualProductionUintId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualProductionAndCapacities_DesignedCapacityUnitId",
                table: "ActualProductionAndCapacities",
                column: "DesignedCapacityUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualProductionAndCapacities_FactoryProductId",
                table: "ActualProductionAndCapacities",
                column: "FactoryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualProductionAttachments_AttachmentId",
                table: "ActualProductionAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualProductionAttachments_FactoryId",
                table: "ActualProductionAttachments",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualRawMaterialFiles_AttachmentId",
                table: "ActualRawMaterialFiles",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualRawMaterialFiles_FactoryId",
                table: "ActualRawMaterialFiles",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualRawMaterials_PeriodId",
                table: "ActualRawMaterials",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualRawMaterials_RawMaterialId",
                table: "ActualRawMaterials",
                column: "RawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_BasicFactoryInfos_FactoryId",
                table: "BasicFactoryInfos",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BasicFactoryInfos_PeriodId",
                table: "BasicFactoryInfos",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_FactoryEntityId",
                table: "Cities",
                column: "FactoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomsItemUpdates_FactoryId",
                table: "CustomsItemUpdates",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryContacts_FactoryId",
                table: "FactoryContacts",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryContacts_FinanceManagerPhoneId",
                table: "FactoryContacts",
                column: "FinanceManagerPhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryContacts_OfficerPhoneId",
                table: "FactoryContacts",
                column: "OfficerPhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryContacts_PeriodId",
                table: "FactoryContacts",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryContacts_ProductionManagerPhoneId",
                table: "FactoryContacts",
                column: "ProductionManagerPhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryFiles_AttachmentId",
                table: "FactoryFiles",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryFiles_FactoryId",
                table: "FactoryFiles",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryFiles_PeriodId",
                table: "FactoryFiles",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryFinancialAttachments_AttachmentId",
                table: "FactoryFinancialAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryFinancialAttachments_FactoryFinancialId",
                table: "FactoryFinancialAttachments",
                column: "FactoryFinancialId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryFinancialAttachments_FactoryId",
                table: "FactoryFinancialAttachments",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryFinancialAttachments_PeriodId",
                table: "FactoryFinancialAttachments",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryFinancials_FactoryId",
                table: "FactoryFinancials",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocationAttachments_AttachmentId",
                table: "FactoryLocationAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocationAttachments_FactoryId",
                table: "FactoryLocationAttachments",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocationAttachments_FactoryLocationId",
                table: "FactoryLocationAttachments",
                column: "FactoryLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocationAttachments_PeriodId",
                table: "FactoryLocationAttachments",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocations_CityId",
                table: "FactoryLocations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocations_FactoryEntityId",
                table: "FactoryLocations",
                column: "FactoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocations_FactoryId",
                table: "FactoryLocations",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocations_IndustrialAreaId",
                table: "FactoryLocations",
                column: "IndustrialAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocations_PeriodId",
                table: "FactoryLocations",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryMonthlyFinancials_FactoryId",
                table: "FactoryMonthlyFinancials",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryMonthlyFinancials_PeriodId",
                table: "FactoryMonthlyFinancials",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryProducts_FactoryId",
                table: "FactoryProducts",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryProducts_PeperId",
                table: "FactoryProducts",
                column: "PeperId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryProducts_PhototId",
                table: "FactoryProducts",
                column: "PhototId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryProducts_ProductId",
                table: "FactoryProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryUpdateStatuses_FactoryId",
                table: "FactoryUpdateStatuses",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryUpdateStatuses_PeriodId",
                table: "FactoryUpdateStatuses",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_IncreaseActualProductions_FactoryId",
                table: "IncreaseActualProductions",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IncreaseActualProductions_ReasonId",
                table: "IncreaseActualProductions",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_IndustrialAreas_CityId",
                table: "IndustrialAreas",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectActualProductionAttachments_AttachmentId",
                table: "InspectActualProductionAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectActualProductionAttachments_FactoryId",
                table: "InspectActualProductionAttachments",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectActualProductions_ActualProductionUintId",
                table: "InspectActualProductions",
                column: "ActualProductionUintId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectActualProductions_DesignedCapacityUnitId",
                table: "InspectActualProductions",
                column: "DesignedCapacityUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectActualProductions_FactoryProductId",
                table: "InspectActualProductions",
                column: "FactoryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectBasicFactoryInfos_FactoryId",
                table: "InspectBasicFactoryInfos",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectBasicFactoryInfos_PeriodId",
                table: "InspectBasicFactoryInfos",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryContacts_FactoryId",
                table: "InspectFactoryContacts",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryContacts_PeriodId",
                table: "InspectFactoryContacts",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryFiles_AttachmentId",
                table: "InspectFactoryFiles",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryFiles_FactoryId",
                table: "InspectFactoryFiles",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryLocationAttachments_AttachmentId",
                table: "InspectFactoryLocationAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryLocationAttachments_FactoryId",
                table: "InspectFactoryLocationAttachments",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryLocations_CityId",
                table: "InspectFactoryLocations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryLocations_FactoryEntityId",
                table: "InspectFactoryLocations",
                column: "FactoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryLocations_FactoryId",
                table: "InspectFactoryLocations",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryLocations_IndustrialAreaId",
                table: "InspectFactoryLocations",
                column: "IndustrialAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectFactoryLocations_PeriodId",
                table: "InspectFactoryLocations",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorFactories_FactoryId",
                table: "InspectorFactories",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorFactories_InspectorId",
                table: "InspectorFactories",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorRawMaterialFiles_AttachmentId",
                table: "InspectorRawMaterialFiles",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorRawMaterialFiles_FactoryId",
                table: "InspectorRawMaterialFiles",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorRawMaterialFiles_RawMaterialId",
                table: "InspectorRawMaterialFiles",
                column: "RawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorRawMaterials_FactoryId",
                table: "InspectorRawMaterials",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorRawMaterials_PeriodId",
                table: "InspectorRawMaterials",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorRawMaterials_RawMaterialId",
                table: "InspectorRawMaterials",
                column: "RawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspectors_FactoryEntityId",
                table: "Inspectors",
                column: "FactoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorUpdateStatuses_FactoryId",
                table: "InspectorUpdateStatuses",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectorUpdateStatuses_PeriodId",
                table: "InspectorUpdateStatuses",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectProductDataAttachments_AttachmentId",
                table: "InspectProductDataAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectProductDataAttachments_FactoryId",
                table: "InspectProductDataAttachments",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectProductDataAttachments_PeriodId",
                table: "InspectProductDataAttachments",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectProductDataAttachments_ProductId",
                table: "InspectProductDataAttachments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectProductPhotos_FactoryId",
                table: "InspectProductPhotos",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectProductPhotos_PeriodId",
                table: "InspectProductPhotos",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectProductPhotos_PhotoId",
                table: "InspectProductPhotos",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectProductPhotos_ProductId",
                table: "InspectProductPhotos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPeriodActives_FactoryProductId",
                table: "ProductPeriodActives",
                column: "FactoryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPeriodActives_PeriodId",
                table: "ProductPeriodActives",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRawMaterials_rawMaterialId",
                table: "ProductRawMaterials",
                column: "rawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FactoryId",
                table: "Products",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitId",
                table: "Products",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterialAttachments_AttachmentId",
                table: "RawMaterialAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterialAttachments_RawMaterialId",
                table: "RawMaterialAttachments",
                column: "RawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_FactoryId",
                table: "RawMaterials",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_PeriodId",
                table: "RawMaterials",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_UnitId",
                table: "RawMaterials",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenStatuses_FactoryId",
                table: "ScreenStatuses",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenStatuses_PeriodId",
                table: "ScreenStatuses",
                column: "PeriodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActualProductionAndCapacities");

            migrationBuilder.DropTable(
                name: "ActualProductionAttachments");

            migrationBuilder.DropTable(
                name: "ActualRawMaterialFiles");

            migrationBuilder.DropTable(
                name: "ActualRawMaterials");

            migrationBuilder.DropTable(
                name: "BasicFactoryInfos");

            migrationBuilder.DropTable(
                name: "CustomsItemUpdates");

            migrationBuilder.DropTable(
                name: "FactoryContacts");

            migrationBuilder.DropTable(
                name: "FactoryFiles");

            migrationBuilder.DropTable(
                name: "FactoryFinancialAttachments");

            migrationBuilder.DropTable(
                name: "FactoryLocationAttachments");

            migrationBuilder.DropTable(
                name: "FactoryMonthlyFinancials");

            migrationBuilder.DropTable(
                name: "FactoryUpdateStatuses");

            migrationBuilder.DropTable(
                name: "IncreaseActualProductions");

            migrationBuilder.DropTable(
                name: "InspectActualProductionAttachments");

            migrationBuilder.DropTable(
                name: "InspectActualProductions");

            migrationBuilder.DropTable(
                name: "InspectBasicFactoryInfos");

            migrationBuilder.DropTable(
                name: "InspectFactoryContacts");

            migrationBuilder.DropTable(
                name: "InspectFactoryFiles");

            migrationBuilder.DropTable(
                name: "InspectFactoryLocationAttachments");

            migrationBuilder.DropTable(
                name: "InspectFactoryLocations");

            migrationBuilder.DropTable(
                name: "InspectorFactories");

            migrationBuilder.DropTable(
                name: "InspectorRawMaterialFiles");

            migrationBuilder.DropTable(
                name: "InspectorRawMaterials");

            migrationBuilder.DropTable(
                name: "InspectorUpdateStatuses");

            migrationBuilder.DropTable(
                name: "InspectProductDataAttachments");

            migrationBuilder.DropTable(
                name: "InspectProductPhotos");

            migrationBuilder.DropTable(
                name: "MappingProducts");

            migrationBuilder.DropTable(
                name: "MappingUnits");

            migrationBuilder.DropTable(
                name: "ProductPeriodActives");

            migrationBuilder.DropTable(
                name: "ProductRawMaterials");

            migrationBuilder.DropTable(
                name: "RawMaterialAttachments");

            migrationBuilder.DropTable(
                name: "ReasonIncreasCapacities");

            migrationBuilder.DropTable(
                name: "ScreenStatuses");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "FactoryFinancials");

            migrationBuilder.DropTable(
                name: "FactoryLocations");

            migrationBuilder.DropTable(
                name: "Reasons");

            migrationBuilder.DropTable(
                name: "Inspectors");

            migrationBuilder.DropTable(
                name: "FactoryProducts");

            migrationBuilder.DropTable(
                name: "RawMaterials");

            migrationBuilder.DropTable(
                name: "IndustrialAreas");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Factories");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "FactoryEntities");
        }
    }
}
