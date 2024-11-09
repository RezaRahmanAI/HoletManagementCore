using HotelManagementCore.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementCore.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Villa>().HasData(

                new Villa
                {
                    Id = 1,
                    Name = "Ocean View Retreat",
                    Description = "A luxurious villa with breathtaking ocean views and modern amenities.",
                    price = 450.00,
                    Sqft = 2500,
                    Occupency = 8,
                    ImgUrl = "https://images.unsplash.com/photo-1502672023488-70e25813eb80",
                    CreatedDate = new DateTime(2023, 3, 15),
                    UpdatedDate = new DateTime(2024, 5, 10)
                },
                new Villa
                {
                    Id = 2,
                    Name = "Mountain Escape Lodge",
                    Description = "A cozy lodge nestled in the mountains, perfect for nature lovers.",
                    price = 300.00,
                    Sqft = 1800,
                    Occupency = 6,
                    ImgUrl = "https://images.unsplash.com/photo-1506748686214-e9df14d4d9d0",
                    CreatedDate = new DateTime(2022, 11, 21),
                    UpdatedDate = new DateTime(2024, 6, 18)
                },
                new Villa
                {
                    Id = 3,
                    Name = "City Center Penthouse",
                    Description = "A spacious penthouse located in the heart of the city with stunning skyline views.",
                    price = 600.00,
                    Sqft = 1500,
                    Occupency = 4,
                    ImgUrl = "https://images.unsplash.com/photo-1600585154340-be6161a56a0c",
                    CreatedDate = new DateTime(2023, 7, 5),
                    UpdatedDate = new DateTime(2024, 8, 12)
                },
                new Villa
                {
                    Id = 4,
                    Name = "Beachfront Bungalow",
                    Description = "A charming bungalow located directly on the beach, ideal for a peaceful getaway.",
                    price = 500.00,
                    Sqft = 2200,
                    Occupency = 5,
                    ImgUrl = "https://images.unsplash.com/photo-1536104968055-4d61aa56f46a",
                    CreatedDate = new DateTime(2023, 2, 18),
                    UpdatedDate = new DateTime(2024, 4, 20)
                },
                new Villa
                {
                    Id = 5,
                    Name = "Countryside Villa",
                    Description = "A beautiful villa in the countryside with vast green landscapes and fresh air.",
                    price = 400.00,
                    Sqft = 2000,
                    Occupency = 7,
                    ImgUrl = "https://images.unsplash.com/photo-1559599239-0c5b2d8d9d31",
                    CreatedDate = new DateTime(2023, 1, 12),
                    UpdatedDate = new DateTime(2024, 3, 30)
                }

               
                );

            modelBuilder.Entity<VillaNumber>().HasData(

                new VillaNumber { VillaNo = 101, VillaId = 1, SpecialDetails = "N/A" },
                new VillaNumber { VillaNo = 102, VillaId = 1, SpecialDetails = "Ocean view" },
                new VillaNumber { VillaNo = 103, VillaId = 1, SpecialDetails = "Close to pool" },
                new VillaNumber { VillaNo = 201, VillaId = 2, SpecialDetails = "Pet-friendly" },
                new VillaNumber { VillaNo = 202, VillaId = 2, SpecialDetails = "Upper level" },
                new VillaNumber { VillaNo = 203, VillaId = 2, SpecialDetails = "Garden view" },
                new VillaNumber { VillaNo = 301, VillaId = 3, SpecialDetails = "Mountain view" },
                new VillaNumber { VillaNo = 302, VillaId = 3, SpecialDetails = "Secluded" },
                new VillaNumber { VillaNo = 303, VillaId = 3, SpecialDetails = "Near spa" }



             );
        }
    }
}
