using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedVillaDataImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "https://images.unsplash.com/photo-1600585154340-be6161a56a0c");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgUrl",
                value: "https://images.unsplash.com/photo-1559599239-0c5b2d8d9d31");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "https://images.unsplash.com/photo-1582719478148-d9e4c3660974");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImgUrl",
                value: "https://images.unsplash.com/photo-1505692794400-7f6a56eee78e");
        }
    }
}
