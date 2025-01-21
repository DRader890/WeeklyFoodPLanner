using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeeklyFoodPlanner.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserProfileIdType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "ALTER TABLE \"MealTimes\" ALTER COLUMN \"UserProfileId\" TYPE integer USING \"UserProfileId\"::integer;"
            );

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02dcf56c-0330-460e-8921-4bd59e60d828", "AQAAAAIAAYagAAAAEK+LF4QP3fozydZw4S+7r+Go47Me5yEKVAqpRjhBfdLJCXsUfON806/p+FhlUJlW/A==", "89b98e12-461a-4e6b-9b3a-c04e9d341ff8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dc34345-73a4-469a-b8e0-80f923b56dbf", "AQAAAAIAAYagAAAAEA3imwWiEGqH9b6uQmI4W2WjgCVA/IaKkFA/tKm06vNCzRxAGTU/qxf8t0H2G/7Kwg==", "69e4c5ce-0c83-4f67-a72b-6440d17bacf1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "ALTER TABLE \"MealTimes\" ALTER COLUMN \"UserProfileId\" TYPE text USING \"UserProfileId\"::text;"
            );

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ef18521-bf85-41e2-8788-52be78ab02f5", "AQAAAAIAAYagAAAAEKHrE0BlxWkFjoAgnkHyqBR254yfAVGN6EmgY6HY5p7jIZkbcUq38ajIo0ZtH79n3Q==", "791a3c07-1679-4553-abfc-6aee0f0df33e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "884a6f5f-0c36-4b60-9b05-06a1c4ad8d0c", "AQAAAAIAAYagAAAAEBAasEs450RN4oOwjSaUgPAYStfjCwWo7nN5g/EJQqQG0OGE/rVWFyXpuIqSf/tC3w==", "7b7dbcc0-24ea-4875-bd14-78ca170a3611" });
        }
    }
}
