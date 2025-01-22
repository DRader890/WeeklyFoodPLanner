using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Foodie.Data;
using Foodie.Models;
using Foodie.Models.DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace Foodie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly FoodieDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public UserProfileController(FoodieDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        // GET: api/userprofile
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserProfile()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized("User is not logged in.");
            }

            var userProfile = await _dbContext.UserProfiles
                .Include(up => up.IdentityUser)
                .Include(up => up.Foods)
                .Include(up => up.MealTimes)
                .ThenInclude(mt => mt.Meals)
                .Where(up => up.IdentityUserId == user.Id)
                .Select(up => new UserProfileDTO
                {
                    Id = up.Id,
                    IdentityUserId = up.IdentityUserId,
                    Email = up.IdentityUser.Email,
                    UserName = up.IdentityUser.UserName,
                    Foods = up.Foods.Select(f => new FoodDTO
                    {
                        Id = f.Id,
                        Name = f.Name,
                        Description = f.Description,
                        UserProfileId = f.UserProfileId
                    }).ToList(),
                    MealTimes = up.MealTimes.Select(mt => new MealTimeDTO
                    {
                        Id = mt.Id,
                        Name = mt.Name,
                        UserProfileId = mt.UserProfileId, // Ensure UserProfileId is included in the DTO
                        Meals = mt.Meals.Select(m => new MealDTO
                        {
                            Id = m.Id,
                            MealTimeId = m.MealTimeId,
                            FoodId = m.FoodId
                        }).ToList()
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            return Ok(userProfile);
        }
    }
}