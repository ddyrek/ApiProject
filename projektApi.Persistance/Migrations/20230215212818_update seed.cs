using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projektApi.Persistance.Migrations
{
    public partial class updateseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Klienci",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 2, 15, 22, 28, 18, 154, DateTimeKind.Local).AddTicks(4706));

            migrationBuilder.UpdateData(
                table: "Kontrahenci",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 2, 15, 22, 28, 18, 154, DateTimeKind.Local).AddTicks(4559));

            migrationBuilder.InsertData(
                table: "Kontrahenci",
                columns: new[] { "Id", "Created", "CreatedBy", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "NazwaFirmy", "Nip", "NumerBudynku", "NumerLokalu", "StatusId", "Ulica" },
                values: new object[] { 2, new DateTime(2023, 2, 15, 22, 28, 18, 154, DateTimeKind.Local).AddTicks(4592), "Dawid", null, null, null, null, "Free Sp. z o.o.", null, null, null, 1, null });

            migrationBuilder.UpdateData(
                table: "Wizyty",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataWizyty", "GodzinaWizyty" },
                values: new object[] { new DateTime(2023, 2, 15, 22, 28, 18, 154, DateTimeKind.Local).AddTicks(4891), new DateTime(2023, 2, 15, 22, 28, 18, 154, DateTimeKind.Local).AddTicks(4894) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kontrahenci",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Klienci",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 1, 25, 22, 20, 45, 5, DateTimeKind.Local).AddTicks(7246));

            migrationBuilder.UpdateData(
                table: "Kontrahenci",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 1, 25, 22, 20, 45, 5, DateTimeKind.Local).AddTicks(7088));

            migrationBuilder.UpdateData(
                table: "Wizyty",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataWizyty", "GodzinaWizyty" },
                values: new object[] { new DateTime(2023, 1, 25, 22, 20, 45, 5, DateTimeKind.Local).AddTicks(7511), new DateTime(2023, 1, 25, 22, 20, 45, 5, DateTimeKind.Local).AddTicks(7518) });
        }
    }
}
