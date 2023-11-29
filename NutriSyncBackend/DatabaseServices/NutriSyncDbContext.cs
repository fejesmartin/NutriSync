using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NutriSyncBackend.Models;

namespace NutriSyncBackend.DatabaseServices;

public class NutriSyncDbContext: IdentityDbContext<User,IdentityRole,string>
{
    public NutriSyncDbContext(DbContextOptions<NutriSyncDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
}