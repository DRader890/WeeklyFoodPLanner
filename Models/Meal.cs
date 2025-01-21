namespace Foodie.Models
{
    public class Meal // Join Entity
    {
        public int Id { get; set; }

        public int MealTimeId { get; set; } // Foreign Key to MealTime
        public MealTime MealTime { get; set; } // Navigation Property to MealTime

        // Navigation property to Food (many-to-many relationship)
        public List<Food> Foods { get; set; } // Navigation Property to Food
    }
}
