using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TareaBackFront.Models
{
    public partial class dbempleadoContext : DbContext
    {
        public dbempleadoContext()
        {
        }

        public dbempleadoContext(DbContextOptions<dbempleadoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Puesto> Puestos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PRIMARY");

                entity.ToTable("empleados");

                entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

                entity.Property(e => e.Apellido).HasMaxLength(45);

                entity.Property(e => e.Direccion).HasMaxLength(45);

                entity.Property(e => e.Dpi)
                    .HasMaxLength(13)
                    .HasColumnName("DPI");

                entity.Property(e => e.FechaIngresoRegresitro).HasColumnType("datetime");

                entity.Property(e => e.IdPuesto).HasColumnName("idPuesto");

                entity.Property(e => e.Nombre).HasMaxLength(45);

                entity.Property(e => e.Telefono).HasMaxLength(8);
            });

            modelBuilder.Entity<Puesto>(entity =>
            {
                entity.HasKey(e => e.IdPuesto)
                    .HasName("PRIMARY");

                entity.ToTable("puestos");

                entity.HasIndex(e => e.IdPuesto, "idPuesto_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdPuesto).HasColumnName("idPuesto");

                entity.Property(e => e.Puesto1)
                    .HasMaxLength(60)
                    .HasColumnName("Puesto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
