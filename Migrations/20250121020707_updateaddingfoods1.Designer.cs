﻿// <auto-generated />
using System;
using Foodie.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WeeklyFoodPlanner.Migrations
{
    [DbContext(typeof(FoodieDbContext))]
    [Migration("20250121020707_updateaddingfoods1")]
    partial class updateaddingfoods1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            UserProfileId = 3
                        },
                        new
                        {
                            Id = 2,
                            Description = "Put in boiling water",
                            Name = "Rice",
                            UserProfileId = 3
                        },
                        new
                        {
                            Id = 3,
                            Description = "Put in pan",
                            Name = "Bacon",
                            UserProfileId = 3
                        },
                        new
                        {
                            Id = 4,
                            Description = "Put in pan, season",
                            Name = "Eggs",
                            UserProfileId = 3
                        },
                        new
                        {
                            Id = 5,
                            Description = "Crack eggs, cinnamon, sugar, dip bread and put in pan",
                            Name = "French Toast",
                            UserProfileId = 3
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

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.ToTable("MealTimes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DayId = 1,
                            Name = "Breakfast"
                        },
                        new
                        {
                            Id = 2,
                            DayId = 1,
                            Name = "Lunch"
                        },
                        new
                        {
                            Id = 3,
                            DayId = 1,
                            Name = "Dinner"
                        },
                        new
                        {
                            Id = 4,
                            DayId = 2,
                            Name = "Breakfast"
                        },
                        new
                        {
                            Id = 5,
                            DayId = 2,
                            Name = "Lunch"
                        },
                        new
                        {
                            Id = 6,
                            DayId = 2,
                            Name = "Dinner"
                        },
                        new
                        {
                            Id = 7,
                            DayId = 3,
                            Name = "Breakfast"
                        },
                        new
                        {
                            Id = 8,
                            DayId = 3,
                            Name = "Lunch"
                        },
                        new
                        {
                            Id = 9,
                            DayId = 3,
                            Name = "Dinner"
                        },
                        new
                        {
                            Id = 10,
                            DayId = 4,
                            Name = "Breakfast"
                        },
                        new
                        {
                            Id = 11,
                            DayId = 4,
                            Name = "Lunch"
                        },
                        new
                        {
                            Id = 12,
                            DayId = 4,
                            Name = "Dinner"
                        },
                        new
                        {
                            Id = 13,
                            DayId = 5,
                            Name = "Breakfast"
                        },
                        new
                        {
                            Id = 14,
                            DayId = 5,
                            Name = "Lunch"
                        },
                        new
                        {
                            Id = 15,
                            DayId = 5,
                            Name = "Dinner"
                        },
                        new
                        {
                            Id = 16,
                            DayId = 6,
                            Name = "Breakfast"
                        },
                        new
                        {
                            Id = 17,
                            DayId = 6,
                            Name = "Lunch"
                        },
                        new
                        {
                            Id = 18,
                            DayId = 6,
                            Name = "Dinner"
                        },
                        new
                        {
                            Id = 19,
                            DayId = 7,
                            Name = "Breakfast"
                        },
                        new
                        {
                            Id = 20,
                            DayId = 7,
                            Name = "Lunch"
                        },
                        new
                        {
                            Id = 21,
                            DayId = 7,
                            Name = "Dinner"
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
                            IdentityUserId = "1"
                        },
                        new
                        {
                            Id = 2,
                            IdentityUserId = "2"
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
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3b6f7736-00ef-4dd6-b664-e429b2072160",
                            Email = "testuser1@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "639a0441-d791-4143-97c5-9fda70bcc0a0",
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a3d12ba0-dfd1-4801-8a57-dcf1395da68e",
                            Email = "testuser2@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "eee7f896-18c0-4477-bb7c-ff61f0946290",
                            TwoFactorEnabled = false
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

                    b.Navigation("Day");
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
