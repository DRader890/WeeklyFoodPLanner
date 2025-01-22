namespace Foodie.Models.DTOs
{
    public class MealAssignmentDTO
    {
        public int MealTimeId { get; set; }
        public List<int> FoodIds { get; set; } // List of food IDs to be assigned
    }
}
