using System;
using back.Models.Entities;
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
        public virtual DbSet<Etapa> Etapas { get; set; }
        public virtual DbSet<Lidere> Lideres { get; set; }
        public virtual DbSet<Liga> Ligas { get; set; }
        public virtual DbSet<Movimiento> Movimientos { get; set; }
        public virtual DbSet<Standing> Standings { get; set; }
        public virtual DbSet<Temporadum> Temporada { get; set; }
        public virtual DbSet<TipoEscenario> TipoEscenarios { get; set; }
        public virtual DbSet<TipoMovimiento> TipoMovimientos { get; set; }


        // Entity Keyless
        public virtual DbSet<StandingVista> StandingVistas  { get; set;}

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

            modelBuilder.Entity<Etapa>(entity =>
            {
                entity.ToTable("Etapa");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EscenarioId).HasColumnName("escenario_id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");

                entity.HasOne(d => d.Escenario)
                    .WithMany(p => p.Etapas)
                    .HasForeignKey(d => d.EscenarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Lidere>(entity =>
            {
                entity.Property(e => e.Categoria).IsRequired();

                entity.Property(e => e.Equipo).IsRequired();

                entity.Property(e => e.Jugador).IsRequired();

                entity.Property(e => e.Rubro).IsRequired();

                entity.Property(e => e.TemporadaId).HasColumnName("Temporada_Id");

                entity.Property(e => e.Valor).IsRequired();

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.Lideres)
                    .HasForeignKey(d => d.TemporadaId)
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

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.ToTable("Movimiento");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TemporadaId).HasColumnName("TemporadaID");

                entity.Property(e => e.TipoMovimientoId).HasColumnName("TipoMovimientoID");

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.TemporadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TipoMovimiento)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.TipoMovimientoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Standing>(entity =>
            {
                entity.ToTable("Standing");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Abrev)
                    .IsRequired()
                    .HasColumnName("abrev");

                entity.Property(e => e.Empates)
                    .HasColumnName("empates")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Equipo)
                    .IsRequired()
                    .HasColumnName("equipo");

                entity.Property(e => e.EtapaId).HasColumnName("etapa_id");

                entity.Property(e => e.Ganados).HasColumnName("ganados");

                entity.Property(e => e.Grupo)
                    .IsRequired()
                    .HasColumnName("grupo");

                entity.Property(e => e.Perdidos).HasColumnName("perdidos");

                entity.Property(e => e.SubGrupo).HasColumnName("subGrupo");

                entity.HasOne(d => d.Etapa)
                    .WithMany(p => p.Standings)
                    .HasForeignKey(d => d.EtapaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
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

            modelBuilder.Entity<TipoMovimiento>(entity =>
            {
                entity.ToTable("TipoMovimiento");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Clave).IsRequired();

                entity.Property(e => e.Nombre).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
