using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Foodie.Data;
using Foodie.Models;
using Foodie.Models.DTOs;
using Microsoft.Extensions.Logging;

namespace Foodie.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly FoodieDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<AuthController> _logger;

        public AuthController(FoodieDbContext dbContext, UserManager<IdentityUser> userManager, ILogger<AuthController> logger)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
                if (user == null)
                {
                    return Unauthorized("Invalid email or password.");
                }

                var hasher = new PasswordHasher<IdentityUser>();
                var result = hasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);
                if (result == PasswordVerificationResult.Success)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                    return Ok(new { message = "Login successful" });
                }

                return Unauthorized("Invalid email or password.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during login.");
                return StatusCode(500);
            }
        }

        [HttpGet("logout")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Ok(new { message = "Logout successful" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during logout.");
                return StatusCode(500);
            }
        }

        [HttpGet("Me")]
        [Authorize]
        public IActionResult Me()
        {
            var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _logger.LogInformation("IdentityUserId: {IdentityUserId}", identityUserId);

            var profile = _dbContext.UserProfiles
                .Include(up => up.Foods)
                .Include(up => up.MealTimes)
                .ThenInclude(mt => mt.Meals)
                .ThenInclude(m => m.Food)
                .SingleOrDefault(up => up.IdentityUserId == identityUserId);

            if (profile != null)
            {
                var userDto = new UserProfileDTO
                {
                    Id = profile.Id,
                    IdentityUserId = identityUserId,
                    UserName = User.FindFirstValue(ClaimTypes.Name),
                    Email = User.FindFirstValue(ClaimTypes.Email),
                    Foods = profile.Foods.Select(f => new FoodDTO
                    {
                        Id = f.Id,
                        Name = f.Name,
                        Description = f.Description,
                        UserProfileId = f.UserProfileId
                    }).ToList(),
                    MealTimes = profile.MealTimes.Select(mt => new MealTimeDTO
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
                };

                return Ok(userDto);
            }

            _logger.LogWarning("User profile not found for IdentityUserId: {IdentityUserId}", identityUserId);
            return NotFound();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationDTO registration)
        {
            try
            {
                var user = new IdentityUser
                {
                    UserName = registration.UserName,
                    Email = registration.Email
                };

                var result = await _userManager.CreateAsync(user, registration.Password);
                if (result.Succeeded)
                {
                    var userProfile = new UserProfile
                    {
                        IdentityUserId = user.Id,
                    };
                    _dbContext.UserProfiles.Add(userProfile);
                    await _dbContext.SaveChangesAsync();

                    // Create default MealTimes for the new user
                    var mealTimes = new List<MealTime>();
                    for (int day = 1; day <= 7; day++)
                    {
                        mealTimes.Add(new MealTime { Name = "Breakfast", UserProfileId = userProfile.Id });
                        mealTimes.Add(new MealTime { Name = "Lunch", UserProfileId = userProfile.Id });
                        mealTimes.Add(new MealTime { Name = "Dinner", UserProfileId = userProfile.Id });
                    }
                    _dbContext.MealTimes.AddRange(mealTimes);
                    await _dbContext.SaveChangesAsync();

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                    return Ok(new { message = "Registration successful" });
                }
                return StatusCode(500);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during registration.");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}