using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projektApi.Persistance.Migrations
{
    public partial class update_Entity_Kontrahent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Utworzono",
                table: "Kontrahenci");

            migrationBuilder.DropColumn(
                name: "Zmodyfikowano",
                table: "Kontrahenci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Utworzono",
                table: "Kontrahenci",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Zmodyfikowano",
                table: "Kontrahenci",
                type: "datetime2",
                nullable: true);
        }
    }
}
