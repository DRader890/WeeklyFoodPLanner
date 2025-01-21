namespace Foodie.Models;

public class MealTime
{
    public int Id { get; set; }
    public int DayId { get; set; }
    public Day Day { get; set; }
    public string Name { get; set; }
    public int UserProfileId { get; set; } // Ensure this is an int
    public UserProfile UserProfile { get; set; }
    public ICollection<Meal> Meals { get; set; }
}