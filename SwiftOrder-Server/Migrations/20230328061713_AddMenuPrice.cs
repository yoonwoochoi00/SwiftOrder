using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftOrder_Server.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MenuPrice",
                table: "Menu",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuPrice",
                table: "Menu");
        }
    }
}
