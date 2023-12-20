using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_Libros.Models;

public partial class DblibroContext : DbContext
{
    public DblibroContext()
    {
    }

    public DblibroContext(DbContextOptions<DblibroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Libro> Libros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__libros__3213E83F10D2867F");

            entity.ToTable("libros");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Autor)
                .HasMaxLength(255)
                .HasColumnName("autor");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Estrellas).HasColumnName("estrellas");
            entity.Property(e => e.FechaPublicacion).HasColumnName("fecha_publicacion");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .HasColumnName("titulo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
