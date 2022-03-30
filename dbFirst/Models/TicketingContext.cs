using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dbFirst.Models
{
    public partial class TicketingContext : DbContext
    {
        public TicketingContext()
        {
        }

        public TicketingContext(DbContextOptions<TicketingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sadrzaj> Sadrzajs { get; set; } = null!;
        public virtual DbSet<Ticketing> Ticketings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress; Database = Ticketing; Trusted_connection = true; TrustServerCertificate = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sadrzaj>(entity =>
            {
                entity.ToTable("Sadrzaj");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdTicketing).HasColumnName("id_ticketing");

                entity.Property(e => e.Sadrzaj1).HasColumnName("Sadrzaj");

                entity.HasOne(d => d.IdTicketingNavigation)
                    .WithMany(p => p.Sadrzajs)
                    .HasForeignKey(d => d.IdTicketing)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sadrzaj_Ticketing");
            });

            modelBuilder.Entity<Ticketing>(entity =>
            {
                entity.ToTable("Ticketing");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Naziv).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
