using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class intial : Migration
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
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
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
                name: "IndustrialAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustrialAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeriodStartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActualProductionAndCapacities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomItemId_12 = table.Column<int>(type: "int", nullable: false),
                    DesignedCapacity = table.Column<int>(type: "int", nullable: false),
                    DesignedCapacityUnitId = table.Column<int>(type: "int", nullable: false),
                    ActualProduction = table.Column<int>(type: "int", nullable: false),
                    ActualProductionUintId = table.Column<int>(type: "int", nullable: false),
                    ActualProductionWeight = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    ReasoneForIncreaseCapacity = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualProductionAndCapacities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualProductionAndCapacities_Factories_FactoryId",
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
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false)
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
                name: "FactoryContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionManagerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionManagerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinanceManagerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinanceManagerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
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
                    FactoryId = table.Column<int>(type: "int", nullable: false)
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
                name: "FactoryProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactoryProducts_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id");
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactoryLocations_IndustrialAreas_IndustrialAreaId",
                        column: x => x.IndustrialAreaId,
                        principalTable: "IndustrialAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActualProductionAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    ActualProduvtionId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ActualProductionId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualProductionAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualProductionAttachments_ActualProductionAndCapacities_ActualProductionId",
                        column: x => x.ActualProductionId,
                        principalTable: "ActualProductionAndCapacities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActualProductionAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReasonIncreasCapacities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActualProductionAndCapacityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonIncreasCapacities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReasonIncreasCapacities_ActualProductionAndCapacities_ActualProductionAndCapacityId",
                        column: x => x.ActualProductionAndCapacityId,
                        principalTable: "ActualProductionAndCapacities",
                        principalColumn: "Id");
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
                    FactoryFinancialId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_FactoryFinancialAttachments_FactoryFinancials_FactoryFinancialId",
                        column: x => x.FactoryFinancialId,
                        principalTable: "FactoryFinancials",
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
                    CustomItemId_12 = table.Column<int>(type: "int", nullable: true),
                    CommericalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    WiegthInKgm = table.Column<int>(type: "int", nullable: true),
                    ProductCount = table.Column<int>(type: "int", nullable: true),
                    AnyNewProducts = table.Column<bool>(type: "bit", nullable: false),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactoryProductId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_FactoryProducts_FactoryProductId",
                        column: x => x.FactoryProductId,
                        principalTable: "FactoryProducts",
                        principalColumn: "Id");
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
                    FactoryLocationId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_FactoryLocationAttachments_FactoryLocations_FactoryLocationId",
                        column: x => x.FactoryLocationId,
                        principalTable: "FactoryLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomsItemLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    CustomsItemUpdateId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomsItemLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomsItemLevels_CustomsItemUpdates_CustomsItemUpdateId",
                        column: x => x.CustomsItemUpdateId,
                        principalTable: "CustomsItemUpdates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomsItemLevels_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttachments_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttachments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    AverageWeightKG = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RawMaterials_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RawMaterials_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RawMaterials_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActualProductionAndCapacityId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_ActualProductionAndCapacities_ActualProductionAndCapacityId",
                        column: x => x.ActualProductionAndCapacityId,
                        principalTable: "ActualProductionAndCapacities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Units_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActualRawMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", nullable: false),
                    RawMaterialId = table.Column<int>(type: "int", nullable: false),
                    CurrentStockQuantity_KG = table.Column<int>(type: "int", nullable: false),
                    UsedQuantity_KG = table.Column<int>(type: "int", nullable: false),
                    IncreasedUsageReason = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualRawMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualRawMaterials_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActualProductionAndCapacities_FactoryId",
                table: "ActualProductionAndCapacities",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualProductionAttachments_ActualProductionId",
                table: "ActualProductionAttachments",
                column: "ActualProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualProductionAttachments_AttachmentId",
                table: "ActualProductionAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualRawMaterialFiles_AttachmentId",
                table: "ActualRawMaterialFiles",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualRawMaterialFiles_FactoryId",
                table: "ActualRawMaterialFiles",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ActualRawMaterials_RawMaterialId",
                table: "ActualRawMaterials",
                column: "RawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomsItemLevels_CustomsItemUpdateId",
                table: "CustomsItemLevels",
                column: "CustomsItemUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomsItemLevels_ProductId",
                table: "CustomsItemLevels",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomsItemUpdates_FactoryId",
                table: "CustomsItemUpdates",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryContacts_FactoryId",
                table: "FactoryContacts",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryFiles_AttachmentId",
                table: "FactoryFiles",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryFiles_FactoryId",
                table: "FactoryFiles",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryFinancialAttachments_AttachmentId",
                table: "FactoryFinancialAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryFinancialAttachments_FactoryFinancialId",
                table: "FactoryFinancialAttachments",
                column: "FactoryFinancialId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryFinancials_FactoryId",
                table: "FactoryFinancials",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocationAttachments_AttachmentId",
                table: "FactoryLocationAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryLocationAttachments_FactoryLocationId",
                table: "FactoryLocationAttachments",
                column: "FactoryLocationId");

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
                name: "IX_FactoryProducts_FactoryId",
                table: "FactoryProducts",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttachments_AttachmentId",
                table: "ProductAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttachments_ProductId",
                table: "ProductAttachments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FactoryProductId",
                table: "Products",
                column: "FactoryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_AttachmentId",
                table: "RawMaterials",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_FactoryId",
                table: "RawMaterials",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_ProductId",
                table: "RawMaterials",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonIncreasCapacities_ActualProductionAndCapacityId",
                table: "ReasonIncreasCapacities",
                column: "ActualProductionAndCapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ActualProductionAndCapacityId",
                table: "Units",
                column: "ActualProductionAndCapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ProductId",
                table: "Units",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActualProductionAttachments");

            migrationBuilder.DropTable(
                name: "ActualRawMaterialFiles");

            migrationBuilder.DropTable(
                name: "ActualRawMaterials");

            migrationBuilder.DropTable(
                name: "CustomsItemLevels");

            migrationBuilder.DropTable(
                name: "FactoryContacts");

            migrationBuilder.DropTable(
                name: "FactoryFiles");

            migrationBuilder.DropTable(
                name: "FactoryFinancialAttachments");

            migrationBuilder.DropTable(
                name: "FactoryLocationAttachments");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "ProductAttachments");

            migrationBuilder.DropTable(
                name: "ReasonIncreasCapacities");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "RawMaterials");

            migrationBuilder.DropTable(
                name: "CustomsItemUpdates");

            migrationBuilder.DropTable(
                name: "FactoryFinancials");

            migrationBuilder.DropTable(
                name: "FactoryLocations");

            migrationBuilder.DropTable(
                name: "ActualProductionAndCapacities");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "FactoryEntities");

            migrationBuilder.DropTable(
                name: "IndustrialAreas");

            migrationBuilder.DropTable(
                name: "FactoryProducts");

            migrationBuilder.DropTable(
                name: "Factories");
        }
    }
}
