using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPrestamos.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionCuotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuotas_CuotasDetalle_PrestamoId",
                table: "Cuotas");

            migrationBuilder.RenameColumn(
                name: "PrestamoId",
                table: "Cuotas",
                newName: "CuotasDetalleId");

            migrationBuilder.RenameIndex(
                name: "IX_Cuotas_PrestamoId",
                table: "Cuotas",
                newName: "IX_Cuotas_CuotasDetalleId");

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
                name: "FK_Cuotas_CuotasDetalle_CuotasDetalleId",
                table: "Cuotas",
                column: "CuotasDetalleId",
                principalTable: "CuotasDetalle",
                principalColumn: "CuotasDetalleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CuotasDetalle_Deudores_DeudorId",
                table: "CuotasDetalle",
                column: "DeudorId",
                principalTable: "Deudores",
                principalColumn: "DeudorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuotas_CuotasDetalle_CuotasDetalleId",
                table: "Cuotas");

            migrationBuilder.DropForeignKey(
                name: "FK_CuotasDetalle_Deudores_DeudorId",
                table: "CuotasDetalle");

            migrationBuilder.DropIndex(
                name: "IX_CuotasDetalle_DeudorId",
                table: "CuotasDetalle");

            migrationBuilder.DropColumn(
                name: "DeudorId",
                table: "CuotasDetalle");

            migrationBuilder.RenameColumn(
                name: "CuotasDetalleId",
                table: "Cuotas",
                newName: "PrestamoId");

            migrationBuilder.RenameIndex(
                name: "IX_Cuotas_CuotasDetalleId",
                table: "Cuotas",
                newName: "IX_Cuotas_PrestamoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuotas_CuotasDetalle_PrestamoId",
                table: "Cuotas",
                column: "PrestamoId",
                principalTable: "CuotasDetalle",
                principalColumn: "CuotasDetalleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
