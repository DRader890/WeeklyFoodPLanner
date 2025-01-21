﻿// <auto-generated />
using System;
using Foodie.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WeeklyFoodPlanner.Migrations
{
    [DbContext(typeof(FoodieDbContext))]
    partial class FoodieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Foodie.Models.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Days");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sunday"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Monday"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tuesday"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Wednesday"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Thursday"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Friday"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Saturday"
                        });
                });

            modelBuilder.Entity("Foodie.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Foods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Cut, season and throw in pan",
                            Name = "Chicken",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Put in boiling water",
                            Name = "Rice",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Put in pan",
                            Name = "Bacon",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "Put in pan, season",
                            Name = "Eggs",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 5,
                            Description = "Crack eggs, cinnamon, sugar, dip bread and put in pan",
                            Name = "French Toast",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 6,
                            Description = "Season and grill",
                            Name = "Steak",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 7,
                            Description = "Boil and add sauce",
                            Name = "Pasta",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 8,
                            Description = "Chop and mix vegetables",
                            Name = "Salad",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 9,
                            Description = "Season and bake",
                            Name = "Fish",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 10,
                            Description = "Boil ingredients",
                            Name = "Soup",
                            UserProfileId = 2
                        });
                });

            modelBuilder.Entity("Foodie.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MealTimeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MealTimeId");

                    b.ToTable("Meals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MealTimeId = 1
                        },
                        new
                        {
                            Id = 2,
                            MealTimeId = 2
                        },
                        new
                        {
                            Id = 3,
                            MealTimeId = 3
                        },
                        new
                        {
                            Id = 4,
                            MealTimeId = 4
                        },
                        new
                        {
                            Id = 5,
                            MealTimeId = 5
                        },
                        new
                        {
                            Id = 6,
                            MealTimeId = 6
                        },
                        new
                        {
                            Id = 7,
                            MealTimeId = 22
                        },
                        new
                        {
                            Id = 8,
                            MealTimeId = 23
                        },
                        new
                        {
                            Id = 9,
                            MealTimeId = 24
                        },
                        new
                        {
                            Id = 10,
                            MealTimeId = 25
                        },
                        new
                        {
                            Id = 11,
                            MealTimeId = 26
                        },
                        new
                        {
                            Id = 12,
                            MealTimeId = 27
                        });
                });

            modelBuilder.Entity("Foodie.Models.MealTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DayId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("MealTimes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DayId = 1,
                            Name = "Breakfast",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 2,
                            DayId = 1,
                            Name = "Lunch",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 3,
                            DayId = 1,
                            Name = "Dinner",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 4,
                            DayId = 2,
                            Name = "Breakfast",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 5,
                            DayId = 2,
                            Name = "Lunch",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 6,
                            DayId = 2,
                            Name = "Dinner",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 7,
                            DayId = 3,
                            Name = "Breakfast",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 8,
                            DayId = 3,
                            Name = "Lunch",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 9,
                            DayId = 3,
                            Name = "Dinner",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 10,
                            DayId = 4,
                            Name = "Breakfast",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 11,
                            DayId = 4,
                            Name = "Lunch",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 12,
                            DayId = 4,
                            Name = "Dinner",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 13,
                            DayId = 5,
                            Name = "Breakfast",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 14,
                            DayId = 5,
                            Name = "Lunch",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 15,
                            DayId = 5,
                            Name = "Dinner",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 16,
                            DayId = 6,
                            Name = "Breakfast",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 17,
                            DayId = 6,
                            Name = "Lunch",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 18,
                            DayId = 6,
                            Name = "Dinner",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 19,
                            DayId = 7,
                            Name = "Breakfast",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 20,
                            DayId = 7,
                            Name = "Lunch",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 21,
                            DayId = 7,
                            Name = "Dinner",
                            UserProfileId = 1
                        },
                        new
                        {
                            Id = 22,
                            DayId = 1,
                            Name = "Breakfast",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 23,
                            DayId = 1,
                            Name = "Lunch",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 24,
                            DayId = 1,
                            Name = "Dinner",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 25,
                            DayId = 2,
                            Name = "Breakfast",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 26,
                            DayId = 2,
                            Name = "Lunch",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 27,
                            DayId = 2,
                            Name = "Dinner",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 28,
                            DayId = 3,
                            Name = "Breakfast",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 29,
                            DayId = 3,
                            Name = "Lunch",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 30,
                            DayId = 3,
                            Name = "Dinner",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 31,
                            DayId = 4,
                            Name = "Breakfast",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 32,
                            DayId = 4,
                            Name = "Lunch",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 33,
                            DayId = 4,
                            Name = "Dinner",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 34,
                            DayId = 5,
                            Name = "Breakfast",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 35,
                            DayId = 5,
                            Name = "Lunch",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 36,
                            DayId = 5,
                            Name = "Dinner",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 37,
                            DayId = 6,
                            Name = "Breakfast",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 38,
                            DayId = 6,
                            Name = "Lunch",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 39,
                            DayId = 6,
                            Name = "Dinner",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 40,
                            DayId = 7,
                            Name = "Breakfast",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 41,
                            DayId = 7,
                            Name = "Lunch",
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 42,
                            DayId = 7,
                            Name = "Dinner",
                            UserProfileId = 2
                        });
                });

            modelBuilder.Entity("Foodie.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("IdentityUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("UserProfiles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdentityUserId = "3"
                        },
                        new
                        {
                            Id = 2,
                            IdentityUserId = "4"
                        });
                });

            modelBuilder.Entity("MealFood", b =>
                {
                    b.Property<int>("MealsId")
                        .HasColumnType("integer");

                    b.Property<int>("FoodsId")
                        .HasColumnType("integer");

                    b.HasKey("MealsId", "FoodsId");

                    b.HasIndex("FoodsId");

                    b.ToTable("MealFood", (string)null);

                    b.HasData(
                        new
                        {
                            MealsId = 1,
                            FoodsId = 1
                        },
                        new
                        {
                            MealsId = 1,
                            FoodsId = 2
                        },
                        new
                        {
                            MealsId = 2,
                            FoodsId = 3
                        },
                        new
                        {
                            MealsId = 3,
                            FoodsId = 4
                        },
                        new
                        {
                            MealsId = 4,
                            FoodsId = 5
                        },
                        new
                        {
                            MealsId = 5,
                            FoodsId = 1
                        },
                        new
                        {
                            MealsId = 6,
                            FoodsId = 2
                        },
                        new
                        {
                            MealsId = 7,
                            FoodsId = 6
                        },
                        new
                        {
                            MealsId = 8,
                            FoodsId = 7
                        },
                        new
                        {
                            MealsId = 9,
                            FoodsId = 8
                        },
                        new
                        {
                            MealsId = 10,
                            FoodsId = 9
                        },
                        new
                        {
                            MealsId = 11,
                            FoodsId = 10
                        },
                        new
                        {
                            MealsId = 12,
                            FoodsId = 6
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "da35abe0-cc7a-4c07-959d-4441443e5f9a",
                            Email = "dale@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "DALE@GMAIL.COM",
                            NormalizedUserName = "DALE",
                            PasswordHash = "AQAAAAIAAYagAAAAELfRW/lIli5WyJhd5/P/Vo1iiHMhnuixGNvB5AoDlUEc3f+2e1bK8gT3RnXH7cZ4og==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2e28f1fd-3607-44f6-add3-5b3b3c1feca5",
                            TwoFactorEnabled = false,
                            UserName = "dale"
                        },
                        new
                        {
                            Id = "4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "972f9724-5681-465d-86aa-4f02d3944c54",
                            Email = "blake@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "BLAKE@GMAIL.COM",
                            NormalizedUserName = "BLAKE",
                            PasswordHash = "AQAAAAIAAYagAAAAECS5VE/2TH9SrZS+6MB2N4Hb2qdmLRVfH++YyODuLynZqt5tQbNDYDuPSvdirgHVvg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b01fcf94-113d-4b67-aeb5-940da38f7616",
                            TwoFactorEnabled = false,
                            UserName = "blake"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Foodie.Models.Food", b =>
                {
                    b.HasOne("Foodie.Models.UserProfile", "UserProfile")
                        .WithMany("Foods")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("Foodie.Models.Meal", b =>
                {
                    b.HasOne("Foodie.Models.MealTime", "MealTime")
                        .WithMany("Meals")
                        .HasForeignKey("MealTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MealTime");
                });

            modelBuilder.Entity("Foodie.Models.MealTime", b =>
                {
                    b.HasOne("Foodie.Models.Day", "Day")
                        .WithMany("MealTimes")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Foodie.Models.UserProfile", "UserProfile")
                        .WithMany()
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Day");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("Foodie.Models.UserProfile", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("MealFood", b =>
                {
                    b.HasOne("Foodie.Models.Food", null)
                        .WithMany()
                        .HasForeignKey("FoodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Foodie.Models.Meal", null)
                        .WithMany()
                        .HasForeignKey("MealsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Foodie.Models.Day", b =>
                {
                    b.Navigation("MealTimes");
                });

            modelBuilder.Entity("Foodie.Models.MealTime", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("Foodie.Models.UserProfile", b =>
                {
                    b.Navigation("Foods");
                });
#pragma warning restore 612, 618
        }
    }
}
