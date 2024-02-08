namespace NutriSyncBackend.Models;
public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
   
    public User User { get; set; }
}