using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projektApi.Persistance.Migrations
{
    public partial class UpdatePropertyNameNotLowerCaseAndNipToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Godzina_wizyty",
                table: "Wizyty",
                newName: "GodzinaWizyty");

            migrationBuilder.RenameColumn(
                name: "Data_wizyty",
                table: "Wizyty",
                newName: "DataWizyty");

            migrationBuilder.RenameColumn(
                name: "Numer_lokalu",
                table: "Kontrahenci",
                newName: "NumerLokalu");

            migrationBuilder.RenameColumn(
                name: "Numer_budynku",
                table: "Kontrahenci",
                newName: "NumerBudynku");

            migrationBuilder.RenameColumn(
                name: "Nazwa_firmy",
                table: "Kontrahenci",
                newName: "NazwaFirmy");

            migrationBuilder.RenameColumn(
                name: "Phone_number",
                table: "Klienci",
                newName: "PhoneNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Nip",
                table: "Kontrahenci",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Klienci",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 1, 23, 22, 22, 41, 673, DateTimeKind.Local).AddTicks(8448));

            migrationBuilder.UpdateData(
                table: "Kontrahenci",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 1, 23, 22, 22, 41, 672, DateTimeKind.Local).AddTicks(6790));

            migrationBuilder.UpdateData(
                table: "Wizyty",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataWizyty", "GodzinaWizyty" },
                values: new object[] { new DateTime(2023, 1, 23, 22, 22, 41, 673, DateTimeKind.Local).AddTicks(8733), new DateTime(2023, 1, 23, 22, 22, 41, 673, DateTimeKind.Local).AddTicks(8737) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GodzinaWizyty",
                table: "Wizyty",
                newName: "Godzina_wizyty");

            migrationBuilder.RenameColumn(
                name: "DataWizyty",
                table: "Wizyty",
                newName: "Data_wizyty");

            migrationBuilder.RenameColumn(
                name: "NumerLokalu",
                table: "Kontrahenci",
                newName: "Numer_lokalu");

            migrationBuilder.RenameColumn(
                name: "NumerBudynku",
                table: "Kontrahenci",
                newName: "Numer_budynku");

            migrationBuilder.RenameColumn(
                name: "NazwaFirmy",
                table: "Kontrahenci",
                newName: "Nazwa_firmy");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Klienci",
                newName: "Phone_number");

            migrationBuilder.AlterColumn<decimal>(
                name: "Nip",
                table: "Kontrahenci",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Klienci",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 1, 23, 21, 15, 59, 348, DateTimeKind.Local).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "Kontrahenci",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 1, 23, 21, 15, 59, 347, DateTimeKind.Local).AddTicks(369));

            migrationBuilder.UpdateData(
                table: "Wizyty",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Data_wizyty", "Godzina_wizyty" },
                values: new object[] { new DateTime(2023, 1, 23, 21, 15, 59, 348, DateTimeKind.Local).AddTicks(3870), new DateTime(2023, 1, 23, 21, 15, 59, 348, DateTimeKind.Local).AddTicks(3876) });
        }
    }
}
