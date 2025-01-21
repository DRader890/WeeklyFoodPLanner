using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Foodie.Models.DTOs;

public class UserProfileDTO
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string IdentityUserId { get; set; }
    public IdentityUser IdentityUser { get; set; }

    public List<Food> Foods { get; set; }  // Add this line
}