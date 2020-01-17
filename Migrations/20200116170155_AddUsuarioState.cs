using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pruebas.Migrations
{
    public partial class AddUsuarioState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sesion",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<string>(nullable: true),
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
                        name: "FK_Sesion_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
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

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "AspNetUsers");
        }
    }
}
