using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Berger.Infra.Migrations
{
    public partial class CreateTableChurch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Church",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FoundationDate = table.Column<DateTime>(nullable: false),
                    Address_ZipCode = table.Column<string>(nullable: true),
                    Address_Street = table.Column<string>(nullable: true),
                    Address_Number = table.Column<string>(nullable: true),
                    Address_Complement = table.Column<string>(nullable: true),
                    Address_Neighborhood = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Church", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Church");
        }
    }
}
