namespace Foodie.Models
{
    public class Food // class that has properties
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserProfileId { get; set; } 
        public UserProfile UserProfile { get; set; } // nav property for food to userprofile
        public ICollection<Meal> Meals { get; set; } 

    }
}