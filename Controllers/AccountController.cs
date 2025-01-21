using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Foodie.Data;
using Foodie.Models;
using Foodie.Models.DTOs;
using System.Threading.Tasks;

namespace Foodie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly FoodieDbContext _dbContext;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, FoodieDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDTO registrationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new IdentityUser { UserName = registrationDto.Email, Email = registrationDto.Email };
            var result = await _userManager.CreateAsync(user, registrationDto.Password);

            if (result.Succeeded)
            {
                // Create UserProfile
                var userProfile = new UserProfile { IdentityUserId = user.Id };
                _dbContext.UserProfiles.Add(userProfile);
                await _dbContext.SaveChangesAsync();

                // Assign days and mealtimes
                _dbContext.SeedMealTimesForUser(userProfile.Id);

                return Ok("User registered successfully with schedule");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }
    }
}