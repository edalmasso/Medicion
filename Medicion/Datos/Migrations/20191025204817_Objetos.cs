using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medicion.Migrations
{
    public partial class Objetos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioEmpresa");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Empresa",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icono",
                table: "Empresa",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Localidad",
                table: "Empresa",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Empresa",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Empresa",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Empresa",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    EmpresaId = table.Column<int>(nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    Desde = table.Column<DateTime>(nullable: false),
                    Hasta = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContratoId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Localidad = table.Column<string>(nullable: true),
                    Provincia = table.Column<string>(nullable: true),
                    Estudio = table.Column<string>(nullable: true),
                    FechaCreado = table.Column<DateTime>(nullable: false),
                    FechaBaja = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proyectos_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PuntoEstudios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Localidad = table.Column<string>(nullable: true),
                    Latitud = table.Column<string>(nullable: true),
                    Longitud = table.Column<string>(nullable: true),
                    FechaCreado = table.Column<DateTime>(nullable: false),
                    FechaBaja = table.Column<DateTime>(nullable: true),
                    Pozo_Profundidad = table.Column<int>(nullable: false),
                    Pozo_Diametro = table.Column<int>(nullable: false),
                    Punzado_Largo = table.Column<int>(nullable: false),
                    Punzado_Diametro = table.Column<int>(nullable: false),
                    Temp_Pozo = table.Column<int>(nullable: false),
                    DensidadRoca = table.Column<int>(nullable: false),
                    Saturacion = table.Column<int>(nullable: false),
                    Presion = table.Column<int>(nullable: false),
                    DensidadFluido = table.Column<int>(nullable: false),
                    ProyectoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoEstudios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PuntoEstudios_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DatosPuntos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<int>(nullable: false),
                    PuntoEstudioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosPuntos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatosPuntos_PuntoEstudios_PuntoEstudioId",
                        column: x => x.PuntoEstudioId,
                        principalTable: "PuntoEstudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2019, 10, 25, 17, 48, 17, 31, DateTimeKind.Local).AddTicks(6795));

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2019, 10, 25, 17, 48, 17, 33, DateTimeKind.Local).AddTicks(931));

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2019, 10, 25, 17, 48, 17, 33, DateTimeKind.Local).AddTicks(972));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmpresaId",
                table: "AspNetUsers",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_EmpresaId",
                table: "Contratos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_DatosPuntos_PuntoEstudioId",
                table: "DatosPuntos",
                column: "PuntoEstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_ContratoId",
                table: "Proyectos",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_PuntoEstudios_ProyectoId",
                table: "PuntoEstudios",
                column: "ProyectoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Empresa_EmpresaId",
                table: "AspNetUsers",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Empresa_EmpresaId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DatosPuntos");

            migrationBuilder.DropTable(
                name: "PuntoEstudios");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmpresaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Icono",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Localidad",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UsuarioEmpresa",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEmpresa", x => new { x.EmpresaId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_UsuarioEmpresa_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioEmpresa_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2019, 10, 18, 15, 15, 48, 249, DateTimeKind.Local).AddTicks(7057));

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2019, 10, 18, 15, 15, 48, 250, DateTimeKind.Local).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2019, 10, 18, 15, 15, 48, 250, DateTimeKind.Local).AddTicks(7235));

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmpresa_UsuarioId",
                table: "UsuarioEmpresa",
                column: "UsuarioId");
        }
    }
}
