using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QnA.Persistence.Migrations
{
    public partial class AnotherIndexAddedToSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sessions_AccessCode_Status",
                table: "Sessions",
                columns: new[] { "AccessCode", "Status" })
                .Annotation("SqlServer:Include", new[] { "Title" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sessions_AccessCode_Status",
                table: "Sessions");
        }
    }
}
