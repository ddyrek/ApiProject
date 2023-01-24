using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projektApi.Persistance.Migrations
{
    public partial class SeedClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
