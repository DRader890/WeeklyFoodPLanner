using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeeklyFoodPlanner.Migrations
{
    /// <inheritdoc />
    public partial class updateaddingfoods1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3b6f7736-00ef-4dd6-b664-e429b2072160", "639a0441-d791-4143-97c5-9fda70bcc0a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a3d12ba0-dfd1-4801-8a57-dcf1395da68e", "eee7f896-18c0-4477-bb7c-ff61f0946290" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "974c1e5b-b033-4121-bf8a-105a7390122f", "82bb32e5-a559-44f4-a336-51aa8526dab4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "084bc7d0-f979-418c-8437-3274a35c90b1", "ffe0dff9-eb38-405a-a6bb-4cd7b6ababbf" });
        }
    }
}
