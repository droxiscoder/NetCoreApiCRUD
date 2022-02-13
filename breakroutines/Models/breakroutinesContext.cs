using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace breakroutines.Models
{
    public partial class breakroutinesContext : DbContext
    {
        public breakroutinesContext()
        {
        }

        public breakroutinesContext(DbContextOptions<breakroutinesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<TripPhoto> TripPhotos { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("reviews");

                entity.HasIndex(e => e.UserId, "reviews_fk_1_idx");

                entity.HasIndex(e => e.TripId, "reviews_fk_2_idx");

                entity.Property(e => e.ReviewId).HasColumnName("review_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(600)
                    .HasColumnName("description");

                entity.Property(e => e.Score)
                    .HasColumnType("tinyint")
                    .HasColumnName("score");

                entity.Property(e => e.TripId).HasColumnName("trip_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.TripId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reviews_fk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reviews_fk_1");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("trips");

                entity.HasIndex(e => e.UserId, "trips_fk_1_idx");

                entity.HasIndex(e => e.Name, "trips_idx_1")
                    .IsUnique();

                entity.Property(e => e.TripId).HasColumnName("trip_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(10000)")
                    .HasColumnName("description");

                entity.Property(e => e.Duration)
                    .HasColumnType("decimal(2,2)")
                    .HasColumnName("duration");

                entity.Property(e => e.Latitude)
                    .HasColumnType("decimal(9,6)")
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasColumnType("decimal(9,6)")
                    .HasColumnName("longitude");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(19,4)")
                    .HasColumnName("price");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trips_fk_1");
            });

            modelBuilder.Entity<TripPhoto>(entity =>
            {
                entity.ToTable("trip_photos");

                entity.HasIndex(e => e.TripId, "trip_photos_fk_1_idx");

                entity.HasIndex(e => e.UserId, "trip_photos_fk_2_idx");

                entity.Property(e => e.TripPhotoId).HasColumnName("trip_photo_id");

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("photo");

                entity.Property(e => e.TripId).HasColumnName("trip_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.TripPhotos)
                    .HasForeignKey(d => d.TripId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trip_photos_fk_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TripPhotos)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trip_photos_fk_2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "users_idx_1")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(150)
                    .HasColumnName("city");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("first_name");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnType("bit(1)")
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("last_name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .HasColumnName("phone_number");

                entity.Property(e => e.ProfilePic)
                    .HasMaxLength(250)
                    .HasColumnName("profile_pic");

                entity.Property(e => e.State)
                    .HasMaxLength(200)
                    .HasColumnName("state");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
