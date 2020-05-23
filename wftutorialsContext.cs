using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace AspnetMvcTutorial
{
    public partial class wftutorialsContext : DbContext
    {
        public wftutorialsContext()
        {
        }

        public wftutorialsContext(DbContextOptions<wftutorialsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FailedJobs> FailedJobs { get; set; }
        public virtual DbSet<MyMigrations> Migrations { get; set; }
        public virtual DbSet<Musers> Musers { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        // Unable to generate entity type for table 'password_resets'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;uid=root;pwd=;database=wftutorials");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FailedJobs>(entity =>
            {
                entity.ToTable("failed_jobs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Connection)
                    .IsRequired()
                    .HasColumnName("connection")
                    .HasColumnType("text");

                entity.Property(e => e.Exception)
                    .IsRequired()
                    .HasColumnName("exception")
                    .HasColumnType("longtext");

                entity.Property(e => e.FailedAt)
                    .HasColumnName("failed_at")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Payload)
                    .IsRequired()
                    .HasColumnName("payload")
                    .HasColumnType("longtext");

                entity.Property(e => e.Queue)
                    .IsRequired()
                    .HasColumnName("queue")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<MyMigrations>(entity =>
            {
                entity.ToTable("migrations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Migration)
                    .IsRequired()
                    .HasColumnName("migration")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Musers>(entity =>
            {
                entity.ToTable("musers");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(65)");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasColumnType("varchar(65)");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.Ipaddress)
                    .HasColumnName("ipaddress")
                    .HasColumnType("varchar(65)");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasColumnType("varchar(65)");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("users_email_unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EmailVerifiedAt)
                    .HasColumnName("email_verified_at")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RememberToken)
                    .HasColumnName("remember_token")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp");
            });
        }
    }
}
