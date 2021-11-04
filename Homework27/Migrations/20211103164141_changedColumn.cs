using Microsoft.EntityFrameworkCore.Migrations;

namespace Homework27.Migrations
{
    public partial class changedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "Cost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Products",
                newName: "Price");
        }
    }
}
