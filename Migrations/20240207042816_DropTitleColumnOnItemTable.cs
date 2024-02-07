using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MauiExample.Migrations
{
    /// <inheritdoc />
    public partial class DropTitleColumnOnItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Items",
                type: "TEXT",
                nullable: true);
        }
    }
}
