using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Commcare.Integration.Migrations
{
    /// <inheritdoc />
    public partial class update_column_names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "form_fields",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FieldName",
                table: "form_fields",
                newName: "field_name");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "form_fields",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "AppId",
                table: "form_fields",
                newName: "app_id");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "form_details",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "form_details",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TimeStart",
                table: "form_details",
                newName: "time_start");

            migrationBuilder.RenameColumn(
                name: "TimeEnd",
                table: "form_details",
                newName: "time_end");

            migrationBuilder.RenameColumn(
                name: "SurveyDate",
                table: "form_details",
                newName: "survey_date");

            migrationBuilder.RenameColumn(
                name: "QuartNum",
                table: "form_details",
                newName: "quart_num");

            migrationBuilder.RenameColumn(
                name: "FormLink",
                table: "form_details",
                newName: "form_link");

            migrationBuilder.RenameColumn(
                name: "FormId",
                table: "form_details",
                newName: "form_id");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "form_details",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "AppId",
                table: "form_details",
                newName: "app_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "form_data",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FormId",
                table: "form_data",
                newName: "form_id");

            migrationBuilder.RenameColumn(
                name: "FieldValue",
                table: "form_data",
                newName: "field_value");

            migrationBuilder.RenameColumn(
                name: "FieldName",
                table: "form_data",
                newName: "field_name");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "form_data",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "AppId",
                table: "form_data",
                newName: "app_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "app_list",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "app_list",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "AppName",
                table: "app_list",
                newName: "app_name");

            migrationBuilder.RenameColumn(
                name: "AppId",
                table: "app_list",
                newName: "app_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "form_fields",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "field_name",
                table: "form_fields",
                newName: "FieldName");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "form_fields",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "app_id",
                table: "form_fields",
                newName: "AppId");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "form_details",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "form_details",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "time_start",
                table: "form_details",
                newName: "TimeStart");

            migrationBuilder.RenameColumn(
                name: "time_end",
                table: "form_details",
                newName: "TimeEnd");

            migrationBuilder.RenameColumn(
                name: "survey_date",
                table: "form_details",
                newName: "SurveyDate");

            migrationBuilder.RenameColumn(
                name: "quart_num",
                table: "form_details",
                newName: "QuartNum");

            migrationBuilder.RenameColumn(
                name: "form_link",
                table: "form_details",
                newName: "FormLink");

            migrationBuilder.RenameColumn(
                name: "form_id",
                table: "form_details",
                newName: "FormId");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "form_details",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "app_id",
                table: "form_details",
                newName: "AppId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "form_data",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "form_id",
                table: "form_data",
                newName: "FormId");

            migrationBuilder.RenameColumn(
                name: "field_value",
                table: "form_data",
                newName: "FieldValue");

            migrationBuilder.RenameColumn(
                name: "field_name",
                table: "form_data",
                newName: "FieldName");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "form_data",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "app_id",
                table: "form_data",
                newName: "AppId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "app_list",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "app_list",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "app_name",
                table: "app_list",
                newName: "AppName");

            migrationBuilder.RenameColumn(
                name: "app_id",
                table: "app_list",
                newName: "AppId");
        }
    }
}
