using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPIAgendaTOP.Migrations
{
    public partial class InicialTest21M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: false),
                    direccion = table.Column<string>(nullable: true),
                    poblacion = table.Column<string>(nullable: true),
                    provincia = table.Column<string>(nullable: true),
                    telefono1 = table.Column<string>(nullable: true),
                    telefono2 = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TablasGenerales",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaveTabla = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Valor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablasGenerales", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(nullable: false),
                    descripcion = table.Column<string>(nullable: false),
                    tipoTarea = table.Column<string>(nullable: false),
                    importe = table.Column<int>(nullable: false),
                    estado = table.Column<string>(nullable: true),
                    Idcliente = table.Column<int>(nullable: false),
                    clienteid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.id);
                    table.ForeignKey(
                        name: "FK_Agenda_Clientes_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_clienteid",
                table: "Agenda",
                column: "clienteid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "TablasGenerales");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
