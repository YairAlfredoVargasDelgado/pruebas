using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pruebas.Migrations
{
    public partial class NoSe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sesion");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Clave",
                table: "AspNetUsers",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Conectado",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Clave",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Conectado",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombres",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Apellidos = table.Column<string>(type: "TEXT", nullable: true),
                    Clave = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Rol = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sesion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Estado = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ip = table.Column<string>(type: "TEXT", nullable: true),
                    Latitud = table.Column<float>(type: "REAL", nullable: false),
                    Longitud = table.Column<float>(type: "REAL", nullable: false),
                    UsuarioId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sesion_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sesion_UsuarioId",
                table: "Sesion",
                column: "UsuarioId");
        }
    }
}
