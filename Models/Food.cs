namespace Foodie.Models;

public class Food
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }

    public List<Meal> Meals { get; set; }

}