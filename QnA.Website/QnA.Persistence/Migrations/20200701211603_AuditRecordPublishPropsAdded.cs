using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QnA.Persistence.Migrations
{
    public partial class AuditRecordPublishPropsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDateTime",
                table: "AuditRecords",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "AuditRecords",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishDateTime",
                table: "AuditRecords");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "AuditRecords");
        }
    }
}
