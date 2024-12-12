using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PruebaTecnicaConfig.Models
{
    public partial class PruebaTecnicaSurisContext : DbContext
    {
        public PruebaTecnicaSurisContext()
        {
        }

        public PruebaTecnicaSurisContext(DbContextOptions<PruebaTecnicaSurisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-TVR85M13;Database=PruebaTecnicaSuris;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.Property(e => e.Codigo).HasMaxLength(50);

                entity.Property(e => e.Descripcion).HasMaxLength(255);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.ArticuloId).HasColumnName("articulo_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Articulo)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.ArticuloId)
                    .HasConstraintName("FK__Pedidos__articul__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
