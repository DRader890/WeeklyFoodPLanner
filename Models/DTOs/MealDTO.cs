namespace Foodie.Models.DTOs;

public class MealDTO
{
    public int Id { get; set; }
    public int FoodId { get; set; } // Foreign key to Food
    public int MealTimeId { get; set; } // Foreign key to MealTime
}
