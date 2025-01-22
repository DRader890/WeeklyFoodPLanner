namespace Foodie.Models
{
    public class MealTime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserProfileId { get; set; } // Foreign Key to UserProfile
        public UserProfile UserProfile { get; set; } // Navigation Property to UserProfile
        public ICollection<Meal> Meals { get; set; } // List of Meals
    }
}