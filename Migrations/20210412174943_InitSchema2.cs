using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FizzBuzzWeb.Migrations
{
    public partial class InitSchema2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wpisy",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Liczba = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Wynik = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wpisy", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wpisy");
        }
    }
}
