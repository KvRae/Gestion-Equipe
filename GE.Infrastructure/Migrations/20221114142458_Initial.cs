using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GE.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    EquipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdresseLocal = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NomEquipe = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.EquipeId);
                });

            migrationBuilder.CreateTable(
                name: "Membres",
                columns: table => new
                {
                    Identifiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    Poste = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membres", x => x.Identifiant);
                });

            migrationBuilder.CreateTable(
                name: "Trophees",
                columns: table => new
                {
                    TropheeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTrophee = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recompense = table.Column<double>(type: "float", nullable: false),
                    EquipeFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trophees", x => x.TropheeId);
                    table.ForeignKey(
                        name: "FK_Trophees_Equipes_EquipeFK",
                        column: x => x.EquipeFK,
                        principalTable: "Equipes",
                        principalColumn: "EquipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contrats",
                columns: table => new
                {
                    EquipeFK = table.Column<int>(type: "int", nullable: false),
                    MembreFK = table.Column<int>(type: "int", nullable: false),
                    DateContrat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DureeMMois = table.Column<short>(type: "smallint", nullable: false),
                    Salaire = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrats", x => new { x.DateContrat, x.EquipeFK, x.MembreFK });
                    table.ForeignKey(
                        name: "FK_Contrats_Equipes_EquipeFK",
                        column: x => x.EquipeFK,
                        principalTable: "Equipes",
                        principalColumn: "EquipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrats_Membres_MembreFK",
                        column: x => x.MembreFK,
                        principalTable: "Membres",
                        principalColumn: "Identifiant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contrats_EquipeFK",
                table: "Contrats",
                column: "EquipeFK");

            migrationBuilder.CreateIndex(
                name: "IX_Contrats_MembreFK",
                table: "Contrats",
                column: "MembreFK");

            migrationBuilder.CreateIndex(
                name: "IX_Trophees_EquipeFK",
                table: "Trophees",
                column: "EquipeFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contrats");

            migrationBuilder.DropTable(
                name: "Trophees");

            migrationBuilder.DropTable(
                name: "Membres");

            migrationBuilder.DropTable(
                name: "Equipes");
        }
    }
}
