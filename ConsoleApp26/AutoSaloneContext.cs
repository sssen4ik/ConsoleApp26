using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ConsoleApp26
{
    public partial class AutoSaloneContext : DbContext
    {
        public AutoSaloneContext()
        {
        }

        public AutoSaloneContext(DbContextOptions<AutoSaloneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CountryMark> CountryMarks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AutoSalone;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasIndex(e => e.CarId, "IX_Car_Id");

                entity.HasIndex(e => e.MarkId, "IX_MarkId");

                entity.Property(e => e.CarId).HasColumnName("Car_Id");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CarNavigation)
                    .WithMany(p => p.InverseCarNavigation)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK_dbo.Cars_dbo.Cars_Car_Id");

                entity.HasOne(d => d.Mark)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.MarkId)
                    .HasConstraintName("FK_dbo.Cars_dbo.Marks_MarkId");
            });

            modelBuilder.Entity<CountryMark>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.MarkId })
                    .HasName("PK_dbo.CountryMarks");

                entity.HasIndex(e => e.CountryId, "IX_Country_Id");

                entity.HasIndex(e => e.MarkId, "IX_Mark_Id");

                entity.Property(e => e.CountryId).HasColumnName("Country_Id");

                entity.Property(e => e.MarkId).HasColumnName("Mark_Id");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CountryMarks)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_dbo.CountryMarks_dbo.Countries_Country_Id");

                entity.HasOne(d => d.Mark)
                    .WithMany(p => p.CountryMarks)
                    .HasForeignKey(d => d.MarkId)
                    .HasConstraintName("FK_dbo.CountryMarks_dbo.Marks_Mark_Id");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.CustomerId, "IX_Customer_Id");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.InverseCustomerNavigation)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_dbo.Customers_dbo.Customers_Customer_Id");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasIndex(e => e.CarId, "IX_CarId");

                entity.HasIndex(e => e.CustomerId, "IX_Customer_Id");

                entity.HasIndex(e => e.WorkerId, "IX_WorkerId");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.DateOfSale).HasColumnType("datetime");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK_dbo.Sales_dbo.Cars_CarId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_dbo.Sales_dbo.Customers_Customer_Id");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.WorkerId)
                    .HasConstraintName("FK_dbo.Sales_dbo.Workers_WorkerId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
