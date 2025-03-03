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

                    b.HasData(
                        new
                        {
                            CobroId = 1,
                            DeudorId = 1,
                            Fecha = new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 500.0
                        },
                        new
                        {
                            CobroId = 2,
                            DeudorId = 2,
                            Fecha = new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 300.0
                        });
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

                    b.ToTable("CobrosDetalle");

                    b.HasData(
                        new
                        {
                            DetalleId = 1,
                            CobroId = 1,
                            PrestamoId = 1,
                            ValorCobrado = 500.0
                        },
                        new
                        {
                            DetalleId = 2,
                            CobroId = 2,
                            PrestamoId = 2,
                            ValorCobrado = 300.0
                        });
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

                    b.HasIndex("PrestamoId");

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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeudorId");

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
                        .HasColumnType("float");

                    b.HasKey("PrestamoId");

                    b.HasIndex("DeudorId");

                    b.ToTable("Prestamos");

                    b.HasData(
                        new
                        {
                            PrestamoId = 1,
                            Balance = 15000.0,
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

                    b.Navigation("Cobro");
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
                        .WithMany("CuotasDetalle")
                        .HasForeignKey("PrestamoId")
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
                    b.Navigation("CuotasDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
