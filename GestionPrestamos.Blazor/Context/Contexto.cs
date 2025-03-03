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
        modelBuilder.Entity<Deudores>()
            .HasIndex(d => d.Nombres)  // Nuevo índice para búsquedas
            .IsUnique();

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

        // Relaciones Deudores
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

        // Configuración de Prestamos
        modelBuilder.Entity<Prestamos>()
            .Property(p => p.Monto)
            .HasPrecision(18, 2);  // Precisión para montos

        modelBuilder.Entity<Prestamos>().HasData(
            new List<Prestamos>()
            {
                // Balance actualizado para PrestamoId=1
                new() { PrestamoId = 1, Concepto = "Compra de vehículo", Monto = 15000, Balance = 14500, DeudorId = 1 },
                new() { PrestamoId = 2, Concepto = "Estudio", Monto = 5000, Balance = 5000, DeudorId = 2 },
                new() { PrestamoId = 3, Concepto = "Mejoras en casa", Monto = 8000, Balance = 8000, DeudorId = 3 }
            }
        );

        // Relación CobrosDetalle -> Prestamos (NUEVO)
        modelBuilder.Entity<CobrosDetalle>()
            .HasOne(cd => cd.Cobro)
            .WithMany(c => c.CobrosDetalle)
            .HasForeignKey(cd => cd.CobroId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CobrosDetalle>()
            .HasOne(cd => cd.Prestamo)  // Navegación añadida
            .WithMany()
            .HasForeignKey(cd => cd.PrestamoId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuración CuotasDetalle
        modelBuilder.Entity<CuotasDetalle>()
            .HasMany(cd => cd.Cuotas)
            .WithOne(c => c.CuotasDetalle)
            .HasForeignKey(c => c.CuotasDetalleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CuotasDetalle>().HasData(
            new List<CuotasDetalle>()
            {
                new() { CuotasDetalleId = 1, PrestamoId = 1, CuotasNo = 12 },
                new() { CuotasDetalleId = 2, PrestamoId = 2, CuotasNo = 6 },
                new() { CuotasDetalleId = 3, PrestamoId = 3, CuotasNo = 10 }
            }
        );

        // Configuración Cuotas
        modelBuilder.Entity<Cuotas>().HasData(
            new List<Cuotas>()
            {
                new() { CuotaId = 1, CuotasDetalleId = 1, Fecha = new DateTime(2025, 3, 2), Valor = 500, Balance = 0 },
                new() { CuotaId = 2, CuotasDetalleId = 2, Fecha = new DateTime(2025, 3, 2), Valor = 300, Balance = 0 },
                new() { CuotaId = 3, CuotasDetalleId = 3, Fecha = new DateTime(2025, 4, 1), Valor = 800, Balance = 800 }
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}