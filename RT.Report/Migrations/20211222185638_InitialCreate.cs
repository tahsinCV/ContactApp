using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RT.Report.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ExternalSystemCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "date", nullable: false),
                    CreateUserID = table.Column<int>(type: "integer", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "date", nullable: false),
                    UpdateUserID = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "true"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReportStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisplayName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    CreateUserID = table.Column<int>(type: "integer", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "date", nullable: false),
                    UpdateUserID = table.Column<int>(type: "integer", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "true"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UUID = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CityID = table.Column<int>(type: "integer", nullable: false),
                    RequestStatusID = table.Column<int>(type: "integer", nullable: false),
                    UsersCountInLocation = table.Column<int>(type: "integer", nullable: false),
                    PhoneCountInLocation = table.Column<int>(type: "integer", nullable: false),
                    RequestTime = table.Column<DateTime>(type: "date", nullable: false),
                    CreateUserID = table.Column<int>(type: "integer", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "date", nullable: false),
                    UpdateUserID = table.Column<int>(type: "integer", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "true"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ID);
                    table.ForeignKey(
                        name: "FK_City",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Report_Status",
                        column: x => x.RequestStatusID,
                        principalTable: "ReportStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CityID",
                table: "Reports",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_RequestStatusID",
                table: "Reports",
                column: "RequestStatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "ReportStatus");
        }
    }
}
