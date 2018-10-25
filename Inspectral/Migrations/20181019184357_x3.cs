using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inspectral.Migrations
{
    public partial class x3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seccion_Informe_InformeID",
                table: "Seccion");

            migrationBuilder.AlterColumn<int>(
                name: "InformeID",
                table: "Seccion",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Contenido",
                table: "Seccion",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Individualizacion",
                columns: table => new
                {
                    IndividualizacionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tanque = table.Column<string>(nullable: true),
                    Comprador = table.Column<string>(nullable: true),
                    Fabricante = table.Column<string>(nullable: true),
                    FechaFabricación = table.Column<DateTime>(nullable: false),
                    Capacidad = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    TipoTanque = table.Column<string>(nullable: true),
                    NormaReferencia = table.Column<string>(nullable: true),
                    FechaInicioInspeccion = table.Column<DateTime>(nullable: false),
                    FechaTerminoInspeccion = table.Column<DateTime>(nullable: false),
                    HoraInicio = table.Column<DateTime>(nullable: false),
                    HoraTermino = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individualizacion", x => x.IndividualizacionID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Seccion_Informe_InformeID",
                table: "Seccion",
                column: "InformeID",
                principalTable: "Informe",
                principalColumn: "InformeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seccion_Informe_InformeID",
                table: "Seccion");

            migrationBuilder.DropTable(
                name: "Individualizacion");

            migrationBuilder.AlterColumn<int>(
                name: "InformeID",
                table: "Seccion",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Contenido",
                table: "Seccion",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seccion_Informe_InformeID",
                table: "Seccion",
                column: "InformeID",
                principalTable: "Informe",
                principalColumn: "InformeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
