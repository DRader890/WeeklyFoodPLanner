namespace Foodie.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserProfileId { get; set; } // Foreign Key to UserProfile
        public UserProfile UserProfile { get; set; } // Navigation Property to UserProfile
        public ICollection<Meal> Meals { get; set; } // Navigation Property to Meals

    }
}