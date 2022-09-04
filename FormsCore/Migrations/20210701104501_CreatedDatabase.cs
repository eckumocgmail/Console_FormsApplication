using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blazor.Core.Migrations
{
    public partial class CreatedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActivationKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RFID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BusinessIndicators",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNegative = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessIndicators", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusinessIndicators_BusinessIndicators_ParentID",
                        column: x => x.ParentID,
                        principalTable: "BusinessIndicators",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessProcess",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProcess", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusinessProcess_BusinessProcess_ParentID",
                        column: x => x.ParentID,
                        principalTable: "BusinessProcess",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessReports",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Xml = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessReports", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusinessReports_BusinessReports_ParentID",
                        column: x => x.ParentID,
                        principalTable: "BusinessReports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessResources",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastActive = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecretKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessResources", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusinessResources_BusinessResources_ParentID",
                        column: x => x.ParentID,
                        principalTable: "BusinessResources",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Week = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Quarter = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FileCatalogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileCatalogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FileCatalogs_FileCatalogs_ParentID",
                        column: x => x.ParentID,
                        principalTable: "FileCatalogs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Granularities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Granularities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ManagmentLocation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagmentLocation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ManagmentLocation_ManagmentLocation_ParentID",
                        column: x => x.ParentID,
                        principalTable: "ManagmentLocation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManagmentPosition",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagmentPosition", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MedicalFunctions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarriff = table.Column<float>(type: "real", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalFunctions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MedicalLabs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalLabs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRoom",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRoom", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MessageAttributes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSystem = table.Column<bool>(type: "bit", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CSharpType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SQLType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InputType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SqlServerDataType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MySQLDataType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostgreDataType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OracleDataType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageAttributes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Migrations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MigrationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SQL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Migrations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VertialLayout = table.Column<bool>(type: "bit", nullable: false),
                    FocusControls = table.Column<bool>(type: "bit", nullable: false),
                    ColorTheme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicOperations = table.Column<bool>(type: "bit", nullable: false),
                    SendNewsToEmail = table.Column<bool>(type: "bit", nullable: false),
                    ShowHelp = table.Column<bool>(type: "bit", nullable: false),
                    EvaluateMe = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ValidationModels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValidationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JavaScript = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidationModels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessProcessID = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Groups_BusinessProcess_BusinessProcessID",
                        column: x => x.BusinessProcessID,
                        principalTable: "BusinessProcess",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessDatasources",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessReportID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessDatasources", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusinessDatasources_BusinessReports_BusinessReportID",
                        column: x => x.BusinessReportID,
                        principalTable: "BusinessReports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilResources",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogID = table.Column<int>(type: "int", nullable: false),
                    Mime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilResources", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FilResources_FileCatalogs_CatalogID",
                        column: x => x.CatalogID,
                        principalTable: "FileCatalogs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JuristicalLocationID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Organizations_ManagmentLocation_JuristicalLocationID",
                        column: x => x.JuristicalLocationID,
                        principalTable: "ManagmentLocation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PositionFunctions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionFunctions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PositionFunctions_ManagmentPosition_PositionID",
                        column: x => x.PositionID,
                        principalTable: "ManagmentPosition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TariffRates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionID = table.Column<int>(type: "int", nullable: false),
                    Param = table.Column<float>(type: "real", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffRates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TariffRates_ManagmentPosition_PositionID",
                        column: x => x.PositionID,
                        principalTable: "ManagmentPosition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalCards",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Policy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastActive = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecretKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MedicalCards_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageID = table.Column<int>(type: "int", nullable: true),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.ID);
                    table.ForeignKey(
                        name: "FK_News_Resources_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Resources",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    SettingsID = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    LoginCount = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastActive = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecretKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_BusinessResources_RoleID",
                        column: x => x.RoleID,
                        principalTable: "BusinessResources",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Settings_SettingsID",
                        column: x => x.SettingsID,
                        principalTable: "Settings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Departments_Organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organizations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FunctionSkills",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionFunctionID = table.Column<int>(type: "int", nullable: false),
                    SkillID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionSkills", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FunctionSkills_PositionFunctions_PositionFunctionID",
                        column: x => x.PositionFunctionID,
                        principalTable: "PositionFunctions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FunctionSkills_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalBeds",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalTargetID = table.Column<int>(type: "int", nullable: true),
                    MedicalRoomID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalBeds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MedicalBeds_MedicalCards_MedicalTargetID",
                        column: x => x.MedicalTargetID,
                        principalTable: "MedicalCards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalBeds_MedicalRoom_MedicalRoomID",
                        column: x => x.MedicalRoomID,
                        principalTable: "MedicalRoom",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalCases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalCardID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MedicalCases_MedicalCards_MedicalCardID",
                        column: x => x.MedicalCardID,
                        principalTable: "MedicalCards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoginFacts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CalendarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginFacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LoginFacts_Calendars_CalendarID",
                        column: x => x.CalendarID,
                        principalTable: "Calendars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoginFacts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: true),
                    ToUserID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Messages_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_ToUserID1",
                        column: x => x.ToUserID1,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserGroups_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroups_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", maxLength: 40, nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    PositionID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_ManagmentPosition_PositionID",
                        column: x => x.PositionID,
                        principalTable: "ManagmentPosition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryReports",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GranularityID = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryReports", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SalaryReports_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    PositionID = table.Column<int>(type: "int", nullable: false),
                    StaffActivatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CountOfEmployees = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Staffs_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staffs_ManagmentPosition_PositionID",
                        column: x => x.PositionID,
                        principalTable: "ManagmentPosition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalDevices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalBedID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalDevices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MedicalDevices_MedicalBeds_MedicalBedID",
                        column: x => x.MedicalBedID,
                        principalTable: "MedicalBeds",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalSteps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalCaseID = table.Column<int>(type: "int", nullable: false),
                    MedicalEnv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalFunctionID = table.Column<int>(type: "int", nullable: false),
                    MedicalDocument = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSteps", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MedicalSteps_MedicalCases_MedicalCaseID",
                        column: x => x.MedicalCaseID,
                        principalTable: "MedicalCases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalSteps_MedicalFunctions_MedicalFunctionID",
                        column: x => x.MedicalFunctionID,
                        principalTable: "MedicalFunctions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeExpirience",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    SkillID = table.Column<int>(type: "int", nullable: false),
                    Begin = table.Column<DateTime>(type: "date", nullable: false),
                    Granularity = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CalendarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeExpirience", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeExpirience_Calendars_CalendarID",
                        column: x => x.CalendarID,
                        principalTable: "Calendars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeExpirience_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeExpirience_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Task = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TimeSheets_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessIndicatorID = table.Column<int>(type: "int", nullable: false),
                    BusinessDatasetID = table.Column<int>(type: "int", nullable: false),
                    GranularityID = table.Column<int>(type: "int", nullable: false),
                    BusinessResourceID = table.Column<int>(type: "int", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    Changed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusinessData_BusinessIndicators_BusinessIndicatorID",
                        column: x => x.BusinessIndicatorID,
                        principalTable: "BusinessIndicators",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessData_BusinessResources_BusinessResourceID",
                        column: x => x.BusinessResourceID,
                        principalTable: "BusinessResources",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessDatasets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessDatasourceID = table.Column<int>(type: "int", nullable: false),
                    Expression = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessFunctionID = table.Column<int>(type: "int", nullable: true),
                    BusinessIndicatorID = table.Column<int>(type: "int", nullable: true),
                    BusinessLogicID = table.Column<int>(type: "int", nullable: true),
                    BusinessProcessID = table.Column<int>(type: "int", nullable: true),
                    BusinessReportID = table.Column<int>(type: "int", nullable: true),
                    MessageProtocolID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessDatasets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusinessDatasets_BusinessDatasources_BusinessDatasourceID",
                        column: x => x.BusinessDatasourceID,
                        principalTable: "BusinessDatasources",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessDatasets_BusinessIndicators_BusinessIndicatorID",
                        column: x => x.BusinessIndicatorID,
                        principalTable: "BusinessIndicators",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessDatasets_BusinessProcess_BusinessProcessID",
                        column: x => x.BusinessProcessID,
                        principalTable: "BusinessProcess",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessDatasets_BusinessReports_BusinessReportID",
                        column: x => x.BusinessReportID,
                        principalTable: "BusinessReports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupsBusinessFunctions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    BusinessFunctionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsBusinessFunctions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GroupsBusinessFunctions_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageProtocols",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromID = table.Column<int>(type: "int", nullable: true),
                    FromBusinessFunctionID = table.Column<int>(type: "int", nullable: true),
                    ToBusinessFunctionID = table.Column<int>(type: "int", nullable: true),
                    ToID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageProtocols", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MessageProtocols_MessageProtocols_ParentID",
                        column: x => x.ParentID,
                        principalTable: "MessageProtocols",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessLogics",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InputID = table.Column<int>(type: "int", nullable: true),
                    OutputID = table.Column<int>(type: "int", nullable: true),
                    ErrorID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessLogics", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusinessLogics_BusinessLogics_ParentID",
                        column: x => x.ParentID,
                        principalTable: "BusinessLogics",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessLogics_MessageProtocols_ErrorID",
                        column: x => x.ErrorID,
                        principalTable: "MessageProtocols",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessLogics_MessageProtocols_InputID",
                        column: x => x.InputID,
                        principalTable: "MessageProtocols",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessLogics_MessageProtocols_OutputID",
                        column: x => x.OutputID,
                        principalTable: "MessageProtocols",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MessageProperties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Help = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    Unique = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<bool>(type: "bit", nullable: false),
                    AttributeID = table.Column<int>(type: "int", nullable: false),
                    MessageProtocolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageProperties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MessageProperties_MessageAttributes_AttributeID",
                        column: x => x.AttributeID,
                        principalTable: "MessageAttributes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageProperties_MessageProtocols_MessageProtocolID",
                        column: x => x.MessageProtocolID,
                        principalTable: "MessageProtocols",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessFunctions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessResourceID = table.Column<int>(type: "int", nullable: true),
                    BusinessLogicID = table.Column<int>(type: "int", nullable: true),
                    BusinessProcessID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessFunctions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusinessFunctions_BusinessFunctions_ParentID",
                        column: x => x.ParentID,
                        principalTable: "BusinessFunctions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessFunctions_BusinessLogics_BusinessLogicID",
                        column: x => x.BusinessLogicID,
                        principalTable: "BusinessLogics",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessFunctions_BusinessProcess_BusinessProcessID",
                        column: x => x.BusinessProcessID,
                        principalTable: "BusinessProcess",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessFunctions_BusinessResources_BusinessResourceID",
                        column: x => x.BusinessResourceID,
                        principalTable: "BusinessResources",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessData_BusinessDatasetID",
                table: "BusinessData",
                column: "BusinessDatasetID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessData_BusinessIndicatorID",
                table: "BusinessData",
                column: "BusinessIndicatorID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessData_BusinessResourceID",
                table: "BusinessData",
                column: "BusinessResourceID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDatasets_BusinessDatasourceID",
                table: "BusinessDatasets",
                column: "BusinessDatasourceID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDatasets_BusinessFunctionID",
                table: "BusinessDatasets",
                column: "BusinessFunctionID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDatasets_BusinessIndicatorID",
                table: "BusinessDatasets",
                column: "BusinessIndicatorID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDatasets_BusinessLogicID",
                table: "BusinessDatasets",
                column: "BusinessLogicID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDatasets_BusinessProcessID",
                table: "BusinessDatasets",
                column: "BusinessProcessID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDatasets_BusinessReportID",
                table: "BusinessDatasets",
                column: "BusinessReportID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDatasets_MessageProtocolID",
                table: "BusinessDatasets",
                column: "MessageProtocolID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDatasets_Name",
                table: "BusinessDatasets",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDatasources_BusinessReportID",
                table: "BusinessDatasources",
                column: "BusinessReportID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDatasources_Name",
                table: "BusinessDatasources",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessFunctions_BusinessLogicID",
                table: "BusinessFunctions",
                column: "BusinessLogicID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessFunctions_BusinessProcessID",
                table: "BusinessFunctions",
                column: "BusinessProcessID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessFunctions_BusinessResourceID",
                table: "BusinessFunctions",
                column: "BusinessResourceID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessFunctions_Name",
                table: "BusinessFunctions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessFunctions_ParentID",
                table: "BusinessFunctions",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessIndicators_Name",
                table: "BusinessIndicators",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessIndicators_ParentID",
                table: "BusinessIndicators",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessLogics_ErrorID",
                table: "BusinessLogics",
                column: "ErrorID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessLogics_InputID",
                table: "BusinessLogics",
                column: "InputID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessLogics_Name",
                table: "BusinessLogics",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessLogics_OutputID",
                table: "BusinessLogics",
                column: "OutputID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessLogics_ParentID",
                table: "BusinessLogics",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_Name",
                table: "BusinessProcess",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcess_ParentID",
                table: "BusinessProcess",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessReports_Name",
                table: "BusinessReports",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessReports_ParentID",
                table: "BusinessReports",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessResources_Name",
                table: "BusinessResources",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessResources_ParentID",
                table: "BusinessResources",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                table: "Departments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_OrganizationID",
                table: "Departments",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExpirience_CalendarID",
                table: "EmployeeExpirience",
                column: "CalendarID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExpirience_EmployeeID",
                table: "EmployeeExpirience",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeExpirience_SkillID",
                table: "EmployeeExpirience",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Name",
                table: "Employees",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionID",
                table: "Employees",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_FileCatalogs_Name",
                table: "FileCatalogs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileCatalogs_ParentID",
                table: "FileCatalogs",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_FilResources_CatalogID",
                table: "FilResources",
                column: "CatalogID");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionSkills_PositionFunctionID",
                table: "FunctionSkills",
                column: "PositionFunctionID");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionSkills_SkillID",
                table: "FunctionSkills",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_Granularities_Name",
                table: "Granularities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_BusinessProcessID",
                table: "Groups",
                column: "BusinessProcessID");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name",
                table: "Groups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupsBusinessFunctions_BusinessFunctionID",
                table: "GroupsBusinessFunctions",
                column: "BusinessFunctionID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsBusinessFunctions_GroupID",
                table: "GroupsBusinessFunctions",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_LoginFacts_CalendarID",
                table: "LoginFacts",
                column: "CalendarID");

            migrationBuilder.CreateIndex(
                name: "IX_LoginFacts_UserID",
                table: "LoginFacts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ManagmentLocation_Name",
                table: "ManagmentLocation",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ManagmentLocation_ParentID",
                table: "ManagmentLocation",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_ManagmentPosition_Name",
                table: "ManagmentPosition",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalBeds_MedicalRoomID",
                table: "MedicalBeds",
                column: "MedicalRoomID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalBeds_MedicalTargetID",
                table: "MedicalBeds",
                column: "MedicalTargetID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCards_Name",
                table: "MedicalCards",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCards_PersonID",
                table: "MedicalCards",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCases_MedicalCardID",
                table: "MedicalCases",
                column: "MedicalCardID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalDevices_MedicalBedID",
                table: "MedicalDevices",
                column: "MedicalBedID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRoom_Name",
                table: "MedicalRoom",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalSteps_MedicalCaseID",
                table: "MedicalSteps",
                column: "MedicalCaseID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalSteps_MedicalFunctionID",
                table: "MedicalSteps",
                column: "MedicalFunctionID");

            migrationBuilder.CreateIndex(
                name: "IX_MessageProperties_AttributeID",
                table: "MessageProperties",
                column: "AttributeID");

            migrationBuilder.CreateIndex(
                name: "IX_MessageProperties_MessageProtocolID",
                table: "MessageProperties",
                column: "MessageProtocolID");

            migrationBuilder.CreateIndex(
                name: "IX_MessageProtocols_FromID",
                table: "MessageProtocols",
                column: "FromID",
                unique: true,
                filter: "[FromID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MessageProtocols_Name",
                table: "MessageProtocols",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MessageProtocols_ParentID",
                table: "MessageProtocols",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_MessageProtocols_ToID",
                table: "MessageProtocols",
                column: "ToID",
                unique: true,
                filter: "[ToID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_GroupID",
                table: "Messages",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToUserID1",
                table: "Messages",
                column: "ToUserID1");

            migrationBuilder.CreateIndex(
                name: "IX_News_ImageID",
                table: "News",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_JuristicalLocationID",
                table: "Organizations",
                column: "JuristicalLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_Name",
                table: "Organizations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_SurName",
                table: "Persons",
                column: "SurName");

            migrationBuilder.CreateIndex(
                name: "IX_PositionFunctions_Name",
                table: "PositionFunctions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PositionFunctions_PositionID",
                table: "PositionFunctions",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryReports_DepartmentID",
                table: "SalaryReports",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Name",
                table: "Skills",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DepartmentID",
                table: "Staffs",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_PositionID",
                table: "Staffs",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_TariffRates_Name",
                table: "TariffRates",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TariffRates_PositionID",
                table: "TariffRates",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_EmployeeID",
                table: "TimeSheets",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_GroupID",
                table: "UserGroups",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_UserID",
                table: "UserGroups",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountID",
                table: "Users",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonID",
                table: "Users",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SettingsID",
                table: "Users",
                column: "SettingsID");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessData_BusinessDatasets_BusinessDatasetID",
                table: "BusinessData",
                column: "BusinessDatasetID",
                principalTable: "BusinessDatasets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessDatasets_BusinessFunctions_BusinessFunctionID",
                table: "BusinessDatasets",
                column: "BusinessFunctionID",
                principalTable: "BusinessFunctions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessDatasets_BusinessLogics_BusinessLogicID",
                table: "BusinessDatasets",
                column: "BusinessLogicID",
                principalTable: "BusinessLogics",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessDatasets_MessageProtocols_MessageProtocolID",
                table: "BusinessDatasets",
                column: "MessageProtocolID",
                principalTable: "MessageProtocols",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupsBusinessFunctions_BusinessFunctions_BusinessFunctionID",
                table: "GroupsBusinessFunctions",
                column: "BusinessFunctionID",
                principalTable: "BusinessFunctions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageProtocols_BusinessFunctions_FromID",
                table: "MessageProtocols",
                column: "FromID",
                principalTable: "BusinessFunctions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageProtocols_BusinessFunctions_ToID",
                table: "MessageProtocols",
                column: "ToID",
                principalTable: "BusinessFunctions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessFunctions_BusinessResources_BusinessResourceID",
                table: "BusinessFunctions");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageProtocols_BusinessFunctions_FromID",
                table: "MessageProtocols");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageProtocols_BusinessFunctions_ToID",
                table: "MessageProtocols");

            migrationBuilder.DropTable(
                name: "BusinessData");

            migrationBuilder.DropTable(
                name: "EmployeeExpirience");

            migrationBuilder.DropTable(
                name: "FilResources");

            migrationBuilder.DropTable(
                name: "FunctionSkills");

            migrationBuilder.DropTable(
                name: "Granularities");

            migrationBuilder.DropTable(
                name: "GroupsBusinessFunctions");

            migrationBuilder.DropTable(
                name: "LoginFacts");

            migrationBuilder.DropTable(
                name: "MedicalDevices");

            migrationBuilder.DropTable(
                name: "MedicalLabs");

            migrationBuilder.DropTable(
                name: "MedicalSteps");

            migrationBuilder.DropTable(
                name: "MessageProperties");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Migrations");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "SalaryReports");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "TariffRates");

            migrationBuilder.DropTable(
                name: "TimeSheets");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "ValidationModels");

            migrationBuilder.DropTable(
                name: "BusinessDatasets");

            migrationBuilder.DropTable(
                name: "FileCatalogs");

            migrationBuilder.DropTable(
                name: "PositionFunctions");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "MedicalBeds");

            migrationBuilder.DropTable(
                name: "MedicalCases");

            migrationBuilder.DropTable(
                name: "MedicalFunctions");

            migrationBuilder.DropTable(
                name: "MessageAttributes");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BusinessDatasources");

            migrationBuilder.DropTable(
                name: "BusinessIndicators");

            migrationBuilder.DropTable(
                name: "MedicalRoom");

            migrationBuilder.DropTable(
                name: "MedicalCards");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "ManagmentPosition");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "BusinessReports");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "ManagmentLocation");

            migrationBuilder.DropTable(
                name: "BusinessResources");

            migrationBuilder.DropTable(
                name: "BusinessFunctions");

            migrationBuilder.DropTable(
                name: "BusinessLogics");

            migrationBuilder.DropTable(
                name: "BusinessProcess");

            migrationBuilder.DropTable(
                name: "MessageProtocols");
        }
    }
}
