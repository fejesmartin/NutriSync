using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NutriSyncBackend.Models;
    public class NutriSyncDBContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Product> Products { get; set; }

        public NutriSyncDBContext(DbContextOptions<NutriSyncDBContext> options)
            : base(options)
        {
            if (Database.IsRelational()) Database.Migrate();
        }

        // Configure the database connection based on the environment
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Testing")
            {
                // Use an in-memory database for testing
                options.UseInMemoryDatabase("TestDatabase");
            }
            else
            {
                // Use SQL Server with the provided connection string
                options.UseSqlServer(
                    Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING"));
            }
        }

        // Configure the database model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Plan model
            modelBuilder.Entity<Plan>()
                .HasKey(p => p.PlanId);

            modelBuilder.Entity<Plan>()
                .Property(p => p.PlanName)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Plan>()
                .Property(p => p.Description)
                .HasMaxLength(1000);

            // Relationships
            modelBuilder.Entity<Plan>()
                .HasOne(p => p.User)
                .WithMany(u => u.Plans)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            
            // Configure the Product model
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(1000);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .IsRequired();

            // Relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.User)
                .WithMany(u => u.BoughtProducts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

