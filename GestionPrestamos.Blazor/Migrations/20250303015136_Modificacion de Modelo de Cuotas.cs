using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPrestamos.Migrations
{
    /// <inheritdoc />
    public partial class ModificaciondeModelodeCuotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CuotaNo",
                table: "Cuotas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cuotas",
                keyColumn: "CuotaId",
                keyValue: 1,
                column: "CuotaNo",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cuotas",
                keyColumn: "CuotaId",
                keyValue: 2,
                column: "CuotaNo",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CuotaNo",
                table: "Cuotas");
        }
    }
}
