using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RT.Report.DataLayer
{
    public partial class RTReportsDataContext : DbContext
    {
        public RTReportsDataContext()
        {
        }

        public RTReportsDataContext(DbContextOptions<RTReportsDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportStatus> ReportStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("User ID=postgres;Password=1234;Server=localhost;Port=5435;Database=RiseTechnologyReports;Integrated Security=true;Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_Turkey.1252");

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateTime).HasColumnType("date");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.ExternalSystemCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateTime).HasColumnType("date");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CityID");

                entity.Property(e => e.CreateTime).HasColumnType("date");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("true");

                entity.Property(e => e.RequestStatusId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("RequestStatusID");

                entity.Property(e => e.RequestTime).HasColumnType("date");

                entity.Property(e => e.UpdateTime).HasColumnType("date");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.Property(e => e.Uuid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("UUID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City");

                entity.HasOne(d => d.RequestStatus)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.RequestStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Report_Status");
            });

            modelBuilder.Entity<ReportStatus>(entity =>
            {
                entity.ToTable("ReportStatus");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateTime).HasColumnType("date");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("true");

                entity.Property(e => e.UpdateTime).HasColumnType("date");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
