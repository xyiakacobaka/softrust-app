using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageFormApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ThemesController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThemeLbel",
                table: "Themes",
                newName: "ThemeLabel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThemeLabel",
                table: "Themes",
                newName: "ThemeLbel");
        }
    }
}
