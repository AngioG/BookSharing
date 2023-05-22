using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Sharing.Migrations.DataDb
{
    public partial class Dati2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Autore",
                table: "UtentiLibri",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Titolo",
                table: "UtentiLibri",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autore",
                table: "UtentiLibri");

            migrationBuilder.DropColumn(
                name: "Titolo",
                table: "UtentiLibri");
        }
    }
}
