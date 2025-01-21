using Microsoft.AspNetCore.Mvc;
using Foodie.Models;
using Foodie.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Foodie.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Foodie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DayController : ControllerBase
    {
        private readonly FoodieDbContext _dbContext;

        public DayController(FoodieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get a list of all days (Sunday to Saturday)
        [HttpGet]
        public IActionResult GetDays()
        {
            var days = new List<DayDTO>
            {
                new DayDTO { Id = 1, Name = "Sunday" },
                new DayDTO { Id = 2, Name = "Monday" },
                new DayDTO { Id = 3, Name = "Tuesday" },
                new DayDTO { Id = 4, Name = "Wednesday" },
                new DayDTO { Id = 5, Name = "Thursday" },
                new DayDTO { Id = 6, Name = "Friday" },
                new DayDTO { Id = 7, Name = "Saturday" }
            };

            return Ok(days);
        }

        // Get days by user
        [HttpGet("user")]
        public async Task<IActionResult> GetDaysByUser()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var days = await _dbContext.Days
                .Where(d => d.MealTimes.Any(mt => mt.UserProfileId == userId))
                .ToListAsync();

            return Ok(days);
        }
    }
}
