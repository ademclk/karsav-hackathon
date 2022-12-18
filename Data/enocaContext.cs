using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace enoca.Data
{
    public partial class enocaContext : DbContext
    {
        public enocaContext()
        {
        }

        public enocaContext(DbContextOptions<enocaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Firma> Firmalar { get; set; } = null!;
        public virtual DbSet<Siparis> Siparisler { get; set; } = null!;
        public virtual DbSet<Urun> Urunler { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=enoca;UID=sa;PWD=ademOnur213@adem");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Firma>(entity =>
            {
                entity.ToTable("Firma");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirmaAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SiparisIzinBaslangicTarihi).HasColumnType("datetime");

                entity.Property(e => e.SiparisIzinBitisTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<Siparis>(entity =>
            {
                entity.ToTable("Siparis");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirmaId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UrunId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SiparisVerenKisiAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SiparisTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<Urun>(entity =>
            {
                entity.ToTable("Urun");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.UrunAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fiyat).HasColumnType("float");

                entity.Property(e => e.Stok).HasColumnType("float");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
