using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pruebas.Migrations
{
    public partial class AddUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Clave = table.Column<string>(maxLength: 20, nullable: true),
                    Rol = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sesion",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<long>(nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(nullable: false),
                    Ip = table.Column<string>(nullable: true),
                    Latitud = table.Column<float>(nullable: false),
                    Longitud = table.Column<float>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sesion");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
