using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QnA.Persistence.Migrations
{
    public partial class IndexOnSessionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CreatedBy_Created",
                table: "Sessions",
                columns: new[] { "CreatedBy", "Created" })
                .Annotation("SqlServer:Include", new[] { "Title", "Status" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sessions_CreatedBy_Created",
                table: "Sessions");
        }
    }
}
