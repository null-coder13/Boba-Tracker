using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BobaTrackerClassLibrary.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    DateTimeId = table.Column<DateTime>(nullable: false),
                    hasPooped = table.Column<bool>(nullable: false),
                    hasPeed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.DateTimeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
