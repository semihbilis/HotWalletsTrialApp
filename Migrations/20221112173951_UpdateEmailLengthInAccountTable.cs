using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotWalletsTrialApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmailLengthInAccountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Account",
                type: "nvarchar(27)",
                maxLength: 27,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(17)",
                oldMaxLength: 17);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Account",
                type: "nvarchar(17)",
                maxLength: 17,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(27)",
                oldMaxLength: 27);
        }
    }
}
