using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeeklyFoodPlanner.Migrations
{
    /// <inheritdoc />
    public partial class newmealtimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d335b155-4c4c-4d5d-967a-8458d0f381c3", "bc818f4f-a8cd-4340-a13c-4ed6bc2e86e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2526fd03-1eef-4247-8cec-06298e5e7563", "28b79d9e-a540-4d6f-b509-460090cd20d9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0b65e640-b0d5-429e-9dd1-bac7c85aa4a1", "69bc4210-7561-40da-b8c3-b0105fbc0b92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "32b5081e-f650-42c2-a678-f928d8737581", "df7599c0-072e-4b81-ad74-3e145587b17c" });
        }
    }
}
