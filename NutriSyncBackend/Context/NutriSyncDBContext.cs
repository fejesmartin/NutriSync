using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


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
            DotNetEnv.Env.Load();
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Testing")
            {
                // Use an in-memory database for testing
                options.UseInMemoryDatabase("TestDatabase");
            }
            else
            {
                // Use SQL Server with the provided connection string
                options.UseSqlServer("Server=nutrisync-db,1433;Database=NutriSyncDB;User Id=sa;Password=HerkuleS1998;TrustServerCertificate=true;"
                    );
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
                .HasOne<User>(u => u.User)
                .WithMany(p => p.Plans)
                .IsRequired();

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

            #region SeedInitialUser

            
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser { Id = "1", UserName = "example@example.com", Email = "example@example.com" }
            );

            #endregion
            
            #region SeedProducts

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1, ProductName = "Dumbbells", Description = "Set of adjustable dumbbells for strength training",
                    Price = 49.99m, UserId = "1"
                },
                new Product
                {
                    ProductId = 2, ProductName = "Exercise Mat", Description = "High-density foam mat for yoga and floor exercises",
                    Price = 19.99m, UserId = "1"
                },
                new Product
                {
                    ProductId = 3, ProductName = "Blender", Description = "High-speed blender for making smoothies and shakes",
                    Price = 69.99m, UserId = "1"
                },
                new Product
                {
                    ProductId = 4, ProductName = "Meal Prep Containers", Description = "Set of reusable containers for meal prepping",
                    Price = 14.99m, UserId = "1"
                }
            );

            #endregion
            
        }

    }

