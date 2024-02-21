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
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Test") Database.Migrate();
        else Database.EnsureCreated();
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
            }
        );
    }
}