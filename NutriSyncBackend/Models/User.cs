using Microsoft.AspNetCore.Identity;

namespace NutriSyncBackend.Models;

public class User: IdentityUser
{
    public UserProfile? UserProfile { get; set; }
    public int ProfileId { get; set; }
}