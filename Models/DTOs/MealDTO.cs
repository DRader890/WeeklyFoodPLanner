namespace Foodie.Models.DTOs
{
    public class MealDTO
    {
        public int Id { get; set; }
        public int MealTimeId { get; set; } // Foreign key to MealTime
        public int FoodId { get; set; } // Foreign Key to Food
    }
}
