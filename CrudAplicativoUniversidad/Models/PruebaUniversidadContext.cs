using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudAplicativoUniversidad.Models;

public partial class PruebaUniversidadContext : DbContext
{
    public PruebaUniversidadContext()
    {
    }

    public PruebaUniversidadContext(DbContextOptions<PruebaUniversidadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mdalumno01> Mdalumno01s { get; set; }

    public virtual DbSet<Mdcarreras05> Mdcarreras05s { get; set; }

    public virtual DbSet<Mdcursos02> Mdcursos02s { get; set; }

    public virtual DbSet<Mdtipocolaborador03> Mdtipocolaborador03s { get; set; }

    public virtual DbSet<Mdtrabajador04> Mdtrabajador04s { get; set; }

    public virtual DbSet<Mqsolicitudcab06> Mqsolicitudcab06s { get; set; }

    public virtual DbSet<Mqsolicituddet07> Mqsolicituddet07s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = localhost; database=PruebaUniversidad; integrated security = true; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mdalumno01>(entity =>
        {
            entity.HasKey(e => e.Id01).HasName("PK__MDALUMNO__B0B03EF85148106E");

            entity.ToTable("MDALUMNO01");

            entity.Property(e => e.Apellidos01)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombres01)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mdcarreras05>(entity =>
        {
            entity.HasKey(e => e.Id05).HasName("PK__MDCARRER__B0B03EE4B14BE393");

            entity.ToTable("MDCARRERAS05");

            entity.Property(e => e.Descripcion05)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mdcursos02>(entity =>
        {
            entity.HasKey(e => e.Id02).HasName("PK__MDCURSOS__B0B03EF9EF5B433A");

            entity.ToTable("MDCURSOS02");

            entity.Property(e => e.Descripcion02)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre02)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mdtipocolaborador03>(entity =>
        {
            entity.HasKey(e => e.Id03).HasName("PK__MDTIPOCO__B0B03EE69041E656");

            entity.ToTable("MDTIPOCOLABORADOR03");

            entity.Property(e => e.Tipo03)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mdtrabajador04>(entity =>
        {
            entity.HasKey(e => e.Id04).HasName("PK__MDTRABAJ__B0B03EE71EE7BFB3");

            entity.ToTable("MDTRABAJADOR04");

            entity.Property(e => e.Apellidos04)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombres04)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipo03Navigation).WithMany(p => p.Mdtrabajador04s)
                .HasForeignKey(d => d.IdTipo03)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MDTRABAJA__IdTip__2A4B4B5E");
        });

        modelBuilder.Entity<Mqsolicitudcab06>(entity =>
        {
            entity.HasKey(e => e.Id06).HasName("PK__MQSOLICI__B0B03EE5C446E12C");

            entity.ToTable("MQSOLICITUDCAB06");

            entity.Property(e => e.FechaSolicitud06).HasColumnType("datetime");
            entity.Property(e => e.Periodo06)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Carrera05Navigation).WithMany(p => p.Mqsolicitudcab06s)
                .HasForeignKey(d => d.Carrera05)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MQSOLICIT__Carre__30F848ED");

            entity.HasOne(d => d.IdAlumno01Navigation).WithMany(p => p.Mqsolicitudcab06s)
                .HasForeignKey(d => d.IdAlumno01)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MQSOLICIT__Perio__2F10007B");

            entity.HasOne(d => d.IdRegistrante04Navigation).WithMany(p => p.Mqsolicitudcab06s)
                .HasForeignKey(d => d.IdRegistrante04)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MQSOLICIT__IdReg__300424B4");
        });

        modelBuilder.Entity<Mqsolicituddet07>(entity =>
        {
            entity.HasKey(e => e.Id07).HasName("PK__MQSOLICI__B0B03EE293C8BEEC");

            entity.ToTable("MQSOLICITUDDET07");

            entity.Property(e => e.Aula07)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IdProfesor04).HasColumnName("idProfesor04");
            entity.Property(e => e.Observacion07)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Sede07)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCurso02Navigation).WithMany(p => p.Mqsolicituddet07s)
                .HasForeignKey(d => d.IdCurso02)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MQSOLICIT__IdCur__34C8D9D1");

            entity.HasOne(d => d.IdProfesor04Navigation).WithMany(p => p.Mqsolicituddet07s)
                .HasForeignKey(d => d.IdProfesor04)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MQSOLICIT__idPro__35BCFE0A");

            entity.HasOne(d => d.IdSolicitud06Navigation).WithMany(p => p.Mqsolicituddet07s)
                .HasForeignKey(d => d.IdSolicitud06)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MQSOLICIT__Obser__33D4B598");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
