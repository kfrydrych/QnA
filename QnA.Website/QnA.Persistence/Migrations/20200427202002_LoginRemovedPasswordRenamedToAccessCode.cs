using Microsoft.EntityFrameworkCore.Migrations;

namespace QnA.Persistence.Migrations
{
    public partial class LoginRemovedPasswordRenamedToAccessCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Sessions");

            migrationBuilder.AddColumn<string>(
                name: "AccessCode",
                table: "Sessions",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessCode",
                table: "Sessions");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Sessions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Sessions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
