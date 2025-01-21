using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeeklyFoodPlanner.Migrations
{
    /// <inheritdoc />
    public partial class ConvertUserProfileIdToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Convert UserProfileId from string to integer
            migrationBuilder.Sql("ALTER TABLE \"MealTimes\" ALTER COLUMN \"UserProfileId\" TYPE integer USING \"UserProfileId\"::integer;");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert UserProfileId from integer to string
            migrationBuilder.Sql("ALTER TABLE \"MealTimes\" ALTER COLUMN \"UserProfileId\" TYPE text USING \"UserProfileId\"::text;");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4090319-257d-4f91-99e5-e6cde605e45a", "AQAAAAIAAYagAAAAEFMQLFhg4Wg8gsc5yz6AUVXFXmlQjGcBOrmNETBxPV8SbPVRTEMZ4ae0DcpbfyCHTg==", "77f867df-1827-4144-9214-6866ad32137c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac21b314-4984-439f-9be3-f782bc8e51d8", "AQAAAAIAAYagAAAAELnQiE30Bdj5s1s8SrxGeu38l/2XVbND8kH8DvXo+I4I2sUb5Ai9aEysVlZ5gz7cdw==", "81f8117f-49da-4f47-882b-9b9807bc20b4" });
        }
    }
}
