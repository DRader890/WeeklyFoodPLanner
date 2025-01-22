using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Foodie.Data;
using Foodie.Models;
using Foodie.Models.DTOs;

namespace Foodie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly FoodieDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public FoodController(FoodieDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        // Get all foods for the logged-in user
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetFoods()
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

            var foods = await _dbContext.Foods
                .Where(f => f.UserProfileId == userProfile.Id)
                .Select(f => new
                {
                    f.Id,
                    f.Name,
                    f.Description,
                    f.UserProfileId
                })
                .ToListAsync();

            return Ok(foods);
        }

        // Create a new food item
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateFood([FromBody] FoodDTO foodDto)
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

            var food = new Food
            {
                Name = foodDto.Name,
                Description = foodDto.Description,
                UserProfileId = userProfile.Id
            };

            _dbContext.Foods.Add(food);
            await _dbContext.SaveChangesAsync();

            var response = new
            {
                food.Id,
                food.Name,
                food.Description,
                food.UserProfileId
            };

            return CreatedAtAction(nameof(GetFoods), new { id = food.Id }, response);
        }

        // Edit an existing food item
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditFood(int id, [FromBody] FoodDTO foodDto)
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

            var food = await _dbContext.Foods
                .FirstOrDefaultAsync(f => f.Id == id && f.UserProfileId == userProfile.Id);

            if (food == null)
            {
                return NotFound("Food item not found.");
            }

            food.Name = foodDto.Name;
            food.Description = foodDto.Description;

            _dbContext.Foods.Update(food);
            await _dbContext.SaveChangesAsync();

            var response = new
            {
                food.Id,
                food.Name,
                food.Description,
                food.UserProfileId
            };

            return Ok(response);
        }

        // Delete a food item
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteFood(int id)
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

            var food = await _dbContext.Foods
                .FirstOrDefaultAsync(f => f.Id == id && f.UserProfileId == userProfile.Id);

            if (food == null)
            {
                return NotFound("Food item not found.");
            }

            _dbContext.Foods.Remove(food);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}