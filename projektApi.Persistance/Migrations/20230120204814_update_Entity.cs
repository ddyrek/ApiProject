using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projektApi.Persistance.Migrations
{
    public partial class update_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Psy");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Psy");

            migrationBuilder.DropColumn(
                name: "Inactivated",
                table: "Psy");

            migrationBuilder.DropColumn(
                name: "InactivatedBy",
                table: "Psy");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Psy");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Psy");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Psy");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Kontrahenci",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InactivatedBy",
                table: "Kontrahenci",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Klienci",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InactivatedBy",
                table: "Klienci",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Psy",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Psy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Inactivated",
                table: "Psy",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InactivatedBy",
                table: "Psy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Psy",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Psy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Psy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Kontrahenci",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InactivatedBy",
                table: "Kontrahenci",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Klienci",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InactivatedBy",
                table: "Klienci",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
