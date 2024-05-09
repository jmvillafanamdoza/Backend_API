using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Integrador_Prestamos.Migrations
{
    public partial class v20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Precios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuracionDias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio150 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Precio200 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Precio300 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Precio400 = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Precio500 = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    NroPrestamo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    pagoDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    diasDuracion = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaIniVigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaFinVigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idPrestatario = table.Column<int>(type: "int", nullable: false),
                    idPrestamista = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamo", x => x.NroPrestamo);
                });

            migrationBuilder.CreateTable(
                name: "Sede",
                columns: table => new
                {
                    idSede = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcionSede = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sede", x => x.idSede);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creatorUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.idUser);
                });

            migrationBuilder.CreateTable(
                name: "Inversionistas",
                columns: table => new
                {
                    idInversionista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSede = table.Column<int>(type: "int", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inversionistas", x => x.idInversionista);
                    table.ForeignKey(
                        name: "FK_Inversionistas_Sede_idSede",
                        column: x => x.idSede,
                        principalTable: "Sede",
                        principalColumn: "idSede",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inversionistas_users_idUser",
                        column: x => x.idUser,
                        principalTable: "users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JefesPrestamistas",
                columns: table => new
                {
                    idJefePrestamista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSede = table.Column<int>(type: "int", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JefesPrestamistas", x => x.idJefePrestamista);
                    table.ForeignKey(
                        name: "FK_JefesPrestamistas_Sede_idSede",
                        column: x => x.idSede,
                        principalTable: "Sede",
                        principalColumn: "idSede",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JefesPrestamistas_users_idUser",
                        column: x => x.idUser,
                        principalTable: "users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamistas",
                columns: table => new
                {
                    idPrestamista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSede = table.Column<int>(type: "int", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamistas", x => x.idPrestamista);
                    table.ForeignKey(
                        name: "FK_Prestamistas_Sede_idSede",
                        column: x => x.idSede,
                        principalTable: "Sede",
                        principalColumn: "idSede",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamistas_users_idUser",
                        column: x => x.idUser,
                        principalTable: "users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestatario",
                columns: table => new
                {
                    IdPrestatario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSede = table.Column<int>(type: "int", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestatario", x => x.IdPrestatario);
                    table.ForeignKey(
                        name: "FK_Prestatario_Sede_idSede",
                        column: x => x.idSede,
                        principalTable: "Sede",
                        principalColumn: "idSede",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestatario_users_idUser",
                        column: x => x.idUser,
                        principalTable: "users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inversionistas_idSede",
                table: "Inversionistas",
                column: "idSede");

            migrationBuilder.CreateIndex(
                name: "IX_Inversionistas_idUser",
                table: "Inversionistas",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_JefesPrestamistas_idSede",
                table: "JefesPrestamistas",
                column: "idSede");

            migrationBuilder.CreateIndex(
                name: "IX_JefesPrestamistas_idUser",
                table: "JefesPrestamistas",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamistas_idSede",
                table: "Prestamistas",
                column: "idSede");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamistas_idUser",
                table: "Prestamistas",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Prestatario_idSede",
                table: "Prestatario",
                column: "idSede");

            migrationBuilder.CreateIndex(
                name: "IX_Prestatario_idUser",
                table: "Prestatario",
                column: "idUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inversionistas");

            migrationBuilder.DropTable(
                name: "JefesPrestamistas");

            migrationBuilder.DropTable(
                name: "Precios");

            migrationBuilder.DropTable(
                name: "Prestamistas");

            migrationBuilder.DropTable(
                name: "Prestamo");

            migrationBuilder.DropTable(
                name: "Prestatario");

            migrationBuilder.DropTable(
                name: "Sede");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
