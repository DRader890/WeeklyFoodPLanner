namespace Foodie.Models.DTOs
{
    public class MealTimeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserProfileId { get; set; } // Foreign Key to UserProfile
        public List<MealDTO> Meals { get; set; } // List of Meal DTOs
    }

}
