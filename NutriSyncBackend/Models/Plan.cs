namespace NutriSyncBackend.Models;
public class Plan
{
    public int PlanId { get; set; }
    public string PlanName { get; set; }
    public string Description { get; set; }
    public int CalorieIn { get; set; }
    public int CalorieMax { get; set; }

    public User User { get; set; }
    
}