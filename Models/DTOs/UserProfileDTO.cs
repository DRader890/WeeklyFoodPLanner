using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Foodie.Models.DTOs
{
    public class UserProfileDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string IdentityUserId { get; set; }
        public List<FoodDTO> Foods { get; set; } // List of Food DTOs
        public List<MealTimeDTO> MealTimes { get; set; } // List of MealTime DTOs
    }
}