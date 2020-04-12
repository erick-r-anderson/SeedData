using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SeedData.Data
{
    public partial class seedsContext : DbContext
    {
        public seedsContext()
        {
        }

        public seedsContext(DbContextOptions<seedsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Month> Month { get; set; }
        public virtual DbSet<Seed> Seed { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=9545;database=seeds");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.Idcolor);

                entity.ToTable("color", "seeds");

                entity.Property(e => e.Idcolor)
                    .HasColumnName("idcolor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Color1)
                    .HasColumnName("color")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Month>(entity =>
            {
                entity.HasKey(e => e.Idmonth);

                entity.ToTable("month", "seeds");

                entity.Property(e => e.Idmonth)
                    .HasColumnName("idmonth")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Month1)
                    .HasColumnName("month")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Seed>(entity =>
            {
                entity.ToTable("seed", "seeds");

                entity.HasIndex(e => e.BloomMonthId)
                    .HasName("fk_monthbloom_idx");

                entity.HasIndex(e => e.Color1Id)
                    .HasName("fk_color_idx");

                entity.HasIndex(e => e.Color2Id)
                    .HasName("fk_color2_idx");

                entity.HasIndex(e => e.Color3Id)
                    .HasName("fk_color3_idx");

                entity.HasIndex(e => e.EndMonthId)
                    .HasName("fk_monthend_idx");

                entity.HasIndex(e => e.StartMonthId)
                    .HasName("fk_monthstart_idx");

                entity.Property(e => e.SeedId)
                    .HasColumnName("seedId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BloomMonthId)
                    .HasColumnName("bloomMonthId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Color1Id)
                    .HasColumnName("color1Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Color2Id)
                    .HasColumnName("color2Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Color3Id)
                    .HasColumnName("color3Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CommonName)
                    .HasColumnName("commonName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dry)
                    .HasColumnName("dry")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Drymesic)
                    .HasColumnName("drymesic")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.EndMonthId)
                    .HasColumnName("endMonthId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Mesic)
                    .HasColumnName("mesic")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Prairie)
                    .HasColumnName("prairie")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Savanna)
                    .HasColumnName("savanna")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.ScientificName)
                    .HasColumnName("scientificName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartMonthId)
                    .HasColumnName("startMonthId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wet)
                    .HasColumnName("wet")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Wetmesic)
                    .HasColumnName("wetmesic")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Woodland)
                    .HasColumnName("woodland")
                    .HasColumnType("tinyint(4)");

                entity.HasOne(d => d.BloomMonth)
                    .WithMany(p => p.SeedBloomMonth)
                    .HasForeignKey(d => d.BloomMonthId)
                    .HasConstraintName("fk_monthbloom");

                entity.HasOne(d => d.Color1)
                    .WithMany(p => p.SeedColor1)
                    .HasForeignKey(d => d.Color1Id)
                    .HasConstraintName("fk_color");

                entity.HasOne(d => d.Color2)
                    .WithMany(p => p.SeedColor2)
                    .HasForeignKey(d => d.Color2Id)
                    .HasConstraintName("fk_color2");

                entity.HasOne(d => d.Color3)
                    .WithMany(p => p.SeedColor3)
                    .HasForeignKey(d => d.Color3Id)
                    .HasConstraintName("fk_color3");

                entity.HasOne(d => d.EndMonth)
                    .WithMany(p => p.SeedEndMonth)
                    .HasForeignKey(d => d.EndMonthId)
                    .HasConstraintName("fk_monthend");

                entity.HasOne(d => d.StartMonth)
                    .WithMany(p => p.SeedStartMonth)
                    .HasForeignKey(d => d.StartMonthId)
                    .HasConstraintName("fk_monthstart");
            });
        }
    }
}
