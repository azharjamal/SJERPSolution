using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SJERP.Infrastructure.Migrations
{
    public partial class InventoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Accounts_AccountId",
                table: "RefreshToken");

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "ProductImage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InventoryDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    diskname = table.Column<string>(type: "varchar(150)", nullable: true),
                    disksize = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    make = table.Column<string>(type: "varchar(150)", nullable: true),
                    model = table.Column<string>(type: "varchar(150)", nullable: true),
                    ram = table.Column<string>(type: "varchar(150)", nullable: true),
                    serial = table.Column<string>(type: "varchar(150)", nullable: true),
                    cpu = table.Column<string>(type: "varchar(150)", nullable: true),
                    stockDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    InventoryDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_InventoryDetail_InventoryDetailId",
                        column: x => x.InventoryDetailId,
                        principalTable: "InventoryDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_InventoryId",
                table: "ProductImage",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InventoryDetailId",
                table: "Inventories",
                column: "InventoryDetailId");

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_Inventories_InventoryId",
                table: "ProductImage");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Accounts_AccountId",
                table: "RefreshToken");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "InventoryDetail");

            migrationBuilder.DropIndex(
                name: "IX_ProductImage_InventoryId",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "ProductImage");

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
