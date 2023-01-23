using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projektApi.Persistance.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Psy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Kontrahenci",
                columns: new[] { "Id", "Created", "CreatedBy", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "Nazwa_firmy", "Nip", "Numer_budynku", "Numer_lokalu", "StatusId", "Ulica" },
                values: new object[] { 1, new DateTime(2023, 1, 23, 21, 15, 59, 347, DateTimeKind.Local).AddTicks(369), "Dawid", null, null, null, null, "Top Dogs", null, null, null, 1, null });

            migrationBuilder.InsertData(
                table: "Klienci",
                columns: new[] { "Id", "Created", "CreatedBy", "Inactivated", "InactivatedBy", "KontrahentId", "Modified", "ModifiedBy", "Phone_number", "StatusId", "KlientName_Name", "KlientName_Surname" },
                values: new object[] { 1, new DateTime(2023, 1, 23, 21, 15, 59, 348, DateTimeKind.Local).AddTicks(3565), "Dawid", null, null, 1, null, null, "+48 606327833", 1, "Andrzej", "Trycz" });

            migrationBuilder.InsertData(
                table: "Psy",
                columns: new[] { "Id", "Description", "KlientId", "KontrahentId", "Name", "Race" },
                values: new object[] { 1, null, 1, 1, "Jackie", "BORDER COLLIE" });

            migrationBuilder.InsertData(
                table: "Psy",
                columns: new[] { "Id", "Description", "KlientId", "KontrahentId", "Name", "Race" },
                values: new object[] { 2, null, 1, 1, "Fifi", "BORDER TERRIER" });

            migrationBuilder.InsertData(
                table: "Wizyty",
                columns: new[] { "Id", "Data_wizyty", "Godzina_wizyty", "Kwota", "Opis", "PiesId" },
                values: new object[] { 1, new DateTime(2023, 1, 23, 21, 15, 59, 348, DateTimeKind.Local).AddTicks(3870), new DateTime(2023, 1, 23, 21, 15, 59, 348, DateTimeKind.Local).AddTicks(3876), 350m, "Strzyżenie", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Psy",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wizyty",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Psy",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Klienci",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kontrahenci",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Psy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
