using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace NutriSyncBackend.Authentication.Context;

#region UserContext

// Represents the database context for user-related entities and Identity framework
public class UserContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
        // Check and create the database and tables if they don't exist
        var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        if (databaseCreator != null)
        {
            if (!databaseCreator.CanConnect()) databaseCreator.Create();
            if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
        }
    }

    // Configures the database connection based on the environment
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

    // Configures the database model
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Additional model configurations can be added if needed
    }
}

#endregion