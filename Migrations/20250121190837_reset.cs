using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WeeklyFoodPlanner.Migrations
{
    /// <inheritdoc />
    public partial class reset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileId",
                table: "MealTimes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3", 0, "d4090319-257d-4f91-99e5-e6cde605e45a", "dale@gmail.com", true, false, null, "DALE@GMAIL.COM", "DALE", "AQAAAAIAAYagAAAAEFMQLFhg4Wg8gsc5yz6AUVXFXmlQjGcBOrmNETBxPV8SbPVRTEMZ4ae0DcpbfyCHTg==", null, false, "77f867df-1827-4144-9214-6866ad32137c", false, "dale" },
                    { "4", 0, "ac21b314-4984-439f-9be3-f782bc8e51d8", "blake@gmail.com", true, false, null, "BLAKE@GMAIL.COM", "BLAKE", "AQAAAAIAAYagAAAAELnQiE30Bdj5s1s8SrxGeu38l/2XVbND8kH8DvXo+I4I2sUb5Ai9aEysVlZ5gz7cdw==", null, false, "81f8117f-49da-4f47-882b-9b9807bc20b4", false, "blake" }
                });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Description", "Name", "UserProfileId" },
                values: new object[,]
                {
                    { 6, "Season and grill", "Steak", 2 },
                    { 7, "Boil and add sauce", "Pasta", 2 },
                    { 8, "Chop and mix vegetables", "Salad", 2 },
                    { 9, "Season and bake", "Fish", 2 },
                    { 10, "Boil ingredients", "Soup", 2 }
                });

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 11,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 12,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 13,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 14,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 15,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 16,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 17,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 18,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 19,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 20,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 21,
                column: "UserProfileId",
                value: 1);

            migrationBuilder.InsertData(
                table: "MealTimes",
                columns: new[] { "Id", "DayId", "Name", "UserProfileId" },
                values: new object[,]
                {
                    { 22, 1, "Breakfast", 2 },
                    { 23, 1, "Lunch", 2 },
                    { 24, 1, "Dinner", 2 },
                    { 25, 2, "Breakfast", 2 },
                    { 26, 2, "Lunch", 2 },
                    { 27, 2, "Dinner", 2 },
                    { 28, 3, "Breakfast", 2 },
                    { 29, 3, "Lunch", 2 },
                    { 30, 3, "Dinner", 2 },
                    { 31, 4, "Breakfast", 2 },
                    { 32, 4, "Lunch", 2 },
                    { 33, 4, "Dinner", 2 },
                    { 34, 5, "Breakfast", 2 },
                    { 35, 5, "Lunch", 2 },
                    { 36, 5, "Dinner", 2 },
                    { 37, 6, "Breakfast", 2 },
                    { 38, 6, "Lunch", 2 },
                    { 39, 6, "Dinner", 2 },
                    { 40, 7, "Breakfast", 2 },
                    { 41, 7, "Lunch", 2 },
                    { 42, 7, "Dinner", 2 }
                });

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "IdentityUserId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "IdentityUserId",
                value: "4");

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "MealTimeId" },
                values: new object[,]
                {
                    { 7, 22 },
                    { 8, 23 },
                    { 9, 24 },
                    { 10, 25 },
                    { 11, 26 },
                    { 12, 27 }
                });

            migrationBuilder.InsertData(
                table: "MealFood",
                columns: new[] { "FoodsId", "MealsId" },
                values: new object[,]
                {
                    { 6, 7 },
                    { 7, 8 },
                    { 8, 9 },
                    { 9, 10 },
                    { 10, 11 },
                    { 6, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealTimes_UserProfileId",
                table: "MealTimes",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealTimes_UserProfiles_UserProfileId",
                table: "MealTimes",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealTimes_UserProfiles_UserProfileId",
                table: "MealTimes");

            migrationBuilder.DropIndex(
                name: "IX_MealTimes_UserProfileId",
                table: "MealTimes");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "MealFood",
                keyColumns: new[] { "FoodsId", "MealsId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "MealFood",
                keyColumns: new[] { "FoodsId", "MealsId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "MealFood",
                keyColumns: new[] { "FoodsId", "MealsId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "MealFood",
                keyColumns: new[] { "FoodsId", "MealsId" },
                keyValues: new object[] { 9, 10 });

            migrationBuilder.DeleteData(
                table: "MealFood",
                keyColumns: new[] { "FoodsId", "MealsId" },
                keyValues: new object[] { 10, 11 });

            migrationBuilder.DeleteData(
                table: "MealFood",
                keyColumns: new[] { "FoodsId", "MealsId" },
                keyValues: new object[] { 6, 12 });

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.AlterColumn<string>(
                name: "UserProfileId",
                table: "MealTimes",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "8e9177c3-e851-42dc-9c5b-1708e31f642a", "testuser1@gmail.com", false, false, null, null, null, null, null, false, "c1d04d9d-01af-4131-a483-6365cb93a564", false, null },
                    { "2", 0, "2c6ef580-45ba-42b0-a6cc-d4a666a29d06", "testuser2@gmail.com", false, false, null, null, null, null, null, false, "28ea6b3c-5eb2-483f-b1ed-db25e3c3e0a0", false, null }
                });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserProfileId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserProfileId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserProfileId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserProfileId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserProfileId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 11,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 12,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 13,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 14,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 15,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 16,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 17,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 18,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 19,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 20,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 21,
                column: "UserProfileId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "IdentityUserId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "IdentityUserId",
                value: "2");
        }
    }
}
