using Microsoft.AspNetCore.Identity;

namespace Foodie.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string IdentityUserId { get; set; }
    public IdentityUser IdentityUser { get; set; }

    public List<Food> Foods { get; set; }  // Add this line
}