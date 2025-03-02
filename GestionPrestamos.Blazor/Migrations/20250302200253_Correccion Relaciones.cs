using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionPrestamos.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cobros",
                columns: new[] { "CobroId", "DeudorId", "Fecha", "Monto" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 2, 16, 2, 52, 792, DateTimeKind.Local).AddTicks(652), 500.0 },
                    { 2, 2, new DateTime(2025, 3, 2, 16, 2, 52, 793, DateTimeKind.Local).AddTicks(6920), 300.0 }
                });

            migrationBuilder.InsertData(
                table: "Deudores",
                columns: new[] { "DeudorId", "Nombres" },
                values: new object[,]
                {
                    { 3, "Carlos Sanchez" },
                    { 4, "Ana Torres" },
                    { 5, "Luis Ramirez" }
                });

            migrationBuilder.InsertData(
                table: "Prestamos",
                columns: new[] { "PrestamoId", "Balance", "Concepto", "DeudorId", "Monto" },
                values: new object[,]
                {
                    { 1, 15000.0, "Compra de vehículo", 1, 15000.0 },
                    { 2, 5000.0, "Estudio", 2, 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "CobrosDetalle",
                columns: new[] { "DetalleId", "CobroId", "PrestamoId", "ValorCobrado" },
                values: new object[,]
                {
                    { 1, 1, 1, 500.0 },
                    { 2, 2, 2, 300.0 }
                });

            migrationBuilder.InsertData(
                table: "CuotasDetalle",
                columns: new[] { "CuotasDetalleId", "CuotasNo", "PrestamoId" },
                values: new object[,]
                {
                    { 1, 12, 1 },
                    { 2, 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "Prestamos",
                columns: new[] { "PrestamoId", "Balance", "Concepto", "DeudorId", "Monto" },
                values: new object[] { 3, 8000.0, "Mejoras en casa", 3, 8000.0 });

            migrationBuilder.InsertData(
                table: "Cuotas",
                columns: new[] { "CuotaId", "Balance", "CuotasDetalleId", "Fecha", "Valor" },
                values: new object[,]
                {
                    { 1, 0.0, 1, new DateTime(2025, 3, 2, 16, 2, 52, 794, DateTimeKind.Local).AddTicks(828), 500.0 },
                    { 2, 0.0, 2, new DateTime(2025, 3, 2, 16, 2, 52, 794, DateTimeKind.Local).AddTicks(1540), 300.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CobrosDetalle",
                keyColumn: "DetalleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CobrosDetalle",
                keyColumn: "DetalleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cuotas",
                keyColumn: "CuotaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cuotas",
                keyColumn: "CuotaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Deudores",
                keyColumn: "DeudorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Deudores",
                keyColumn: "DeudorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Prestamos",
                keyColumn: "PrestamoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cobros",
                keyColumn: "CobroId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cobros",
                keyColumn: "CobroId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CuotasDetalle",
                keyColumn: "CuotasDetalleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CuotasDetalle",
                keyColumn: "CuotasDetalleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Deudores",
                keyColumn: "DeudorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prestamos",
                keyColumn: "PrestamoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prestamos",
                keyColumn: "PrestamoId",
                keyValue: 2);
        }
    }
}
