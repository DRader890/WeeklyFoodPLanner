using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Foodie.Data;
using Foodie.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Foodie.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private FoodieDbContext _dbContext;

    public UserProfileController(FoodieDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .Include(up => up.Foods) // Include Foods
            .Select(up => new UserProfileDTO
            {
                Id = up.Id,
                IdentityUserId = up.IdentityUserId,
                Email = up.IdentityUser.Email,
                UserName = up.IdentityUser.UserName,
                Foods = up.Foods // Map Foods
            })
            .ToList());
    }
}