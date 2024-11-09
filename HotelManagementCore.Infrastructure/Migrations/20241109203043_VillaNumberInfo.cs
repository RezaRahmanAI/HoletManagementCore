using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VillaNumberInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 101,
                column: "SpecialDetails",
                value: "N/A");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 102,
                column: "SpecialDetails",
                value: "Ocean view");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 103,
                column: "SpecialDetails",
                value: "Close to pool");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 201,
                column: "SpecialDetails",
                value: "Pet-friendly");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 202,
                column: "SpecialDetails",
                value: "Upper level");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 203,
                column: "SpecialDetails",
                value: "Garden view");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 301,
                column: "SpecialDetails",
                value: "Mountain view");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 302,
                column: "SpecialDetails",
                value: "Secluded");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 303,
                column: "SpecialDetails",
                value: "Near spa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 101,
                column: "SpecialDetails",
                value: null);

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 102,
                column: "SpecialDetails",
                value: null);

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 103,
                column: "SpecialDetails",
                value: null);

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 201,
                column: "SpecialDetails",
                value: null);

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 202,
                column: "SpecialDetails",
                value: null);

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 203,
                column: "SpecialDetails",
                value: null);

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 301,
                column: "SpecialDetails",
                value: null);

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 302,
                column: "SpecialDetails",
                value: null);

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 303,
                column: "SpecialDetails",
                value: null);
        }
    }
}
