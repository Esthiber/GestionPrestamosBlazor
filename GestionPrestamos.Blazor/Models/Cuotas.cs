using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPrestamos.Models
{
    public class Cuotas
    {
        [Key]
        public int CuotaId { get; set; }

        public int PrestamoId { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El Valor es Requerido.")]
        public double Valor { get; set; }

        [ForeignKey("PrestamoId")]
        [InverseProperty("Cuota")]
        public virtual Prestamos Prestamo { get; set; } = null!;
    }
}
