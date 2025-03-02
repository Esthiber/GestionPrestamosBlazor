using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPrestamos.Migrations
{
    /// <inheritdoc />
    public partial class Cuotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    PrestamoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuotas", x => x.CuotaId);
                    table.ForeignKey(
                        name: "FK_Cuotas_CuotasDetalle_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "CuotasDetalle",
                        principalColumn: "CuotasDetalleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_PrestamoId",
                table: "Cuotas",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_CuotasDetalle_PrestamoId",
                table: "CuotasDetalle",
                column: "PrestamoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuotas");

            migrationBuilder.DropTable(
                name: "CuotasDetalle");
        }
    }
}
