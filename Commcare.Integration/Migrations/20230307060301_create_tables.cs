using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Commcare.Integration.Migrations
{
    /// <inheritdoc />
    public partial class create_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "app_list",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppName = table.Column<string>(type: "text", nullable: true),
                    AppId = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_list", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "form_data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FormId = table.Column<string>(type: "text", nullable: true),
                    FieldName = table.Column<string>(type: "text", nullable: true),
                    FieldValue = table.Column<string>(type: "text", nullable: true),
                    AppId = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_form_data", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "form_details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppId = table.Column<string>(type: "text", nullable: true),
                    FormId = table.Column<string>(type: "text", nullable: true),
                    TimeStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    QuartNum = table.Column<string>(type: "text", nullable: true),
                    SurveyDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FormLink = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_form_details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "form_fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppId = table.Column<string>(type: "text", nullable: true),
                    FieldName = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_form_fields", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "app_list");

            migrationBuilder.DropTable(
                name: "form_data");

            migrationBuilder.DropTable(
                name: "form_details");

            migrationBuilder.DropTable(
                name: "form_fields");
        }
    }
}
