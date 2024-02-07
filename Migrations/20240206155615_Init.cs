using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MauiExample.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Timestamp = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    Altitude = table.Column<double>(type: "REAL", nullable: true),
                    Accuracy = table.Column<double>(type: "REAL", nullable: true),
                    VerticalAccuracy = table.Column<double>(type: "REAL", nullable: true),
                    ReducedAccuracy = table.Column<bool>(type: "INTEGER", nullable: false),
                    Speed = table.Column<double>(type: "REAL", nullable: true),
                    Course = table.Column<double>(type: "REAL", nullable: true),
                    IsFromMockProvider = table.Column<bool>(type: "INTEGER", nullable: false),
                    AltitudeReferenceSystem = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkLocations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "WorkLocations");
        }
    }
}
