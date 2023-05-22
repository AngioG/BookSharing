using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Sharing.Migrations.DataDb
{
    public partial class Dati3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Utenti",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Utenti");
        }
    }
}
