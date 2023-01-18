using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projektApi.Persistance.Migrations
{
    public partial class add_Wizyta_entit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wizyty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_wizyty = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Godzina_wizyty = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Opis = table.Column<long>(type: "bigint", nullable: false),
                    Kwota = table.Column<double>(type: "float", nullable: true),
                    Pies_id = table.Column<int>(type: "int", nullable: false),
                    PiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wizyty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wizyty_Psy_PiesId",
                        column: x => x.PiesId,
                        principalTable: "Psy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_PiesId",
                table: "Wizyty",
                column: "PiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wizyty");
        }
    }
}
