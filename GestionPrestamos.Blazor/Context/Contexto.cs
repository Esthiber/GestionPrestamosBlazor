using GestionPrestamos.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionPrestamos.Context;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public virtual DbSet<Deudores> Deudores { get; set; }
    public virtual DbSet<Prestamos> Prestamos { get; set; }
    public virtual DbSet<Cobros> Cobros { get; set; }
    public virtual DbSet<CobrosDetalle> CobrosDetalle { get; set; }

    public virtual DbSet<Cuotas> Cuotas { get; set; }
    public virtual DbSet<CuotasDetalle> CuotasDetalle { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de Deudores
        modelBuilder.Entity<Deudores>().HasData(
            new List<Deudores>()
            {
            new() { DeudorId = 1, Nombres = "Jose Lopez" },
            new() { DeudorId = 2, Nombres = "Maria Perez" },
            new() { DeudorId = 3, Nombres = "Carlos Sanchez" },
            new() { DeudorId = 4, Nombres = "Ana Torres" },
            new() { DeudorId = 5, Nombres = "Luis Ramirez" }
            }
        );

        // Configuración de relaciones
        modelBuilder.Entity<Deudores>()
            .HasMany(d => d.Cobros)
            .WithOne(c => c.Deudor)
            .HasForeignKey(c => c.DeudorId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Deudores>()
            .HasMany(d => d.Prestamos)
            .WithOne(p => p.Deudor)
            .HasForeignKey(p => p.DeudorId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Prestamos>()
            .HasMany(p => p.CuotasDetalle)
            .WithOne(cd => cd.Prestamo)
            .HasForeignKey(cd => cd.PrestamoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Cobros>()
            .HasMany(c => c.CobrosDetalle)
            .WithOne(cd => cd.Cobro)
            .HasForeignKey(cd => cd.CobroId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CuotasDetalle>()
            .HasMany(cd => cd.Cuotas)
            .WithOne(c => c.CuotasDetalle)
            .HasForeignKey(c => c.CuotasDetalleId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuración de Prestamos
        modelBuilder.Entity<Prestamos>().HasData(
            new List<Prestamos>()
            {
            new() { PrestamoId = 1, Concepto = "Compra de vehículo", Monto = 15000, Balance = 15000, DeudorId = 1 },
            new() { PrestamoId = 2, Concepto = "Estudio", Monto = 5000, Balance = 5000, DeudorId = 2 },
            new() { PrestamoId = 3, Concepto = "Mejoras en casa", Monto = 8000, Balance = 8000, DeudorId = 3 }
            }
        );

        // Configuración de Cobros
        modelBuilder.Entity<Cobros>().HasData(
            new List<Cobros>()
            {
            new() { CobroId = 1, Fecha = new DateTime(2025,3,2), DeudorId = 1, Monto = 500 },
            new() { CobroId = 2, Fecha = new DateTime(2025,3,2), DeudorId = 2, Monto = 300 }
            }
        );

        // Configuración de CobrosDetalle
        modelBuilder.Entity<CobrosDetalle>().HasData(
            new List<CobrosDetalle>()
            {
            new() { DetalleId = 1, CobroId = 1, PrestamoId = 1, ValorCobrado = 500 },
            new() { DetalleId = 2, CobroId = 2, PrestamoId = 2, ValorCobrado = 300 }
            }
        );

        // Configuración de Cuotas
        modelBuilder.Entity<Cuotas>().HasData(
            new List<Cuotas>()
            {
            new() { CuotaId = 1, CuotasDetalleId = 1, Fecha = new DateTime(2025, 3, 2), Valor = 500, Balance = 0 },
            new() { CuotaId = 2, CuotasDetalleId = 2, Fecha = new DateTime(2025, 3, 2), Valor = 300, Balance = 0 }
            }
        );

        // Configuración de CuotasDetalle
        modelBuilder.Entity<CuotasDetalle>().HasData(
            new List<CuotasDetalle>()
            {
            new() { CuotasDetalleId = 1, PrestamoId = 1, CuotasNo = 12 },
            new() { CuotasDetalleId = 2, PrestamoId = 2, CuotasNo = 6 }
            }
        );

        base.OnModelCreating(modelBuilder);
    }

}
