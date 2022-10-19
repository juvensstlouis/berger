using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Berger.Infra.Migrations
{
    public partial class UpdateChurchColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoundationDate",
                table: "Church");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Church",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Church",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Church");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Church");

            migrationBuilder.AddColumn<DateTime>(
                name: "FoundationDate",
                table: "Church",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
