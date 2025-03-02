using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPrestamos.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionCuotas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuotasDetalle_Deudores_DeudorId",
                table: "CuotasDetalle");

            migrationBuilder.DropIndex(
                name: "IX_CuotasDetalle_DeudorId",
                table: "CuotasDetalle");

            migrationBuilder.DropColumn(
                name: "DeudorId",
                table: "CuotasDetalle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeudorId",
                table: "CuotasDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CuotasDetalle_DeudorId",
                table: "CuotasDetalle",
                column: "DeudorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuotasDetalle_Deudores_DeudorId",
                table: "CuotasDetalle",
                column: "DeudorId",
                principalTable: "Deudores",
                principalColumn: "DeudorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
