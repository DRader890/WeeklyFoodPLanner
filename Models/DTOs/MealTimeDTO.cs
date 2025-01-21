namespace Foodie.Models.DTOs
{
    public class MealTimeDTO
    {
        public int Id { get; set; }
        public int DayId { get; set; }
        public string Name { get; set; }
        public List<FoodDTO> Foods { get; set; } // Add this property
    }

}
