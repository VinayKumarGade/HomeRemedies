using Microsoft.EntityFrameworkCore.Migrations;

namespace Remedies.DataAccess.Migrations
{
    public partial class AddedDifferentPricesToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ListPrice",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price100",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price50",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price100",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price50",
                table: "Products");
        }
    }
}
