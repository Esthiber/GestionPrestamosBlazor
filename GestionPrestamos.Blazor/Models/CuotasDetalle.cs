using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPrestamos.Models
{
    public class CuotasDetalle
    {
        [Key]
        public int CuotasDetalleId { get; set; }

        public int PrestamoId { get; set; }

        public int DeudorId { get; set; }

        public int CuotasNo { get; set; }

        [InverseProperty("CuotasDetalle")]
        public virtual ICollection<Cuotas> Cuotas { get; set; } = null!;

        [ForeignKey("PrestamoId")]
        public Prestamos Prestamo { get; set; } = null!;

        [ForeignKey("DeudorId")]
        public Deudores Deudor { get; set; } = null!;

    }
}
