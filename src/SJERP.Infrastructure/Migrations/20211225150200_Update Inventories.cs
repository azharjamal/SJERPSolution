using Microsoft.EntityFrameworkCore.Migrations;

namespace SJERP.Infrastructure.Migrations
{
    public partial class UpdateInventories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Accounts_AccountId",
                table: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Inventories",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "stockDate",
                table: "Inventories",
                newName: "StockDate");

            migrationBuilder.RenameColumn(
                name: "serial",
                table: "Inventories",
                newName: "Serial");

            migrationBuilder.RenameColumn(
                name: "ram",
                table: "Inventories",
                newName: "Ram");

            migrationBuilder.RenameColumn(
                name: "model",
                table: "Inventories",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "make",
                table: "Inventories",
                newName: "Make");

            migrationBuilder.RenameColumn(
                name: "cpu",
                table: "Inventories",
                newName: "CPU");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_Accounts_AccountId",
                table: "RefreshToken",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Accounts_AccountId",
                table: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Inventories",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "StockDate",
                table: "Inventories",
                newName: "stockDate");

            migrationBuilder.RenameColumn(
                name: "Serial",
                table: "Inventories",
                newName: "serial");

            migrationBuilder.RenameColumn(
                name: "Ram",
                table: "Inventories",
                newName: "ram");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Inventories",
                newName: "model");

            migrationBuilder.RenameColumn(
                name: "Make",
                table: "Inventories",
                newName: "make");

            migrationBuilder.RenameColumn(
                name: "CPU",
                table: "Inventories",
                newName: "cpu");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_Accounts_AccountId",
                table: "RefreshToken",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
