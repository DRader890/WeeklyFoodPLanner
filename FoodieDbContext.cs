using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Foodie.Models;
using Foodie.Models.DTOs;

namespace Foodie.Data
{
    public class FoodieDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly IConfiguration _configuration;

        public FoodieDbContext(DbContextOptions<FoodieDbContext> context, IConfiguration config) : base(context)
        {
            _configuration = config;
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<MealTime> MealTimes { get; set; }
        public DbSet<Meal> Meals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Day ↔ MealTime (One-to-Many)
            modelBuilder.Entity<MealTime>()
                .HasOne(mt => mt.Day)
                .WithMany(d => d.MealTimes)
                .HasForeignKey(mt => mt.DayId);

            // MealTime ↔ Meal (One-to-Many)
            modelBuilder.Entity<Meal>()
                .HasOne(m => m.MealTime)
                .WithMany(mt => mt.Meals)
                .HasForeignKey(m => m.MealTimeId);

            // Meal ↔ Food (Many-to-Many)
            modelBuilder.Entity<Meal>()
                .HasMany(m => m.Foods)
                .WithMany(f => f.Meals)
                .UsingEntity<Dictionary<string, object>>(
                    "MealFood",
                    j => j.HasOne<Food>().WithMany().HasForeignKey("FoodsId"),
                    j => j.HasOne<Meal>().WithMany().HasForeignKey("MealsId"),
                    j =>
                    {
                        j.HasKey("MealsId", "FoodsId");
                        j.ToTable("MealFood");
                    });

            // Ensure UserProfileId is included in MealTime
            modelBuilder.Entity<MealTime>()
                .Property(mt => mt.UserProfileId)
                .IsRequired();

            // UserProfile ↔ Food (One-to-Many)
            modelBuilder.Entity<Food>()
                .HasOne(f => f.UserProfile)
                .WithMany(up => up.Foods)
                .HasForeignKey(f => f.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserProfile ↔ IdentityUser (One-to-One)
            modelBuilder.Entity<UserProfile>()
                .HasOne(up => up.IdentityUser)
                .WithMany()
                .HasForeignKey(up => up.IdentityUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed IdentityUser with only Email (without UserName)
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "3",
                    Email = "dale@gmail.com",
                    UserName = "dale",
                    NormalizedEmail = "DALE@GMAIL.COM",
                    NormalizedUserName = "DALE",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Pp3837411")
                },
                new IdentityUser
                {
                    Id = "4",
                    Email = "blake@gmail.com",
                    UserName = "blake",
                    NormalizedEmail = "BLAKE@GMAIL.COM",
                    NormalizedUserName = "BLAKE",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "12345678")
                }
            );

            // Seed UserProfiles and link to IdentityUser by IdentityUserId
            modelBuilder.Entity<UserProfile>().HasData(
                new UserProfile
                {
                    Id = 1,
                    IdentityUserId = "3" // Link to IdentityUser with Id "3"
                },
                new UserProfile
                {
                    Id = 2,
                    IdentityUserId = "4" // Link to IdentityUser with Id "4"
                }
            );

            // Seed Foods
            modelBuilder.Entity<Food>().HasData(
                new Food { Id = 1, Name = "Chicken", Description = "Cut, season and throw in pan", UserProfileId = 1 },
                new Food { Id = 2, Name = "Rice", Description = "Put in boiling water", UserProfileId = 1 },
                new Food { Id = 3, Name = "Bacon", Description = "Put in pan", UserProfileId = 1 },
                new Food { Id = 4, Name = "Eggs", Description = "Put in pan, season", UserProfileId = 1 },
                new Food { Id = 5, Name = "French Toast", Description = "Crack eggs, cinnamon, sugar, dip bread and put in pan", UserProfileId = 1 },
                new Food { Id = 6, Name = "Steak", Description = "Season and grill", UserProfileId = 2 },
                new Food { Id = 7, Name = "Pasta", Description = "Boil and add sauce", UserProfileId = 2 },
                new Food { Id = 8, Name = "Salad", Description = "Chop and mix vegetables", UserProfileId = 2 },
                new Food { Id = 9, Name = "Fish", Description = "Season and bake", UserProfileId = 2 },
                new Food { Id = 10, Name = "Soup", Description = "Boil ingredients", UserProfileId = 2 }
            );

            // Seed Days (Sunday to Saturday)
            modelBuilder.Entity<Day>().HasData(
                new Day { Id = 1, Name = "Sunday" },
                new Day { Id = 2, Name = "Monday" },
                new Day { Id = 3, Name = "Tuesday" },
                new Day { Id = 4, Name = "Wednesday" },
                new Day { Id = 5, Name = "Thursday" },
                new Day { Id = 6, Name = "Friday" },
                new Day { Id = 7, Name = "Saturday" }
            );

            // Seed MealTimes (Breakfast, Lunch, Dinner for each day)
            modelBuilder.Entity<MealTime>().HasData(
                new MealTime { Id = 1, DayId = 1, Name = "Breakfast", UserProfileId = 1 },
                new MealTime { Id = 2, DayId = 1, Name = "Lunch", UserProfileId = 1 },
                new MealTime { Id = 3, DayId = 1, Name = "Dinner", UserProfileId = 1 },

                new MealTime { Id = 4, DayId = 2, Name = "Breakfast", UserProfileId = 1 },
                new MealTime { Id = 5, DayId = 2, Name = "Lunch", UserProfileId = 1 },
                new MealTime { Id = 6, DayId = 2, Name = "Dinner", UserProfileId = 1 },

                new MealTime { Id = 7, DayId = 3, Name = "Breakfast", UserProfileId = 1 },
                new MealTime { Id = 8, DayId = 3, Name = "Lunch", UserProfileId = 1 },
                new MealTime { Id = 9, DayId = 3, Name = "Dinner", UserProfileId = 1 },

                new MealTime { Id = 10, DayId = 4, Name = "Breakfast", UserProfileId = 1 },
                new MealTime { Id = 11, DayId = 4, Name = "Lunch", UserProfileId = 1 },
                new MealTime { Id = 12, DayId = 4, Name = "Dinner", UserProfileId = 1 },

                new MealTime { Id = 13, DayId = 5, Name = "Breakfast", UserProfileId = 1 },
                new MealTime { Id = 14, DayId = 5, Name = "Lunch", UserProfileId = 1 },
                new MealTime { Id = 15, DayId = 5, Name = "Dinner", UserProfileId = 1 },

                new MealTime { Id = 16, DayId = 6, Name = "Breakfast", UserProfileId = 1 },
                new MealTime { Id = 17, DayId = 6, Name = "Lunch", UserProfileId = 1 },
                new MealTime { Id = 18, DayId = 6, Name = "Dinner", UserProfileId = 1 },

                new MealTime { Id = 19, DayId = 7, Name = "Breakfast", UserProfileId = 1 },
                new MealTime { Id = 20, DayId = 7, Name = "Lunch", UserProfileId = 1 },
                new MealTime { Id = 21, DayId = 7, Name = "Dinner", UserProfileId = 1 },

                new MealTime { Id = 22, DayId = 1, Name = "Breakfast", UserProfileId = 2 },
                new MealTime { Id = 23, DayId = 1, Name = "Lunch", UserProfileId = 2 },
                new MealTime { Id = 24, DayId = 1, Name = "Dinner", UserProfileId = 2 },

                new MealTime { Id = 25, DayId = 2, Name = "Breakfast", UserProfileId = 2 },
                new MealTime { Id = 26, DayId = 2, Name = "Lunch", UserProfileId = 2 },
                new MealTime { Id = 27, DayId = 2, Name = "Dinner", UserProfileId = 2 },

                new MealTime { Id = 28, DayId = 3, Name = "Breakfast", UserProfileId = 2 },
                new MealTime { Id = 29, DayId = 3, Name = "Lunch", UserProfileId = 2 },
                new MealTime { Id = 30, DayId = 3, Name = "Dinner", UserProfileId = 2 },

                new MealTime { Id = 31, DayId = 4, Name = "Breakfast", UserProfileId = 2 },
                new MealTime { Id = 32, DayId = 4, Name = "Lunch", UserProfileId = 2 },
                new MealTime { Id = 33, DayId = 4, Name = "Dinner", UserProfileId = 2 },

                new MealTime { Id = 34, DayId = 5, Name = "Breakfast", UserProfileId = 2 },
                new MealTime { Id = 35, DayId = 5, Name = "Lunch", UserProfileId = 2 },
                new MealTime { Id = 36, DayId = 5, Name = "Dinner", UserProfileId = 2 },

                new MealTime { Id = 37, DayId = 6, Name = "Breakfast", UserProfileId = 2 },
                new MealTime { Id = 38, DayId = 6, Name = "Lunch", UserProfileId = 2 },
                new MealTime { Id = 39, DayId = 6, Name = "Dinner", UserProfileId = 2 },

                new MealTime { Id = 40, DayId = 7, Name = "Breakfast", UserProfileId = 2 },
                new MealTime { Id = 41, DayId = 7, Name = "Lunch", UserProfileId = 2 },
                new MealTime { Id = 42, DayId = 7, Name = "Dinner", UserProfileId = 2 }
            );

            // Seed Meals
            modelBuilder.Entity<Meal>().HasData(
                new Meal { Id = 1, MealTimeId = 1 },
                new Meal { Id = 2, MealTimeId = 2 },
                new Meal { Id = 3, MealTimeId = 3 },
                new Meal { Id = 4, MealTimeId = 4 },
                new Meal { Id = 5, MealTimeId = 5 },
                new Meal { Id = 6, MealTimeId = 6 },
                new Meal { Id = 7, MealTimeId = 22 },
                new Meal { Id = 8, MealTimeId = 23 },
                new Meal { Id = 9, MealTimeId = 24 },
                new Meal { Id = 10, MealTimeId = 25 },
                new Meal { Id = 11, MealTimeId = 26 },
                new Meal { Id = 12, MealTimeId = 27 }
            );

            // Seed MealFood join table
            modelBuilder.Entity("MealFood").HasData(
                new { MealsId = 1, FoodsId = 1 },
                new { MealsId = 1, FoodsId = 2 },
                new { MealsId = 2, FoodsId = 3 },
                new { MealsId = 3, FoodsId = 4 },
                new { MealsId = 4, FoodsId = 5 },
                new { MealsId = 5, FoodsId = 1 },
                new { MealsId = 6, FoodsId = 2 },
                new { MealsId = 7, FoodsId = 6 },
                new { MealsId = 8, FoodsId = 7 },
                new { MealsId = 9, FoodsId = 8 },
                new { MealsId = 10, FoodsId = 9 },
                new { MealsId = 11, FoodsId = 10 },
                new { MealsId = 12, FoodsId = 6 }
            );
        }

        public void SeedMealTimesForUser(int userId)
{
    var mealTimes = new List<MealTime>
    {
        new MealTime { DayId = 1, Name = "Breakfast", UserProfileId = userId },
        new MealTime { DayId = 1, Name = "Lunch", UserProfileId = userId },
        new MealTime { DayId = 1, Name = "Dinner", UserProfileId = userId },
        new MealTime { DayId = 2, Name = "Breakfast", UserProfileId = userId },
        new MealTime { DayId = 2, Name = "Lunch", UserProfileId = userId },
        new MealTime { DayId = 2, Name = "Dinner", UserProfileId = userId },
        new MealTime { DayId = 3, Name = "Breakfast", UserProfileId = userId },
        new MealTime { DayId = 3, Name = "Lunch", UserProfileId = userId },
        new MealTime { DayId = 3, Name = "Dinner", UserProfileId = userId },
        new MealTime { DayId = 4, Name = "Breakfast", UserProfileId = userId },
        new MealTime { DayId = 4, Name = "Lunch", UserProfileId = userId },
        new MealTime { DayId = 4, Name = "Dinner", UserProfileId = userId },
        new MealTime { DayId = 5, Name = "Breakfast", UserProfileId = userId },
        new MealTime { DayId = 5, Name = "Lunch", UserProfileId = userId },
        new MealTime { DayId = 5, Name = "Dinner", UserProfileId = userId },
        new MealTime { DayId = 6, Name = "Breakfast", UserProfileId = userId },
        new MealTime { DayId = 6, Name = "Lunch", UserProfileId = userId },
        new MealTime { DayId = 6, Name = "Dinner", UserProfileId = userId },
        new MealTime { DayId = 7, Name = "Breakfast", UserProfileId = userId },
        new MealTime { DayId = 7, Name = "Lunch", UserProfileId = userId },
        new MealTime { DayId = 7, Name = "Dinner", UserProfileId = userId }
    };

    MealTimes.AddRange(mealTimes);
    SaveChanges();
}
    }
}
