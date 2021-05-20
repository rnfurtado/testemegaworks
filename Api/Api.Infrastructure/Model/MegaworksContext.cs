using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Api.Infrastructure.Model
{
    public partial class MegaworksContext : DbContext
    {
        public MegaworksContext()
        {
        }

        public MegaworksContext(DbContextOptions<MegaworksContext> options) : base(options)
        {
        }

        public virtual DbSet<ContaBancaria> ContaBancaria { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NOTEBOOK;Initial Catalog=Megaworks;Persist Security Info=False;User ID=megaworks;Password=123456;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<ContaBancaria>(entity =>
            {
                entity.HasKey(e => e.ContaId);

                entity.Property(e => e.CpfCnpj)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.DataAbertura).HasColumnType("datetime");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
