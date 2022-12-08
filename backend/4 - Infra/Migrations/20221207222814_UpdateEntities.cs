using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Berger.Infra.Migrations
{
    public partial class UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Church");

            migrationBuilder.DropColumn(
                name: "Address_Complement",
                table: "Church");

            migrationBuilder.DropColumn(
                name: "Address_Neighborhood",
                table: "Church");

            migrationBuilder.DropColumn(
                name: "Address_Number",
                table: "Church");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "Church");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Church");

            migrationBuilder.DropColumn(
                name: "Address_ZipCode",
                table: "Church");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Church",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Church",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Church_UserId",
                table: "Church",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Church_User_UserId",
                table: "Church",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Church_User_UserId",
                table: "Church");

            migrationBuilder.DropIndex(
                name: "IX_Church_UserId",
                table: "Church");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Church");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Church",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Church",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Complement",
                table: "Church",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Neighborhood",
                table: "Church",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Number",
                table: "Church",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "Church",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Church",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_ZipCode",
                table: "Church",
                type: "text",
                nullable: true);
        }
    }
}
