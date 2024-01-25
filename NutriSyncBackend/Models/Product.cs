
public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public byte[] ImageData { get; set; }
    public string ImageMimeType { get; set; }
    public string UserId { get; set; }

    // Navigation property
    public User User { get; set; }
    
}