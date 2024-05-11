using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Integrador_Prestamos.Migrations
{
    public partial class v24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fechaIniVigencia",
                table: "Cuotas",
                newName: "FechaCuota");

            migrationBuilder.AddColumn<int>(
                name: "IdPrestatario",
                table: "Cuotas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "pagoDiario",
                table: "Cuotas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPrestatario",
                table: "Cuotas");

            migrationBuilder.DropColumn(
                name: "pagoDiario",
                table: "Cuotas");

            migrationBuilder.RenameColumn(
                name: "FechaCuota",
                table: "Cuotas",
                newName: "fechaIniVigencia");
        }
    }
}
