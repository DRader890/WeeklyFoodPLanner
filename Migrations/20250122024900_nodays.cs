using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WeeklyFoodPlanner.Migrations
{
    /// <inheritdoc />
    public partial class nodays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealTimes_Days_DayId",
                table: "MealTimes");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "MealFood");

            migrationBuilder.DropIndex(
                name: "IX_MealTimes_DayId",
                table: "MealTimes");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 6);

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

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "MealTimes");

            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "Meals",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb0f93e0-caa5-44bf-a1ca-e7a2ac60e81d", "AQAAAAIAAYagAAAAEOQx11MJ879QquMaZpKWixC8zUijS1uYAZniTX5KiY1mlMyZmjaFV2rS7K98v+GYEA==", "a9b8e0f0-4c76-4ec7-849a-5597697c1d88" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "183f4fe9-7406-4b26-bb26-e27188e6d42e", "AQAAAAIAAYagAAAAEBfl3bvlvDSkEj9goL41REsBksUaV9Ze70cA4CM628fb72szVJR3cDv/JGxIEjdopw==", "6c50fb33-8766-4682-8489-f2523139831f" });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_FoodId",
                table: "Meals",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Foods_FoodId",
                table: "Meals",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Foods_FoodId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_FoodId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "Meals");

            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "MealTimes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealFood",
                columns: table => new
                {
                    MealsId = table.Column<int>(type: "integer", nullable: false),
                    FoodsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealFood", x => new { x.MealsId, x.FoodsId });
                    table.ForeignKey(
                        name: "FK_MealFood_Foods_FoodsId",
                        column: x => x.FoodsId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealFood_Meals_MealsId",
                        column: x => x.MealsId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64de1683-b6ff-46ba-a326-09eb33268f54", "AQAAAAIAAYagAAAAEL8E5LSdM7gSoWCUMlPiwkJRsYo8r3VyShqY2GyeT1AQ8N77D5k/y/JK9gaTnxkofw==", "731091c6-4df1-4c9e-8d22-3e343b215f2a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2203f113-e6d4-491b-9d88-fa5fdd37385e", "AQAAAAIAAYagAAAAEHEKOGBPPOcAnrsHxZ/iNrknR9BvpDBEaKGav1x5F1lNyQJ+sDymZkhsaFGPzwzEAA==", "37f72a5d-86f7-4d5e-ba89-455e6d1e7703" });

            migrationBuilder.InsertData(
                table: "Days",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sunday" },
                    { 2, "Monday" },
                    { 3, "Tuesday" },
                    { 4, "Wednesday" },
                    { 5, "Thursday" },
                    { 6, "Friday" },
                    { 7, "Saturday" }
                });

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DayId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DayId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DayId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DayId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DayId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 6,
                column: "DayId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 7,
                column: "DayId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 8,
                column: "DayId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 9,
                column: "DayId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 10,
                column: "DayId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 11,
                column: "DayId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 12,
                column: "DayId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 13,
                column: "DayId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 14,
                column: "DayId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 15,
                column: "DayId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 16,
                column: "DayId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 17,
                column: "DayId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 18,
                column: "DayId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 19,
                column: "DayId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 20,
                column: "DayId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 21,
                column: "DayId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 22,
                column: "DayId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 23,
                column: "DayId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 24,
                column: "DayId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 25,
                column: "DayId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 26,
                column: "DayId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 27,
                column: "DayId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 28,
                column: "DayId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 29,
                column: "DayId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 30,
                column: "DayId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 31,
                column: "DayId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 32,
                column: "DayId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 33,
                column: "DayId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 34,
                column: "DayId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 35,
                column: "DayId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 36,
                column: "DayId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 37,
                column: "DayId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 38,
                column: "DayId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 39,
                column: "DayId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 40,
                column: "DayId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 41,
                column: "DayId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "MealTimes",
                keyColumn: "Id",
                keyValue: 42,
                column: "DayId",
                value: 7);

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "MealTimeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
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
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 6, 7 },
                    { 7, 8 },
                    { 8, 9 },
                    { 9, 10 },
                    { 10, 11 },
                    { 6, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealTimes_DayId",
                table: "MealTimes",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_MealFood_FoodsId",
                table: "MealFood",
                column: "FoodsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealTimes_Days_DayId",
                table: "MealTimes",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
