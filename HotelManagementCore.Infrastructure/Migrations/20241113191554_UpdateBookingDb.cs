using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookingDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StripePaymentIntentId2",
                table: "Bookings",
                newName: "StripePaymentIntentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StripePaymentIntentId",
                table: "Bookings",
                newName: "StripePaymentIntentId2");
        }
    }
}
