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
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Test")
        {
            if (Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                Database.Migrate();
            }
            else
            {
                Database.EnsureCreated();
            }
        }
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        DotNetEnv.Env.Load();

        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Test")
        {
            options.UseInMemoryDatabase("TestDatabase");
        }
        else
            options.UseSqlServer(
                Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING"));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed initial products
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                ProductId = 1,
                ProductName = "Dumbbells",
                Description = "Set of adjustable dumbbells for strength training",
                Price = 49.99m
            },
            new Product
            {
                ProductId = 2,
                ProductName = "Exercise Mat",
                Description = "High-density foam mat for yoga and floor exercises",
                Price = 19.99m
            },
            new Product
            {
                ProductId = 3,
                ProductName = "Jump Rope",
                Description = "Adjustable jump rope for cardio workouts",
                Price = 9.99m
            },
            new Product
            {
                ProductId = 4,
                ProductName = "Resistance Bands",
                Description = "Set of resistance bands for various strength exercises",
                Price = 14.99m
            },
            new Product
            {
                ProductId = 5,
                ProductName = "Kettlebell",
                Description = "Cast iron kettlebell for full-body workouts",
                Price = 29.99m
            },
            new Product
            {
                ProductId = 6,
                ProductName = "Foam Roller",
                Description = "High-density foam roller for muscle recovery",
                Price = 12.99m
            },
            new Product
            {
                ProductId = 7,
                ProductName = "Yoga Blocks",
                Description = "Set of yoga blocks for support and balance",
                Price = 8.99m
            },
            new Product
            {
                ProductId = 8,
                ProductName = "Pull-Up Bar",
                Description = "Doorway pull-up bar for upper body workouts",
                Price = 24.99m
            },
            new Product
            {
                ProductId = 9,
                ProductName = "Boxing Gloves",
                Description = "Pair of boxing gloves for boxing and kickboxing",
                Price = 34.99m
            },
            new Product
            {
                ProductId = 10,
                ProductName = "Medicine Ball",
                Description = "Medicine ball for strength and coordination exercises",
                Price = 39.99m
            }
        );

    }
}