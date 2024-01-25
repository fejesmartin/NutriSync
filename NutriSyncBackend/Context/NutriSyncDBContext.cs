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
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Testing")
            {
                // Use an in-memory database for testing
                options.UseInMemoryDatabase("TestDatabase");
            }
            else
            {
                // Use SQL Server with the provided connection string
                options.UseSqlServer(
                    "Server=localhost,1433;Database=NutriSyncDB;User Id=sa;Password=HerkuleS1998;TrustServerCertificate=true;");
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

            modelBuilder.Entity<Product>()
                .Property(p => p.ImageData)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.ImageMimeType)
                .IsRequired();

            // Relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.User)
                .WithMany(u => u.BoughtProducts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            #region SeedPlans

            modelBuilder.Entity<Plan>().HasData(
                new Plan { PlanId = 1, PlanName = "Standard Plan", Description = "Basic weight loss plan", UserId = "1"}
            );

            #endregion
            
            
            #region SeedProducts

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1, ProductName = "Dumbbells", Description = "Set of adjustable dumbbells for strength training",
                    Price = 49.99m, ImageData = GetImageBytes("dumbbell.png"), ImageMimeType = "image/png", UserId = "1"
                },
                new Product
                {
                    ProductId = 2, ProductName = "Exercise Mat", Description = "High-density foam mat for yoga and floor exercises",
                    Price = 19.99m, ImageData = GetImageBytes("mat.png"), ImageMimeType = "image/png", UserId = "1"
                },
                new Product
                {
                    ProductId = 3, ProductName = "Blender", Description = "High-speed blender for making smoothies and shakes",
                    Price = 69.99m, ImageData = GetImageBytes("blender.png"), ImageMimeType = "image/png", UserId = "1"
                },
                new Product
                {
                    ProductId = 4, ProductName = "Meal Prep Containers", Description = "Set of reusable containers for meal prepping",
                    Price = 14.99m, ImageData = GetImageBytes("containers.png"), ImageMimeType = "image/png", UserId = "1"
                }
            );

            #endregion

           
        }
        
        private static byte[] GetImageBytes(string imageName)
        {
            DotNetEnv.Env.Load();
            var pathToImage = Environment.GetEnvironmentVariable("PATH_TO_IMAGE");
    
            if (string.IsNullOrEmpty(pathToImage))
            {
                // Handle the case where PATH_TO_IMAGE is not set
                throw new InvalidOperationException("PATH_TO_IMAGE environment variable is not set.");
            }
    
            var imagePath = Path.Combine(pathToImage, imageName);
    
            if (!File.Exists(imagePath))
            {
                // Handle the case where the image file does not exist
                throw new FileNotFoundException($"Image file '{imageName}' not found at path: '{imagePath}'.");
            }
    
            return File.ReadAllBytes(imagePath);
        }

    }

