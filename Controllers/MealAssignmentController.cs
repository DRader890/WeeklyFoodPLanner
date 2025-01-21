using Microsoft.AspNetCore.Mvc;
using Foodie.Data;
using Foodie.Models;
using Foodie.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Foodie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MealAssignmentController : ControllerBase
    {
        private readonly FoodieDbContext _dbContext;

        public MealAssignmentController(FoodieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/mealassignment/{mealTimeId}
        // Get all food assignments for a specific mealtime
        [HttpGet("{mealTimeId}")]
        public IActionResult GetAssignedFoods(int mealTimeId)
        {
            var mealTime = _dbContext.MealTimes
                .Include(mt => mt.Meals)
                    .ThenInclude(m => m.Foods)
                .FirstOrDefault(mt => mt.Id == mealTimeId);

            if (mealTime == null)
            {
                return NotFound("MealTime not found.");
            }

            var assignedFoods = mealTime.Meals
                .SelectMany(m => m.Foods)
                .Select(f => new FoodDTO
                {
                    Id = f.Id,
                    Name = f.Name,
                    Description = f.Description
                })
                .ToList();

            return Ok(assignedFoods);
        }

        // POST: api/mealassignment
        // Assign foods to a mealtime (e.g., breakfast, lunch, or dinner)
        [HttpPost]
        public async Task<IActionResult> AssignFoodsToMealTime([FromBody] MealAssignmentDTO mealAssignmentDto)
        {
            var mealTime = await _dbContext.MealTimes
                .FirstOrDefaultAsync(mt => mt.Id == mealAssignmentDto.MealTimeId);

            if (mealTime == null)
            {
                return NotFound("MealTime not found.");
            }

            var foods = await _dbContext.Foods
                .Where(f => mealAssignmentDto.FoodIds.Contains(f.Id))
                .ToListAsync();

            if (foods.Count != mealAssignmentDto.FoodIds.Count)
            {
                return BadRequest("Some food items were not found.");
            }

            var meal = new Meal
            {
                MealTimeId = mealAssignmentDto.MealTimeId,
                Foods = foods
            };

            _dbContext.Meals.Add(meal);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAssignedFoods), new { mealTimeId = meal.MealTimeId }, meal);
        }

        // DELETE: api/mealassignment/{mealId}
        // Remove a food assignment from a mealtime
        [HttpDelete("{mealId}")]
        public async Task<IActionResult> RemoveFoodFromMealTime(int mealId)
        {
            var meal = await _dbContext.Meals
                .Include(m => m.Foods)
                .FirstOrDefaultAsync(m => m.Id == mealId);

            if (meal == null)
            {
                return NotFound("Meal not found.");
            }

            _dbContext.Meals.Remove(meal);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("public")]
        public IActionResult GetPublic()
        {
            return Ok("This is a public endpoint");
        }
    }
}
