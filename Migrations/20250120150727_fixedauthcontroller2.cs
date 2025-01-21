using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeeklyFoodPlanner.Migrations
{
    /// <inheritdoc />
    public partial class fixedauthcontroller2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7a9deabe-ca45-4d2e-b1d0-4846994bfa38", "b39871d2-f467-45e8-b19d-f16f26576922" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1bbdf1b6-0b4f-41b4-970a-da661e215ed4", "c17e59cc-d0fd-46d1-8a0e-8e992fcefed6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0ededc0d-74dd-4d1f-8036-0e4db0698dd8", "b13bb213-1dfe-4524-b2ab-cd92edd8d5d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3afb520c-77f1-44d2-ad32-ab147d5d8e4c", "0998cd49-732d-43a1-8672-1bf617d7b369" });
        }
    }
}
