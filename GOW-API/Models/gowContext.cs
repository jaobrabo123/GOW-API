using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GOW_API.Models
{
    public partial class gowContext : DbContext
    {
        public gowContext()
        {
        }

        public gowContext(DbContextOptions<gowContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arma> Armas { get; set; } = null!;
        public virtual DbSet<Jogo> Jogos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arma>(entity =>
            {
                entity.ToTable("armas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .HasColumnType("text")
                    .HasColumnName("descricao");

                entity.Property(e => e.Jogoid).HasColumnName("jogoid");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasOne(d => d.Jogo)
                    .WithMany(p => p.Armas)
                    .HasForeignKey(d => d.Jogoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__armas__jogoid__398D8EEE");
            });

            modelBuilder.Entity<Jogo>(entity =>
            {
                entity.ToTable("jogos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Lancamento)
                    .HasColumnType("date")
                    .HasColumnName("lancamento");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
