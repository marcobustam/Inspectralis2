using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inspectral.Migrations
{
    public partial class x01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Informe",
                columns: table => new
                {
                    InformeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    CodigoSEC = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informe", x => x.InformeID);
                });

            migrationBuilder.CreateTable(
                name: "Seccion",
                columns: table => new
                {
                    SeccionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Orden = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Contenido = table.Column<string>(nullable: true),
                    InformeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seccion", x => x.SeccionID);
                    table.ForeignKey(
                        name: "FK_Seccion_Informe_InformeID",
                        column: x => x.InformeID,
                        principalTable: "Informe",
                        principalColumn: "InformeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seccion_InformeID",
                table: "Seccion",
                column: "InformeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seccion");

            migrationBuilder.DropTable(
                name: "Informe");
        }
    }
}
