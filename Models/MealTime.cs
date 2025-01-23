namespace Foodie.Models
{
    public class MealTime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserProfileId { get; set; } 
        public UserProfile UserProfile { get; set; } 
        public ICollection<Meal> Meals { get; set; } 
    }
}