using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_MySIRH.Migrations
{
    public partial class addCollaborateurs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collaborateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Matricule = table.Column<string>(type: "TEXT", nullable: false),
                    Civilite = table.Column<string>(type: "TEXT", nullable: false),
                    ModeRecrutement = table.Column<string>(type: "TEXT", nullable: false),
                    DatePremiereExperience = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateEntreeSqli = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateSortieSqli = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateDebutStage = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Diplomes = table.Column<string>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborateurs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collaborateurs");
        }
    }
}
