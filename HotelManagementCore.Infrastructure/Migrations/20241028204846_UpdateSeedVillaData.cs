using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedVillaData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "https://images.unsplash.com/photo-1502672023488-70e25813eb80");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgUrl",
                value: "https://images.unsplash.com/photo-1506748686214-e9df14d4d9d0");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "https://images.unsplash.com/photo-1582719478148-d9e4c3660974");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgUrl",
                value: "https://images.unsplash.com/photo-1536104968055-4d61aa56f46a");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgUrl",
                value: "https://images.unsplash.com/photo-1505692794400-7f6a56eee78e");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "https://example.com/images/ocean_view_retreat.jpg");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgUrl",
                value: "https://example.com/images/mountain_escape_lodge.jpg");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "https://example.com/images/city_center_penthouse.jpg");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImgUrl",
                value: "https://example.com/images/beachfront_bungalow.jpg");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgUrl",
                value: "https://example.com/images/countryside_villa.jpg");
        }
    }
}
