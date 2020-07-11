using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QnA.Persistence.Migrations
{
    public partial class IndexAddedToQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Questions_SessionId",
                table: "Questions");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SessionId",
                table: "Questions",
                column: "SessionId")
                .Annotation("SqlServer:Include", new[] { "Text", "Score", "CreatedBy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Questions_SessionId",
                table: "Questions");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SessionId",
                table: "Questions",
                column: "SessionId");
        }
    }
}
