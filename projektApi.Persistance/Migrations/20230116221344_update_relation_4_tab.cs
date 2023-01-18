using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projektApi.Persistance.Migrations
{
    public partial class update_relation_4_tab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Kod_Kon_Id",
                table: "Psy",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Kod_Kon_Id",
                table: "Klienci",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "KontrahentId",
                table: "Klienci",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Klienci_KontrahentId",
                table: "Klienci",
                column: "KontrahentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Klienci_Kontrahenci_KontrahentId",
                table: "Klienci",
                column: "KontrahentId",
                principalTable: "Kontrahenci",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction); //po utworzeniu migracji było Cascade, zmieniłem na NoAction żeby chciała przejść aktualizacja
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klienci_Kontrahenci_KontrahentId",
                table: "Klienci");

            migrationBuilder.DropIndex(
                name: "IX_Klienci_KontrahentId",
                table: "Klienci");

            migrationBuilder.DropColumn(
                name: "KontrahentId",
                table: "Klienci");

            migrationBuilder.AlterColumn<int>(
                name: "Kod_Kon_Id",
                table: "Psy",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Kod_Kon_Id",
                table: "Klienci",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
