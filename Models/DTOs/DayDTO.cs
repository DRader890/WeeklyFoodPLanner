namespace Foodie.Models.DTOs;

public class DayDTO
{
    public int Id { get; set; }
    public string Name { get; set; } // e.g., Sunday, Monday

    public List<MealTimeDTO> MealTimes { get; set; } // Nested MealTimes
}
