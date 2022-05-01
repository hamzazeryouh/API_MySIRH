using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_MySIRH.Migrations
{
    public partial class EntityBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ToDoLists",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ToDoLists");
        }
    }
}
