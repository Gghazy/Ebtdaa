using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ebtdaa.Persistence.Migrations
{
    public partial class Intial_Create : Migration
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
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
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
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryContacts", x => x.Id);
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
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryFinancials", x => x.Id);
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
                name: "FactoryFinancialAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    FactoryFinancialId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
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
                name: "FactoryLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryEntityId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    IndustrialAreaId = table.Column<int>(type: "int", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
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
                name: "Factories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommercialRegister = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerIdentity = table.Column<int>(type: "int", nullable: false),
                    FactoryNumber = table.Column<int>(type: "int", nullable: false),
                    LicenseNumber = table.Column<int>(type: "int", nullable: false),
                    FactoryFinancialId = table.Column<int>(type: "int", nullable: true),
                    FactoryLocationId = table.Column<int>(type: "int", nullable: true),
                    FactoryContactId = table.Column<int>(type: "int", nullable: true),
                    LicenseExpirDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factories_FactoryContacts_FactoryContactId",
                        column: x => x.FactoryContactId,
                        principalTable: "FactoryContacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Factories_FactoryFinancials_FactoryFinancialId",
                        column: x => x.FactoryFinancialId,
                        principalTable: "FactoryFinancials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Factories_FactoryLocations_FactoryLocationId",
                        column: x => x.FactoryLocationId,
                        principalTable: "FactoryLocations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FactoryLocationAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    FactoryLocationId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
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
                name: "FactoryFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Factories_FactoryContactId",
                table: "Factories",
                column: "FactoryContactId",
                unique: true,
                filter: "[FactoryContactId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Factories_FactoryFinancialId",
                table: "Factories",
                column: "FactoryFinancialId",
                unique: true,
                filter: "[FactoryFinancialId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Factories_FactoryLocationId",
                table: "Factories",
                column: "FactoryLocationId",
                unique: true,
                filter: "[FactoryLocationId] IS NOT NULL");

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
                name: "IX_FactoryLocations_IndustrialAreaId",
                table: "FactoryLocations",
                column: "IndustrialAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactoryFiles");

            migrationBuilder.DropTable(
                name: "FactoryFinancialAttachments");

            migrationBuilder.DropTable(
                name: "FactoryLocationAttachments");

            migrationBuilder.DropTable(
                name: "Factories");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "FactoryContacts");

            migrationBuilder.DropTable(
                name: "FactoryFinancials");

            migrationBuilder.DropTable(
                name: "FactoryLocations");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "FactoryEntities");

            migrationBuilder.DropTable(
                name: "IndustrialAreas");
        }
    }
}
