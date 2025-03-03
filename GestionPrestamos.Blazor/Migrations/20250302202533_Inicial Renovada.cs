using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionPrestamos.Migrations
{
    /// <inheritdoc />
    public partial class InicialRenovada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deudores",
                columns: table => new
                {
                    DeudorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deudores", x => x.DeudorId);
                });

            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    CobroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeudorId = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.CobroId);
                    table.ForeignKey(
                        name: "FK_Cobros_Deudores_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "Deudores",
                        principalColumn: "DeudorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Concepto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    DeudorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                    table.ForeignKey(
                        name: "FK_Prestamos_Deudores_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "Deudores",
                        principalColumn: "DeudorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CobrosDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CobroId = table.Column<int>(type: "int", nullable: false),
                    PrestamoId = table.Column<int>(type: "int", nullable: false),
                    ValorCobrado = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobrosDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_CobrosDetalle_Cobros_CobroId",
                        column: x => x.CobroId,
                        principalTable: "Cobros",
                        principalColumn: "CobroId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CuotasDetalle",
                columns: table => new
                {
                    CuotasDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrestamoId = table.Column<int>(type: "int", nullable: false),
                    CuotasNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuotasDetalle", x => x.CuotasDetalleId);
                    table.ForeignKey(
                        name: "FK_CuotasDetalle_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuotas",
                columns: table => new
                {
                    CuotaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuotasDetalleId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuotas", x => x.CuotaId);
                    table.ForeignKey(
                        name: "FK_Cuotas_CuotasDetalle_CuotasDetalleId",
                        column: x => x.CuotasDetalleId,
                        principalTable: "CuotasDetalle",
                        principalColumn: "CuotasDetalleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Deudores",
                columns: new[] { "DeudorId", "Nombres" },
                values: new object[,]
                {
                    { 1, "Jose Lopez" },
                    { 2, "Maria Perez" },
                    { 3, "Carlos Sanchez" },
                    { 4, "Ana Torres" },
                    { 5, "Luis Ramirez" }
                });

            migrationBuilder.InsertData(
                table: "Cobros",
                columns: new[] { "CobroId", "DeudorId", "Fecha", "Monto" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0 },
                    { 2, 2, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 300.0 }
                });

            migrationBuilder.InsertData(
                table: "Prestamos",
                columns: new[] { "PrestamoId", "Balance", "Concepto", "DeudorId", "Monto" },
                values: new object[,]
                {
                    { 1, 15000.0, "Compra de vehículo", 1, 15000.0 },
                    { 2, 5000.0, "Estudio", 2, 5000.0 },
                    { 3, 8000.0, "Mejoras en casa", 3, 8000.0 }
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
                table: "Cuotas",
                columns: new[] { "CuotaId", "Balance", "CuotasDetalleId", "Fecha", "Valor" },
                values: new object[,]
                {
                    { 1, 0.0, 1, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0 },
                    { 2, 0.0, 2, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 300.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cobros_DeudorId",
                table: "Cobros",
                column: "DeudorId");

            migrationBuilder.CreateIndex(
                name: "IX_CobrosDetalle_CobroId",
                table: "CobrosDetalle",
                column: "CobroId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_CuotasDetalleId",
                table: "Cuotas",
                column: "CuotasDetalleId");

            migrationBuilder.CreateIndex(
                name: "IX_CuotasDetalle_PrestamoId",
                table: "CuotasDetalle",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_DeudorId",
                table: "Prestamos",
                column: "DeudorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CobrosDetalle");

            migrationBuilder.DropTable(
                name: "Cuotas");

            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.DropTable(
                name: "CuotasDetalle");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Deudores");
        }
    }
}
