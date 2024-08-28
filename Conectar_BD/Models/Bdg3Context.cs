using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Conectar_BD.Models;

public partial class Bdg3Context : DbContext
{
    public Bdg3Context()
    {
    }

    public Bdg3Context(DbContextOptions<Bdg3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Cerveza> Cervezas { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Detalle> Detalles { get; set; }

    public virtual DbSet<Publicacion> Publicacions { get; set; }

    public virtual DbSet<Recibo> Recibos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SQLSERVER\\SQLSERVER;Initial Catalog=bdg3;User ID=bdg3;Password=bdg3;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("db_owner");

        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Idalumno).HasName("PK__alumnos__608A9B4883EC5D59");

            entity.ToTable("alumnos");

            entity.Property(e => e.Idalumno).HasColumnName("idalumno");
            entity.Property(e => e.Apyn)
                .HasMaxLength(100)
                .HasColumnName("apyn");
            entity.Property(e => e.Fecnac).HasColumnName("fecnac");
            entity.Property(e => e.Idcurso).HasColumnName("idcurso");

            entity.HasOne(d => d.IdcursoNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.Idcurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__alumnos__idcurso__10966653");
        });

        modelBuilder.Entity<Cerveza>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cerveza__3213E83FDF574D7C");

            entity.ToTable("cerveza");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Alcohol).HasColumnName("alcohol");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Marca)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idclientes).HasName("PK__Clientes__59AEEEEEE030E8C9");

            entity.Property(e => e.Idclientes).HasColumnName("IDClientes");
            entity.Property(e => e.Cliente1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Cliente");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Localidad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("ituzaingo")
                .HasColumnName("localidad");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Idcurso).HasName("PK__cursos__39994732C8742F19");

            entity.ToTable("cursos");

            entity.Property(e => e.Idcurso).HasColumnName("idcurso");
            entity.Property(e => e.Curso1)
                .HasMaxLength(100)
                .HasColumnName("curso");
        });

        modelBuilder.Entity<Detalle>(entity =>
        {
            entity.HasKey(e => e.Iddetalle).HasName("PK__detalles__32EB9E47330C926B");

            entity.ToTable("detalles");

            entity.Property(e => e.Iddetalle).HasColumnName("IDDetalle");
            entity.Property(e => e.Detalle1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Detalle");
            entity.Property(e => e.Idrecibo).HasColumnName("IDRecibo");
            entity.Property(e => e.Monto).HasColumnType("money");

            entity.HasOne(d => d.IdreciboNavigation).WithMany(p => p.Detalles)
                .HasForeignKey(d => d.Idrecibo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_det_rec");
        });

        modelBuilder.Entity<Publicacion>(entity =>
        {
            entity.HasKey(e => e.IdPublicacion).HasName("PK__publicac__1EF15D3A7F22639B");

            entity.ToTable("publicacion");

            entity.Property(e => e.IdPublicacion).HasColumnName("ID_Publicacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Especie)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Recibo>(entity =>
        {
            entity.HasKey(e => e.Idrecibos).HasName("PK__recibos__7C50097230E1E930");

            entity.ToTable("recibos");

            entity.HasIndex(e => e.Nro, "unq_Nro").IsUnique();

            entity.Property(e => e.Idrecibos).HasColumnName("IDRecibos");
            entity.Property(e => e.Idcliente).HasColumnName("IDCliente");
            entity.Property(e => e.Nro)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Total).HasColumnType("money");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Recibos)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cli_rec");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuario__645723A68A38C4FD");

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
