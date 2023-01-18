using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projektApi.Persistance.Migrations
{
    public partial class modify_entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Klienci",
                newName: "KlientName_Surname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Klienci",
                newName: "KlientName_Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KlientName_Surname",
                table: "Klienci",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "KlientName_Name",
                table: "Klienci",
                newName: "Name");
        }
    }
}
