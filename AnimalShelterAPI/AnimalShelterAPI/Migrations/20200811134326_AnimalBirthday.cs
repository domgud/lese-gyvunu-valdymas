using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelterAPI.Migrations
{
    public partial class AnimalBirthday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Animals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransferOrganisationContacts",
                table: "Animals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "TransferOrganisationContacts",
                table: "Animals");
        }
    }
}
