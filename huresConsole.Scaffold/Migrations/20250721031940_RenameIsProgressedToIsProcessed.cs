using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace huresConsole.Scaffold.Migrations
{
    /// <inheritdoc />
    public partial class RenameIsProgressedToIsProcessed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isProgressed",
                table: "DATAASAS",
                newName: "isProcessed");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isProcessed",
                table: "DATAASAS",
                newName: "isProgressed");
        }
    }
}
