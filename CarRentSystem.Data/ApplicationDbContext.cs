namespace CarRentSystem.Data
{
    using CarRentSystem.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static Constants;
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DefaultConnection);
            }

            base.OnConfiguring(optionsBuilder);
        }

        public required DbSet<User> Users { get; set; } = default!;
        public required DbSet<Car> Cars { get; set; } = default!;
        public required DbSet<Rent> Rents { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rent>(entity =>
            {
                entity
                    .HasKey(r => new { r.CarId, r.UserId });

                entity
                    .HasOne(r => r.User)
                    .WithMany(u => u.Rents)
                    .HasForeignKey(r => r.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(r => r.Car)
                    .WithMany(c => c.Rents)
                    .HasForeignKey(r => r.CarId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Unique index for cars whose return date is null
                entity
                    .HasIndex(r => new { r.CarId })
                    .HasFilter("ReturnDate IS NULL")
                    .IsUnique();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity
                    .Property(u => u.EGN)
                    .HasColumnType("char")
                    .HasMaxLength(10);

                MakePropertiesUnique(entity, "EGN", "Username", "Email");
            });

            modelBuilder.Entity<Car>()
                .Property(c => c.Price)
                .HasColumnType("decimal")
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }

        private static void MakePropertiesUnique<T>(EntityTypeBuilder<T> entity, params string[] properties)
            where T : BaseEntity
        {
            foreach (var property in properties)
            {
                entity
                    .HasIndex(property)
                    .IsUnique(true);
            }
        }
    }
}
