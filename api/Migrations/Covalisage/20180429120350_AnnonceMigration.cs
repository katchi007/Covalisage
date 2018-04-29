using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace api.Migrations.Covalisage
{
    public partial class AnnonceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "dateDepart",
                table: "Annonces",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "dateArrivee",
                table: "Annonces",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "dateDepart",
                table: "Annonces",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateArrivee",
                table: "Annonces",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
