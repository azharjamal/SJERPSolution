using Microsoft.EntityFrameworkCore.Migrations;

namespace SJERP.Infrastructure.Migrations
{
    public partial class RemoveDependency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_InventoryDetail_InventoryDetailId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_Inventories_InventoryId",
                table: "ProductImage");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Accounts_AccountId",
                table: "RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_ProductImage_InventoryId",
                table: "ProductImage");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_InventoryDetailId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "InventoryDetailId",
                table: "Inventories");

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

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "ProductImage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryDetailId",
                table: "Inventories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_InventoryId",
                table: "ProductImage",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InventoryDetailId",
                table: "Inventories",
                column: "InventoryDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_InventoryDetail_InventoryDetailId",
                table: "Inventories",
                column: "InventoryDetailId",
                principalTable: "InventoryDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_Inventories_InventoryId",
                table: "ProductImage",
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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
