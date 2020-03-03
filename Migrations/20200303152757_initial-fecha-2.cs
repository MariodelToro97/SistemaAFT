using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaAFT.Migrations
{
    public partial class initialfecha2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastAccessed",
                table: "Persona");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Persona",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Persona");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastAccessed",
                table: "Persona",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
