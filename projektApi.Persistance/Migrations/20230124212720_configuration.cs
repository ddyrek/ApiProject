using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projektApi.Persistance.Migrations
{
    public partial class configuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KlientName_Surname",
                table: "Klienci",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "KlientName_Name",
                table: "Klienci",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Psy",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Klienci",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 1, 24, 22, 27, 20, 314, DateTimeKind.Local).AddTicks(5647));

            migrationBuilder.UpdateData(
                table: "Kontrahenci",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 1, 24, 22, 27, 20, 314, DateTimeKind.Local).AddTicks(5534));

            migrationBuilder.UpdateData(
                table: "Wizyty",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataWizyty", "GodzinaWizyty" },
                values: new object[] { new DateTime(2023, 1, 24, 22, 27, 20, 314, DateTimeKind.Local).AddTicks(5794), new DateTime(2023, 1, 24, 22, 27, 20, 314, DateTimeKind.Local).AddTicks(5798) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Klienci",
                newName: "KlientName_Surname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Klienci",
                newName: "KlientName_Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Psy",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.UpdateData(
                table: "Klienci",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 1, 24, 19, 49, 35, 662, DateTimeKind.Local).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "Kontrahenci",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 1, 24, 19, 49, 35, 662, DateTimeKind.Local).AddTicks(7922));

            migrationBuilder.UpdateData(
                table: "Wizyty",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataWizyty", "GodzinaWizyty" },
                values: new object[] { new DateTime(2023, 1, 24, 19, 49, 35, 662, DateTimeKind.Local).AddTicks(8389), new DateTime(2023, 1, 24, 19, 49, 35, 662, DateTimeKind.Local).AddTicks(8394) });
        }
    }
}
