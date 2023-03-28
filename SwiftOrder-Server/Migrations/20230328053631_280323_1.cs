using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftOrder_Server.Migrations
{
    /// <inheritdoc />
    public partial class _280323_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MenuID",
                table: "Kiosks",
                newName: "IsPaid");

            migrationBuilder.AddColumn<bool>(
                name: "IsKitchen",
                table: "Kiosks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsKitchen",
                table: "Kiosks");

            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "Kiosks",
                newName: "MenuID");
        }
    }
}
