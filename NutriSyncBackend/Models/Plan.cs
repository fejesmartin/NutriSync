namespace NutriSyncBackend.Models;

public class Plan
{
    public int PlanId { get; set; }
    public string PlanName { get; set; }
    public DateTime CreatedAt = DateTime.Now;
    public string Description { get; set; }
    public int CalorieIn { get; set; }
    public int CalorieMax { get; set; }
    // Foreign key
    public int UserId { get; set; }

    // Navigation property
    public User User { get; set; }
}