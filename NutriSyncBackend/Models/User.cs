using Microsoft.AspNetCore.Identity;

public class User : IdentityUser<string>
{
    public byte[]? ProfilePictureData { get; set; }
    public string? ProfileImageMimeType { get; set; }
    public string DisplayName { get; set; }

    // Navigation properties
    public List<Product> BoughtProducts { get; set; }
    public List<Plan> Plans { get; set; }
}