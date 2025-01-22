namespace Foodie.Models
{
    public class Meal
    {
        public int Id { get; set; }

        public int MealTimeId { get; set; } // Foreign Key to MealTime
        public MealTime MealTime { get; set; } // Navigation Property to MealTime

        public int FoodId { get; set; } // Foreign Key to Food
        public Food Food { get; set; } // Navigation Property to Food
    }

}
