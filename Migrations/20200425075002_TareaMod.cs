using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPIAgendaTOP.Migrations
{
    public partial class TareaMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Clientes_clienteid",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "Idcliente",
                table: "Agenda");

            migrationBuilder.RenameColumn(
                name: "clienteid",
                table: "Agenda",
                newName: "Clienteid");

            migrationBuilder.RenameIndex(
                name: "IX_Agenda_clienteid",
                table: "Agenda",
                newName: "IX_Agenda_Clienteid");

            migrationBuilder.AlterColumn<string>(
                name: "usuario",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "clave",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cliente",
                table: "Agenda",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Clientes_Clienteid",
                table: "Agenda",
                column: "Clienteid",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Clientes_Clienteid",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "cliente",
                table: "Agenda");

            migrationBuilder.RenameColumn(
                name: "Clienteid",
                table: "Agenda",
                newName: "clienteid");

            migrationBuilder.RenameIndex(
                name: "IX_Agenda_Clienteid",
                table: "Agenda",
                newName: "IX_Agenda_clienteid");

            migrationBuilder.AlterColumn<string>(
                name: "usuario",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "clave",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Idcliente",
                table: "Agenda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Clientes_clienteid",
                table: "Agenda",
                column: "clienteid",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
