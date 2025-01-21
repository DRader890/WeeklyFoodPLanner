using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Foodie.Data;
using Foodie.Models;
using Foodie.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Foodie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FoodController : ControllerBase
    {
        private readonly FoodieDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public FoodController(FoodieDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        // Get foods of the logged-in user
        [HttpGet]
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
                .ToListAsync();

            return Ok(foods);
        }

        // Create a new food item
        [HttpPost]
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

            return CreatedAtAction(nameof(GetFoods), new { id = food.Id }, food);
        }

        // Edit an existing food item
        [HttpPut("{id}")]
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
                return NotFound("Food not found or not authorized to edit.");
            }

            food.Name = foodDto.Name;
            food.Description = foodDto.Description;

            _dbContext.Foods.Update(food);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // Delete a food item
        [HttpDelete("{id}")]
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
                return NotFound("Food not found or not authorized to delete.");
            }

            _dbContext.Foods.Remove(food);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}





