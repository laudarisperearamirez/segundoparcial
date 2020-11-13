using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Identificacion = table.Column<string>(nullable: false),
                    TipoIdentificacion = table.Column<string>(nullable: true),
                    PrimerNombre = table.Column<string>(nullable: true),
                    PrimerApellido = table.Column<string>(nullable: true),
                    Departamento = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    Codigo = table.Column<string>(nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Valorpago = table.Column<decimal>(nullable: false),
                    Valoriva = table.Column<decimal>(nullable: false),
                    Identificacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.Codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Pago");
        }
    }
}
