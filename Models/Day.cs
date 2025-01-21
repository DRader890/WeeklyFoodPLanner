namespace Foodie.Models
{
    public class Day
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MealTime> MealTimes { get; set; }
    }
}