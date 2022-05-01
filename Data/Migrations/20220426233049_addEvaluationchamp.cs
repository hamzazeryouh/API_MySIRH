using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_MySIRH.Migrations
{
    public partial class addEvaluationchamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Evaluation",
                table: "Candidats",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Evaluation",
                table: "Candidats");
        }
    }
}
