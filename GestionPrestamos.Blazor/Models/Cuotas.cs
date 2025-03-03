using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPrestamos.Models
{
    public class Cuotas
    {
        [Key]
        public int CuotaId { get; set; }

        public int CuotaNo { get; set; }

        public int CuotasDetalleId { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El Valor es Requerido.")]
        public double Valor { get; set; }

        public double Balance { get; set; } = 0;

        [ForeignKey("CuotasDetalleId")]
        [InverseProperty("Cuotas")]
        public virtual CuotasDetalle CuotasDetalle { get; set; } = null!;
    }
}
