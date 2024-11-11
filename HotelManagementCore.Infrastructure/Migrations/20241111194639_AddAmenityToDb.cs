using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagementCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAmenityToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desctiption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenities_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Desctiption", "Name", "VillaId" },
                values: new object[,]
                {
                    { 1, "High-speed internet available throughout the villa.", "Wi-Fi", 1 },
                    { 2, "Private pool with ocean view.", "Pool", 1 },
                    { 3, "Outdoor hot tub for a relaxing experience.", "Hot Tub", 2 },
                    { 4, "Cozy indoor fireplace for chilly mountain nights.", "Fireplace", 2 },
                    { 5, "Spacious balcony with a panoramic city skyline view.", "Balcony", 3 },
                    { 6, "Fully equipped gym available to guests.", "Gym", 3 },
                    { 7, "Direct access to the beach from the villa.", "Beach Access", 4 },
                    { 8, "Outdoor barbecue area for social gatherings.", "Outdoor BBQ", 4 },
                    { 9, "Beautiful greenhouse with exotic plants.", "Greenhouse", 5 },
                    { 10, "Enjoy scenic cycling trails around the countryside.", "Cycling Trails", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_VillaId",
                table: "Amenities",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");
        }
    }
}
