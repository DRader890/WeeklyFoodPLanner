using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Foodie.Data;
using Foodie.Models;
using Foodie.Models.DTOs;
using System.Security.Claims;

namespace Foodie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MealTimeController : ControllerBase
    {
        private readonly FoodieDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public MealTimeController(FoodieDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        // GET: api/mealtime/user
        [HttpGet("user")]
        [Authorize]
        public async Task<IActionResult> GetMealTimesByUser()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized("User is not logged in.");
            }

            var userProfile = await _dbContext.UserProfiles
                .FirstOrDefaultAsync(up => up.IdentityUserId == user.Id);

            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            var mealTimes = await _dbContext.MealTimes
                .Include(mt => mt.Meals)
                .Where(mt => mt.UserProfileId == userProfile.Id)
                .Select(mt => new MealTimeDTO
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
                })
                .ToListAsync();

            return Ok(mealTimes);
        }

        // POST: api/mealtime/assign
        [HttpPost("assign")]
        [Authorize]
        public async Task<IActionResult> AssignFoodsToMealTime([FromBody] MealAssignmentDTO mealAssignment)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized("User is not logged in.");
            }

            var userProfile = await _dbContext.UserProfiles
                .FirstOrDefaultAsync(up => up.IdentityUserId == user.Id);

            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            var mealTime = await _dbContext.MealTimes
                .Include(mt => mt.Meals)
                .FirstOrDefaultAsync(mt => mt.Id == mealAssignment.MealTimeId && mt.UserProfileId == userProfile.Id);

            if (mealTime == null)
            {
                return NotFound("MealTime not found.");
            }

            // Clear existing meals
            _dbContext.Meals.RemoveRange(mealTime.Meals); // removes all meals associated with the mealTime

            // Assign new foods to the meal time
            foreach (var foodId in mealAssignment.FoodIds) // iterate through the foodIds in the mealAssignment
            {
                var meal = new Meal
                {
                    MealTimeId = mealTime.Id,
                    FoodId = foodId
                };
                _dbContext.Meals.Add(meal);
            }

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}