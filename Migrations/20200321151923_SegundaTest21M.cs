using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPIAgendaTOP.Migrations
{
    public partial class SegundaTest21M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipoTarea",
                table: "Agenda");

            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "Agenda",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipo",
                table: "Agenda");

            migrationBuilder.AddColumn<string>(
                name: "tipoTarea",
                table: "Agenda",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
