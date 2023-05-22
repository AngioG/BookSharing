using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Sharing.Migrations.DataDb
{
    public partial class Dati : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regioni",
                columns: table => new
                {
                    PkRegione = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regioni", x => x.PkRegione);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    PkProvincia = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sigla = table.Column<string>(type: "TEXT", nullable: false),
                    fkRegione = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.PkProvincia);
                    table.ForeignKey(
                        name: "FK_Province_Regioni_fkRegione",
                        column: x => x.fkRegione,
                        principalTable: "Regioni",
                        principalColumn: "PkRegione",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    PkUtente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cognome = table.Column<string>(type: "TEXT", nullable: false),
                    CAP = table.Column<string>(type: "TEXT", maxLength: 5, nullable: false),
                    fkProvincia = table.Column<int>(type: "INTEGER", nullable: false),
                    IdentityUid = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.PkUtente);
                    table.ForeignKey(
                        name: "FK_Utenti_Province_fkProvincia",
                        column: x => x.fkProvincia,
                        principalTable: "Province",
                        principalColumn: "PkProvincia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UtentiLibri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdLibro = table.Column<string>(type: "TEXT", nullable: false),
                    Prestito = table.Column<bool>(type: "INTEGER", nullable: false),
                    Scambio = table.Column<bool>(type: "INTEGER", nullable: false),
                    Interesse = table.Column<bool>(type: "INTEGER", nullable: false),
                    fkUtente = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtentiLibri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UtentiLibri_Utenti_fkUtente",
                        column: x => x.fkUtente,
                        principalTable: "Utenti",
                        principalColumn: "PkUtente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Province_fkRegione",
                table: "Province",
                column: "fkRegione");

            migrationBuilder.CreateIndex(
                name: "IX_Utenti_fkProvincia",
                table: "Utenti",
                column: "fkProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_UtentiLibri_fkUtente",
                table: "UtentiLibri",
                column: "fkUtente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UtentiLibri");

            migrationBuilder.DropTable(
                name: "Utenti");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "Regioni");
        }
    }
}
