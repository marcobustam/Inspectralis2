using Microsoft.EntityFrameworkCore.Migrations;

namespace Inspectral.Migrations
{
    public partial class x2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndividualizacionID",
                table: "Informe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Informe_IndividualizacionID",
                table: "Informe",
                column: "IndividualizacionID");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Informe_Individualizacion_IndividualizacionID",
                table: "Informe");

            migrationBuilder.DropIndex(
                name: "IX_Informe_IndividualizacionID",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "IndividualizacionID",
                table: "Informe");
        }
    }
}
