using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace huresConsole.Scaffold.Migrations
{
    /// <inheritdoc />
    public partial class AddIsProgressedToDataasas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isProgressed",
                table: "DATAASAS",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isProgressed",
                table: "DATAASAS");
        }
    }
}
