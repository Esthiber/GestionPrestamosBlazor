﻿// <auto-generated />
using System;
using GestionPrestamos.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionPrestamos.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionPrestamos.Models.Cobros", b =>
                {
                    b.Property<int>("CobroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CobroId"));

                    b.Property<int>("DeudorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.HasKey("CobroId");

                    b.HasIndex("DeudorId");

                    b.ToTable("Cobros");
                });

            modelBuilder.Entity("GestionPrestamos.Models.CobrosDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleId"));

                    b.Property<int>("CobroId")
                        .HasColumnType("int");

                    b.Property<int>("PrestamoId")
                        .HasColumnType("int");

                    b.Property<double>("ValorCobrado")
                        .HasColumnType("float");

                    b.HasKey("DetalleId");

                    b.HasIndex("CobroId");

                    b.HasIndex("PrestamoId");

                    b.ToTable("CobrosDetalle");
                });

            modelBuilder.Entity("GestionPrestamos.Models.Cuotas", b =>
                {
                    b.Property<int>("CuotaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CuotaId"));

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<int>("CuotaNo")
                        .HasColumnType("int");

                    b.Property<int>("CuotasDetalleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("CuotaId");

                    b.HasIndex("CuotasDetalleId");

                    b.ToTable("Cuotas");

                    b.HasData(
                        new
                        {
                            CuotaId = 1,
                            Balance = 0.0,
                            CuotaNo = 0,
                            CuotasDetalleId = 1,
                            Fecha = new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 500.0
                        },
                        new
                        {
                            CuotaId = 2,
                            Balance = 0.0,
                            CuotaNo = 0,
                            CuotasDetalleId = 2,
                            Fecha = new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 300.0
                        },
                        new
                        {
                            CuotaId = 3,
                            Balance = 800.0,
                            CuotaNo = 0,
                            CuotasDetalleId = 3,
                            Fecha = new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Valor = 800.0
                        });
                });

            modelBuilder.Entity("GestionPrestamos.Models.CuotasDetalle", b =>
                {
                    b.Property<int>("CuotasDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CuotasDetalleId"));

                    b.Property<int>("CuotasNo")
                        .HasColumnType("int");

                    b.Property<int>("PrestamoId")
                        .HasColumnType("int");

                    b.HasKey("CuotasDetalleId");

                    b.HasIndex("PrestamoId")
                        .IsUnique();

                    b.ToTable("CuotasDetalle");

                    b.HasData(
                        new
                        {
                            CuotasDetalleId = 1,
                            CuotasNo = 12,
                            PrestamoId = 1
                        },
                        new
                        {
                            CuotasDetalleId = 2,
                            CuotasNo = 6,
                            PrestamoId = 2
                        },
                        new
                        {
                            CuotasDetalleId = 3,
                            CuotasNo = 10,
                            PrestamoId = 3
                        });
                });

            modelBuilder.Entity("GestionPrestamos.Models.Deudores", b =>
                {
                    b.Property<int>("DeudorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeudorId"));

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DeudorId");

                    b.HasIndex("Nombres")
                        .IsUnique();

                    b.ToTable("Deudores");

                    b.HasData(
                        new
                        {
                            DeudorId = 1,
                            Nombres = "Jose Lopez"
                        },
                        new
                        {
                            DeudorId = 2,
                            Nombres = "Maria Perez"
                        },
                        new
                        {
                            DeudorId = 3,
                            Nombres = "Carlos Sanchez"
                        },
                        new
                        {
                            DeudorId = 4,
                            Nombres = "Ana Torres"
                        },
                        new
                        {
                            DeudorId = 5,
                            Nombres = "Luis Ramirez"
                        });
                });

            modelBuilder.Entity("GestionPrestamos.Models.Prestamos", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrestamoId"));

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeudorId")
                        .HasColumnType("int");

                    b.Property<double>("Monto")
                        .HasPrecision(18, 2)
                        .HasColumnType("float(18)");

                    b.HasKey("PrestamoId");

                    b.HasIndex("DeudorId");

                    b.ToTable("Prestamos");

                    b.HasData(
                        new
                        {
                            PrestamoId = 1,
                            Balance = 14500.0,
                            Concepto = "Compra de vehículo",
                            DeudorId = 1,
                            Monto = 15000.0
                        },
                        new
                        {
                            PrestamoId = 2,
                            Balance = 5000.0,
                            Concepto = "Estudio",
                            DeudorId = 2,
                            Monto = 5000.0
                        },
                        new
                        {
                            PrestamoId = 3,
                            Balance = 8000.0,
                            Concepto = "Mejoras en casa",
                            DeudorId = 3,
                            Monto = 8000.0
                        });
                });

            modelBuilder.Entity("GestionPrestamos.Models.Cobros", b =>
                {
                    b.HasOne("GestionPrestamos.Models.Deudores", "Deudor")
                        .WithMany("Cobros")
                        .HasForeignKey("DeudorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deudor");
                });

            modelBuilder.Entity("GestionPrestamos.Models.CobrosDetalle", b =>
                {
                    b.HasOne("GestionPrestamos.Models.Cobros", "Cobro")
                        .WithMany("CobrosDetalle")
                        .HasForeignKey("CobroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GestionPrestamos.Models.Prestamos", "Prestamo")
                        .WithMany()
                        .HasForeignKey("PrestamoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cobro");

                    b.Navigation("Prestamo");
                });

            modelBuilder.Entity("GestionPrestamos.Models.Cuotas", b =>
                {
                    b.HasOne("GestionPrestamos.Models.CuotasDetalle", "CuotasDetalle")
                        .WithMany("Cuotas")
                        .HasForeignKey("CuotasDetalleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CuotasDetalle");
                });

            modelBuilder.Entity("GestionPrestamos.Models.CuotasDetalle", b =>
                {
                    b.HasOne("GestionPrestamos.Models.Prestamos", "Prestamo")
                        .WithOne("CuotasDetalle")
                        .HasForeignKey("GestionPrestamos.Models.CuotasDetalle", "PrestamoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestamo");
                });

            modelBuilder.Entity("GestionPrestamos.Models.Prestamos", b =>
                {
                    b.HasOne("GestionPrestamos.Models.Deudores", "Deudor")
                        .WithMany("Prestamos")
                        .HasForeignKey("DeudorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deudor");
                });

            modelBuilder.Entity("GestionPrestamos.Models.Cobros", b =>
                {
                    b.Navigation("CobrosDetalle");
                });

            modelBuilder.Entity("GestionPrestamos.Models.CuotasDetalle", b =>
                {
                    b.Navigation("Cuotas");
                });

            modelBuilder.Entity("GestionPrestamos.Models.Deudores", b =>
                {
                    b.Navigation("Cobros");

                    b.Navigation("Prestamos");
                });

            modelBuilder.Entity("GestionPrestamos.Models.Prestamos", b =>
                {
                    b.Navigation("CuotasDetalle")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
