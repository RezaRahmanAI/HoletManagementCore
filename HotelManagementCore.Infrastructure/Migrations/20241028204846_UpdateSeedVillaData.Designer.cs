﻿// <auto-generated />
using System;
using HotelManagementCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelManagementCore.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241028204846_UpdateSeedVillaData")]
    partial class UpdateSeedVillaData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelManagementCore.Domain.Entities.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupency")
                        .HasColumnType("int");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A luxurious villa with breathtaking ocean views and modern amenities.",
                            ImgUrl = "https://images.unsplash.com/photo-1502672023488-70e25813eb80",
                            Name = "Ocean View Retreat",
                            Occupency = 8,
                            Sqft = 2500,
                            UpdatedDate = new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 450.0
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A cozy lodge nestled in the mountains, perfect for nature lovers.",
                            ImgUrl = "https://images.unsplash.com/photo-1506748686214-e9df14d4d9d0",
                            Name = "Mountain Escape Lodge",
                            Occupency = 6,
                            Sqft = 1800,
                            UpdatedDate = new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 300.0
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A spacious penthouse located in the heart of the city with stunning skyline views.",
                            ImgUrl = "https://images.unsplash.com/photo-1582719478148-d9e4c3660974",
                            Name = "City Center Penthouse",
                            Occupency = 4,
                            Sqft = 1500,
                            UpdatedDate = new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 600.0
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A charming bungalow located directly on the beach, ideal for a peaceful getaway.",
                            ImgUrl = "https://images.unsplash.com/photo-1536104968055-4d61aa56f46a",
                            Name = "Beachfront Bungalow",
                            Occupency = 5,
                            Sqft = 2200,
                            UpdatedDate = new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 500.0
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A beautiful villa in the countryside with vast green landscapes and fresh air.",
                            ImgUrl = "https://images.unsplash.com/photo-1505692794400-7f6a56eee78e",
                            Name = "Countryside Villa",
                            Occupency = 7,
                            Sqft = 2000,
                            UpdatedDate = new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 400.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
