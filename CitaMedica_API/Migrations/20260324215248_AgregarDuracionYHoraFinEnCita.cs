using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitaMedica_API.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDuracionYHoraFinEnCita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duracion",
                table: "Citas",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraFin",
                table: "Citas",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duracion",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "HoraFin",
                table: "Citas");
        }
    }
}
