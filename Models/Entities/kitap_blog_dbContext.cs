using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace projeDotnet.Models.Entities
{
    public partial class kitap_blog_dbContext : DbContext
    {
        public kitap_blog_dbContext()
        {
        }

        public kitap_blog_dbContext(DbContextOptions<kitap_blog_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kitaplar> Kitaplars { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;database=kitap_blog_db;default command timeout=120;sslmode=none", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.1.0-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Kitaplar>(entity =>
            {
                entity.ToTable("kitaplar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ad)
                    .HasMaxLength(50)
                    .HasColumnName("ad")
                    .IsFixedLength();

                entity.Property(e => e.Ozet)
                    .HasColumnType("mediumtext")
                    .HasColumnName("ozet");

                entity.Property(e => e.Resim)
                    .HasMaxLength(50)
                    .HasColumnName("resim")
                    .IsFixedLength();

                entity.Property(e => e.SayfaSayisi).HasColumnName("sayfaSayisi");

                entity.Property(e => e.YayinTarihi).HasColumnName("yayinTarihi");

                entity.Property(e => e.Yazar)
                    .HasMaxLength(50)
                    .HasColumnName("yazar")
                    .IsFixedLength();

                entity.Property(e => e.Yorum)
                    .HasColumnType("mediumtext")
                    .HasColumnName("yorum");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
