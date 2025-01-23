using Microsoft.AspNetCore.Identity;

namespace Foodie.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string IdentityUserId { get; set; } // Foreign Key to IdentityUser
        public IdentityUser IdentityUser { get; set; } // Navigation Property to IdentityUser
        public ICollection<Food> Foods { get; set; } 
        public ICollection<MealTime> MealTimes { get; set; } 
    }
}