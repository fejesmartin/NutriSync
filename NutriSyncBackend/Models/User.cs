using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace NutriSyncBackend.Models;

public class User: IdentityUser
{
    public string UserId { get; set; } 
    public string UserName { get; set; }
    public byte[]? ProfilePicture { get; set; }
    public string DisplayName { get; set; }
    public List<Product> BoughtProducts { get; set; }
    public List<Plan> Plans { get; set; }
}