using Microsoft.EntityFrameworkCore.Migrations;

namespace Remedies.DataAccess.Migrations
{
    public partial class AddedChangesToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_RemedyTypes_CoverTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CoverTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CoverTypeId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RemedyTypeId",
                table: "Products",
                column: "RemedyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_RemedyTypes_RemedyTypeId",
                table: "Products",
                column: "RemedyTypeId",
                principalTable: "RemedyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_RemedyTypes_RemedyTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_RemedyTypeId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CoverTypeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CoverTypeId",
                table: "Products",
                column: "CoverTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_RemedyTypes_CoverTypeId",
                table: "Products",
                column: "CoverTypeId",
                principalTable: "RemedyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
