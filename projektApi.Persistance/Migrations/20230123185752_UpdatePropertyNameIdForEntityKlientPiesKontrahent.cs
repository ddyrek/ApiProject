using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projektApi.Persistance.Migrations
{
    public partial class UpdatePropertyNameIdForEntityKlientPiesKontrahent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pies_id",
                table: "Wizyty");

            migrationBuilder.DropColumn(
                name: "Klient_Id",
                table: "Psy");

            migrationBuilder.DropColumn(
                name: "Kod_Kon_Id",
                table: "Psy");

            migrationBuilder.DropColumn(
                name: "Kod_Kon_Id",
                table: "Klienci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pies_id",
                table: "Wizyty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Klient_Id",
                table: "Psy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Kod_Kon_Id",
                table: "Psy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Kod_Kon_Id",
                table: "Klienci",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
