using Microsoft.EntityFrameworkCore.Migrations;

namespace QnA.Persistence.Migrations
{
    public partial class IndexAddedToVotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vote_QuestionId",
                table: "Vote");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_QuestionId_CreatedBy",
                table: "Vote",
                columns: new[] { "QuestionId", "CreatedBy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vote_QuestionId_CreatedBy",
                table: "Vote");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_QuestionId",
                table: "Vote",
                column: "QuestionId");
        }
    }
}
