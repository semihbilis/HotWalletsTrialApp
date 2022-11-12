using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotWalletsTrialApp.Migrations
{
    /// <inheritdoc />
    public partial class RenameCreateAccountIdToCreatedByAccountIdForAllTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateAccountId",
                table: "WalletTransaction",
                newName: "CreatedByAccountId");

            migrationBuilder.RenameColumn(
                name: "CreateAccountId",
                table: "WalletAuthorization",
                newName: "CreatedByAccountId");

            migrationBuilder.RenameColumn(
                name: "CreateAccountId",
                table: "Wallet",
                newName: "CreatedByAccountId");

            migrationBuilder.RenameColumn(
                name: "CreateAccountId",
                table: "Category",
                newName: "CreatedByAccountId");

            migrationBuilder.RenameColumn(
                name: "CreateAccountId",
                table: "Account",
                newName: "CreatedByAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedByAccountId",
                table: "WalletTransaction",
                newName: "CreateAccountId");

            migrationBuilder.RenameColumn(
                name: "CreatedByAccountId",
                table: "WalletAuthorization",
                newName: "CreateAccountId");

            migrationBuilder.RenameColumn(
                name: "CreatedByAccountId",
                table: "Wallet",
                newName: "CreateAccountId");

            migrationBuilder.RenameColumn(
                name: "CreatedByAccountId",
                table: "Category",
                newName: "CreateAccountId");

            migrationBuilder.RenameColumn(
                name: "CreatedByAccountId",
                table: "Account",
                newName: "CreateAccountId");
        }
    }
}
