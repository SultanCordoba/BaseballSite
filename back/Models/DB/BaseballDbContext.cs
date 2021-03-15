﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace back.Models.DB
{
    public partial class BaseballDbContext : DbContext
    {
        public BaseballDbContext()
        {
        }

        public BaseballDbContext(DbContextOptions<BaseballDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Escenario> Escenarios { get; set; }
        public virtual DbSet<Liga> Ligas { get; set; }
        public virtual DbSet<Temporadum> Temporada { get; set; }
        public virtual DbSet<TipoEscenario> TipoEscenarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("name=BeisbolBase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Escenario>(entity =>
            {
                entity.ToTable("Escenario");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TemporadaId).HasColumnName("TemporadaID");

                entity.Property(e => e.TipoEscenarioId).HasColumnName("TipoEscenarioID");

                entity.Property(e => e.Titulo).IsRequired();

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.Escenarios)
                    .HasForeignKey(d => d.TemporadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TipoEscenario)
                    .WithMany(p => p.Escenarios)
                    .HasForeignKey(d => d.TipoEscenarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Liga>(entity =>
            {
                entity.ToTable("Liga");

                entity.HasIndex(e => e.Id, "Liga_Id_IDX")
                    .IsUnique();

                entity.Property(e => e.Activa).HasDefaultValueSql("0");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("TEXT(50)");

                entity.Property(e => e.Siglas)
                    .IsRequired()
                    .HasColumnType("TEXT(10)");
            });

            modelBuilder.Entity<Temporadum>(entity =>
            {
                entity.HasIndex(e => e.Id, "Temporada_ID_IDX")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FechaInicio).HasColumnType("TEXT(20)");

                entity.Property(e => e.LigaId).HasColumnName("Liga_ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("TEXT(20)");

                entity.HasOne(d => d.Liga)
                    .WithMany(p => p.Temporada)
                    .HasForeignKey(d => d.LigaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TipoEscenario>(entity =>
            {
                entity.ToTable("TipoEscenario");

                entity.Property(e => e.Clave).IsRequired();

                entity.Property(e => e.Descripcion).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
