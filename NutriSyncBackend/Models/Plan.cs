
public class Plan
{
    public int PlanId { get; set; }
    public string PlanName { get; set; }
    public string Description { get; set; }
    public int CalorieIn { get; set; }
    public int CalorieMax { get; set; }
    public string UserId { get; set; }

    // Navigation property
    public User User { get; set; }
    
}