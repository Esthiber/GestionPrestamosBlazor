using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionPrestamos.Migrations
{
    /// <inheritdoc />
    public partial class CorrecciondeRelacionenPrestamos_CuotasDetalleyrelacionconcobros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CuotasDetalle_PrestamoId",
                table: "CuotasDetalle");

            migrationBuilder.DeleteData(
                table: "CobrosDetalle",
                keyColumn: "DetalleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CobrosDetalle",
                keyColumn: "DetalleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cobros",
                keyColumn: "CobroId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cobros",
                keyColumn: "CobroId",
                keyValue: 2);

            migrationBuilder.AlterColumn<double>(
                name: "Monto",
                table: "Prestamos",
                type: "float(18)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Nombres",
                table: "Deudores",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "CuotasDetalle",
                columns: new[] { "CuotasDetalleId", "CuotasNo", "PrestamoId" },
                values: new object[] { 3, 10, 3 });

            migrationBuilder.UpdateData(
                table: "Prestamos",
                keyColumn: "PrestamoId",
                keyValue: 1,
                column: "Balance",
                value: 14500.0);

            migrationBuilder.InsertData(
                table: "Cuotas",
                columns: new[] { "CuotaId", "Balance", "CuotaNo", "CuotasDetalleId", "Fecha", "Valor" },
                values: new object[] { 3, 800.0, 0, 3, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 800.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Deudores_Nombres",
                table: "Deudores",
                column: "Nombres",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CuotasDetalle_PrestamoId",
                table: "CuotasDetalle",
                column: "PrestamoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CobrosDetalle_PrestamoId",
                table: "CobrosDetalle",
                column: "PrestamoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CobrosDetalle_Prestamos_PrestamoId",
                table: "CobrosDetalle",
                column: "PrestamoId",
                principalTable: "Prestamos",
                principalColumn: "PrestamoId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CobrosDetalle_Prestamos_PrestamoId",
                table: "CobrosDetalle");

            migrationBuilder.DropIndex(
                name: "IX_Deudores_Nombres",
                table: "Deudores");

            migrationBuilder.DropIndex(
                name: "IX_CuotasDetalle_PrestamoId",
                table: "CuotasDetalle");

            migrationBuilder.DropIndex(
                name: "IX_CobrosDetalle_PrestamoId",
                table: "CobrosDetalle");

            migrationBuilder.DeleteData(
                table: "Cuotas",
                keyColumn: "CuotaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CuotasDetalle",
                keyColumn: "CuotasDetalleId",
                keyValue: 3);

            migrationBuilder.AlterColumn<double>(
                name: "Monto",
                table: "Prestamos",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(18)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Nombres",
                table: "Deudores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Cobros",
                columns: new[] { "CobroId", "DeudorId", "Fecha", "Monto" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0 },
                    { 2, 2, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 300.0 }
                });

            migrationBuilder.UpdateData(
                table: "Prestamos",
                keyColumn: "PrestamoId",
                keyValue: 1,
                column: "Balance",
                value: 15000.0);

            migrationBuilder.InsertData(
                table: "CobrosDetalle",
                columns: new[] { "DetalleId", "CobroId", "PrestamoId", "ValorCobrado" },
                values: new object[,]
                {
                    { 1, 1, 1, 500.0 },
                    { 2, 2, 2, 300.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuotasDetalle_PrestamoId",
                table: "CuotasDetalle",
                column: "PrestamoId");
        }
    }
}
