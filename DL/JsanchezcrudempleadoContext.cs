using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class JsanchezcrudempleadoContext : DbContext
{
    public JsanchezcrudempleadoContext()
    {
    }

    public JsanchezcrudempleadoContext(DbContextOptions<JsanchezcrudempleadoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database= JSANCHEZCRUDEMPLEADO; User ID=sa; TrustServerCertificate=True; Password=pass@word1; Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Idempleado).HasName("PK__EMPLEADO__E014C3167E4F251E");

            entity.ToTable("EMPLEADO");

            entity.Property(e => e.Idempleado).HasColumnName("IDEMPLEADO");
            entity.Property(e => e.Apellidomaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDOMATERNO");
            entity.Property(e => e.Apellidopaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDOPATERNO");
            entity.Property(e => e.Estatus).HasColumnName("ESTATUS");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
