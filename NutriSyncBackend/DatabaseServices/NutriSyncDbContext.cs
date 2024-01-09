using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NutriSyncBackend.Models;

namespace NutriSyncBackend.DatabaseServices
{
    #region NutriSyncDbContext

    // NutriSyncDbContext class that extends IdentityDbContext with User and IdentityRole
    public class NutriSyncDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        // DbSet for the User entity
        public DbSet<User> Users { get; set; }

        // Constructor for NutriSyncDbContext
        public NutriSyncDbContext()
        {
            // Apply database migration if it's a relational database
            if (Database.IsRelational()) Database.Migrate();
        }

        // Override method to configure database connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Get connection string from environment variables
            var connectionString = Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");

            // Use SQL Server with the provided connection string
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    #endregion
}