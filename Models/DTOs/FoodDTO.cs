namespace Foodie.Models.DTOs;

public class FoodDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public int UserProfileId { get; set; } // Foreign key to UserProfile
}
