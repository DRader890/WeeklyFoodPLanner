using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WeeklyFoodPlanner.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMealModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Foods_FoodId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_FoodId",
                table: "Meals");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "Meals");

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
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dfbcd483-8df6-4bee-a549-d48a01ecb1ea", "85e052d4-dcdd-4683-82eb-a46dc838c886" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b67e399d-e311-4bc3-935c-e83fe4274100", "e70d194c-f644-461a-b9b1-9e98692e6525" });

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
                    { 2, 6 }
                });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 2,
                column: "MealTimeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3,
                column: "MealTimeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 4,
                column: "MealTimeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 5,
                column: "MealTimeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 6,
                column: "MealTimeId",
                value: 6);

            migrationBuilder.CreateIndex(
                name: "IX_MealFood_FoodsId",
                table: "MealFood",
                column: "FoodsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealFood");

            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "Meals",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8199033d-0a20-4f21-9b9f-fd0425e8ca63", "2c070461-bcd8-4e54-b5b9-43d1922cfd64" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2b99851a-39ad-45d6-b724-f49a04a65e17", "331a6778-6364-4ed0-9859-2c4c07d3dfa5" });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 1,
                column: "FoodId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FoodId", "MealTimeId" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FoodId", "MealTimeId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FoodId", "MealTimeId" },
                values: new object[] { 4, 3 });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FoodId", "MealTimeId" },
                values: new object[] { 5, 4 });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FoodId", "MealTimeId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "FoodId", "MealTimeId" },
                values: new object[] { 7, 2, 6 });

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
    }
}
