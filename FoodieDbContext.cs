using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Foodie.Models;

namespace Foodie.Data
{
    public class FoodieDbContext : IdentityDbContext<IdentityUser> // Inherit from IdentityDbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; } // setting up  a table for UserProfiles to be stored in the database
        public DbSet<Food> Foods { get; set; }
        public DbSet<MealTime> MealTimes { get; set; }
        public DbSet<Meal> Meals { get; set; }

        public FoodieDbContext(DbContextOptions<FoodieDbContext> options) : base(options) { } // allow options to be passed to the base class

        protected override void OnModelCreating(ModelBuilder modelBuilder) // method to configure models
        {
            base.OnModelCreating(modelBuilder);

            // Meal ↔ MealTime (Many-to-One)
            modelBuilder.Entity<Meal>()  // moldelBuilder.Entity<entityName> method is used to configure the entity
                .HasOne(m => m.MealTime)
                .WithMany(mt => mt.Meals)
                .HasForeignKey(m => m.MealTimeId);

            // Meal ↔ Food (Many-to-One)
            modelBuilder.Entity<Meal>()
                .HasOne(m => m.Food)
                .WithMany(f => f.Meals)
                .HasForeignKey(m => m.FoodId);

            // Ensure UserProfileId is included in MealTime
            modelBuilder.Entity<MealTime>()
                .Property(mt => mt.UserProfileId) // propery method to ensure UserProfileId is included in MealTime
                .IsRequired();

            // UserProfile ↔ MealTime (One-to-Many)
            modelBuilder.Entity<MealTime>()
                .HasOne(mt => mt.UserProfile)
                .WithMany(up => up.MealTimes)
                .HasForeignKey(mt => mt.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

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

            // Remove static seeding for MealTimes
        }
    }
}
