using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_MySIRH.Migrations
{
    public partial class AddCandidats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    Prenom = table.Column<string>(type: "TEXT", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Civilite = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Telephone = table.Column<string>(type: "TEXT", nullable: true),
                    DatePremiereExperience = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateDeNaissance = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SalaireActuel = table.Column<decimal>(type: "TEXT", nullable: true),
                    PropositionSalariale = table.Column<decimal>(type: "TEXT", nullable: true),
                    ResidenceActuelle = table.Column<string>(type: "TEXT", nullable: true),
                    EmploiEncore = table.Column<string>(type: "TEXT", nullable: true),
                    PosteId = table.Column<int>(type: "INTEGER", nullable: false),
                    PosteNiveauId = table.Column<int>(type: "INTEGER", nullable: false),
                    Commentaire = table.Column<string>(type: "TEXT", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidats_Niveaux_PosteNiveauId",
                        column: x => x.PosteNiveauId,
                        principalTable: "Niveaux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidats_Postes_PosteId",
                        column: x => x.PosteId,
                        principalTable: "Postes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidats_PosteId",
                table: "Candidats",
                column: "PosteId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidats_PosteNiveauId",
                table: "Candidats",
                column: "PosteNiveauId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidats");
        }
    }
}
