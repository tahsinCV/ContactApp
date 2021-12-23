using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RT.Contact.DataLayer
{
    public partial class RTDataContext : DbContext
    {
        public RTDataContext()
        {
        }

        public RTDataContext(DbContextOptions<RTDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInformation> UserInformations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("User ID=postgres;Password=1234;Server=localhost;Port=5435;Database=RiseTechnology;Integrated Security=true;Pooling=true;");
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

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreateTime).HasColumnType("date");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SurName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateTime).HasColumnType("date");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.Property(e => e.Uuid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("UUID");
            });

            modelBuilder.Entity<UserInformation>(entity =>
            {
                entity.ToTable("UserInformation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CreateTime).HasColumnType("date");

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Information)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("true");

                entity.Property(e => e.PhoneNumber).HasMaxLength(11);

                entity.Property(e => e.UpdateTime).HasColumnType("date");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.Property(e => e.UserId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("UserID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.UserInformations)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_City");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInformations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Info");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
