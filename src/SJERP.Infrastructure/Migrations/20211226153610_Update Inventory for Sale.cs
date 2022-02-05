using Microsoft.EntityFrameworkCore.Migrations;

namespace SJERP.Infrastructure.Migrations
{
    public partial class UpdateInventoryforSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Accounts_AccountId",
                table: "RefreshToken");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDetail_InventoryId",
                table: "InventoryDetail",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryDetail_Inventories_InventoryId",
                table: "InventoryDetail",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_InventoryDetail_Inventories_InventoryId",
                table: "InventoryDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Accounts_AccountId",
                table: "RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_InventoryDetail_InventoryId",
                table: "InventoryDetail");

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
