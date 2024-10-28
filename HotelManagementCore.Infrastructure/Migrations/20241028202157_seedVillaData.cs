using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagementCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedVillaData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "CreatedDate", "Description", "ImgUrl", "Name", "Occupency", "Sqft", "UpdatedDate", "price" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "A luxurious villa with breathtaking ocean views and modern amenities.", "https://example.com/images/ocean_view_retreat.jpg", "Ocean View Retreat", 8, 2500, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 450.0 },
                    { 2, new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "A cozy lodge nestled in the mountains, perfect for nature lovers.", "https://example.com/images/mountain_escape_lodge.jpg", "Mountain Escape Lodge", 6, 1800, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 300.0 },
                    { 3, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "A spacious penthouse located in the heart of the city with stunning skyline views.", "https://example.com/images/city_center_penthouse.jpg", "City Center Penthouse", 4, 1500, new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 600.0 },
                    { 4, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "A charming bungalow located directly on the beach, ideal for a peaceful getaway.", "https://example.com/images/beachfront_bungalow.jpg", "Beachfront Bungalow", 5, 2200, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0 },
                    { 5, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "A beautiful villa in the countryside with vast green landscapes and fresh air.", "https://example.com/images/countryside_villa.jpg", "Countryside Villa", 7, 2000, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 400.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
