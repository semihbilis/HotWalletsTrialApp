using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotWalletsTrialApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAccountIdColumnInWalletTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_Account_AccountId",
                table: "Wallet");

            migrationBuilder.DropIndex(
                name: "IX_Wallet_AccountId",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "Account");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Wallet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WalletId",
                table: "Account",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_AccountId",
                table: "Wallet",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_Account_AccountId",
                table: "Wallet",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
