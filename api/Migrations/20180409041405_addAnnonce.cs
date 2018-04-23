using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace covalisage.Migrations
{
    public partial class addAnnonce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Annonces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Note = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    dateArrivee = table.Column<DateTime>(nullable: false),
                    dateDepart = table.Column<DateTime>(nullable: false),
                    lieuArrivee = table.Column<string>(nullable: true),
                    lieuDepart = table.Column<string>(nullable: true),
                    poidDisponible = table.Column<int>(nullable: false),
                    prixKg = table.Column<decimal>(nullable: false),
                    titre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annonces", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annonces");
        }
    }
}
