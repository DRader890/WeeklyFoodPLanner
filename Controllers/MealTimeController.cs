using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Foodie.Data;
using Foodie.Models;
using Foodie.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Foodie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MealTimeController : ControllerBase
    {
        private readonly FoodieDbContext _dbContext;
        private readonly ILogger<MealTimeController> _logger;

        public MealTimeController(FoodieDbContext dbContext, ILogger<MealTimeController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        // GET: api/mealtime
        [HttpGet]
        public async Task<IActionResult> GetAllMealTimes()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _logger.LogInformation($"Fetching meal times for user: {userId}");

            var mealTimes = await _dbContext.MealTimes
                .Include(mt => mt.Meals)
                .ThenInclude(m => m.Foods)
                .Where(mt => mt.UserProfileId == userId)
                .Select(mt => new MealTimeDTO
                {
                    Id = mt.Id,
                    Name = mt.Name,
                    DayId = mt.DayId,
                    Foods = mt.Meals.SelectMany(m => m.Foods).Select(f => new FoodDTO
                    {
                        Id = f.Id,
                        Name = f.Name
                    }).ToList()
                })
                .ToListAsync();

            return Ok(mealTimes);
        }

        // GET: api/mealtime/{dayId}
        [HttpGet("{dayId}")]
        public async Task<IActionResult> GetMealTimesByDay(int dayId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var mealTimes = await _dbContext.MealTimes
                .Where(mt => mt.DayId == dayId && mt.UserProfileId == userId)
                .Include(mt => mt.Meals)
                .ThenInclude(m => m.Foods)
                .Select(mt => new MealTimeDTO
                {
                    Id = mt.Id,
                    Name = mt.Name,
                    DayId = mt.DayId,
                    Foods = mt.Meals.SelectMany(m => m.Foods).Select(f => new FoodDTO
                    {
                        Id = f.Id,
                        Name = f.Name
                    }).ToList()
                })
                .ToListAsync();

            if (mealTimes.Count == 0)
            {
                return NotFound($"No mealtimes found for the day with ID {dayId}");
            }

            return Ok(mealTimes);
        }
    }
}