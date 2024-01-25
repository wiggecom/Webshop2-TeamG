using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webshop2_TeamG.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Today",
                table: "Baskets",
                newName: "DateOfPurchase");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfPurchase",
                table: "Baskets",
                newName: "Today");
        }
    }
}
