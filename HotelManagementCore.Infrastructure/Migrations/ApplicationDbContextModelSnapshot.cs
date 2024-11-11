﻿// <auto-generated />
using System;
using HotelManagementCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelManagementCore.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelManagementCore.Domain.Entities.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Desctiption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VillaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VillaId");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Desctiption = "High-speed internet available throughout the villa.",
                            Name = "Wi-Fi",
                            VillaId = 1
                        },
                        new
                        {
                            Id = 2,
                            Desctiption = "Private pool with ocean view.",
                            Name = "Pool",
                            VillaId = 1
                        },
                        new
                        {
                            Id = 3,
                            Desctiption = "Outdoor hot tub for a relaxing experience.",
                            Name = "Hot Tub",
                            VillaId = 2
                        },
                        new
                        {
                            Id = 4,
                            Desctiption = "Cozy indoor fireplace for chilly mountain nights.",
                            Name = "Fireplace",
                            VillaId = 2
                        },
                        new
                        {
                            Id = 5,
                            Desctiption = "Spacious balcony with a panoramic city skyline view.",
                            Name = "Balcony",
                            VillaId = 3
                        },
                        new
                        {
                            Id = 6,
                            Desctiption = "Fully equipped gym available to guests.",
                            Name = "Gym",
                            VillaId = 3
                        },
                        new
                        {
                            Id = 7,
                            Desctiption = "Direct access to the beach from the villa.",
                            Name = "Beach Access",
                            VillaId = 4
                        },
                        new
                        {
                            Id = 8,
                            Desctiption = "Outdoor barbecue area for social gatherings.",
                            Name = "Outdoor BBQ",
                            VillaId = 4
                        },
                        new
                        {
                            Id = 9,
                            Desctiption = "Beautiful greenhouse with exotic plants.",
                            Name = "Greenhouse",
                            VillaId = 5
                        },
                        new
                        {
                            Id = 10,
                            Desctiption = "Enjoy scenic cycling trails around the countryside.",
                            Name = "Cycling Trails",
                            VillaId = 5
                        });
                });

            modelBuilder.Entity("HotelManagementCore.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("applicationUsers");
                });

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
                            ImgUrl = "https://images.unsplash.com/photo-1600585154340-be6161a56a0c",
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
                            ImgUrl = "https://images.unsplash.com/photo-1559599239-0c5b2d8d9d31",
                            Name = "Countryside Villa",
                            Occupency = 7,
                            Sqft = 2000,
                            UpdatedDate = new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 400.0
                        });
                });

            modelBuilder.Entity("HotelManagementCore.Domain.Entities.VillaNumber", b =>
                {
                    b.Property<int>("VillaNo")
                        .HasColumnType("int");

                    b.Property<string>("SpecialDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VillaId")
                        .HasColumnType("int");

                    b.HasKey("VillaNo");

                    b.HasIndex("VillaId");

                    b.ToTable("VillaNumbers");

                    b.HasData(
                        new
                        {
                            VillaNo = 101,
                            SpecialDetails = "N/A",
                            VillaId = 1
                        },
                        new
                        {
                            VillaNo = 102,
                            SpecialDetails = "Ocean view",
                            VillaId = 1
                        },
                        new
                        {
                            VillaNo = 103,
                            SpecialDetails = "Close to pool",
                            VillaId = 1
                        },
                        new
                        {
                            VillaNo = 201,
                            SpecialDetails = "Pet-friendly",
                            VillaId = 2
                        },
                        new
                        {
                            VillaNo = 202,
                            SpecialDetails = "Upper level",
                            VillaId = 2
                        },
                        new
                        {
                            VillaNo = 203,
                            SpecialDetails = "Garden view",
                            VillaId = 2
                        },
                        new
                        {
                            VillaNo = 301,
                            SpecialDetails = "Mountain view",
                            VillaId = 3
                        },
                        new
                        {
                            VillaNo = 302,
                            SpecialDetails = "Secluded",
                            VillaId = 3
                        },
                        new
                        {
                            VillaNo = 303,
                            SpecialDetails = "Near spa",
                            VillaId = 3
                        });
                });

            modelBuilder.Entity("HotelManagementCore.Domain.Entities.Amenity", b =>
                {
                    b.HasOne("HotelManagementCore.Domain.Entities.Villa", "Villa")
                        .WithMany()
                        .HasForeignKey("VillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Villa");
                });

            modelBuilder.Entity("HotelManagementCore.Domain.Entities.VillaNumber", b =>
                {
                    b.HasOne("HotelManagementCore.Domain.Entities.Villa", "Villa")
                        .WithMany()
                        .HasForeignKey("VillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Villa");
                });
#pragma warning restore 612, 618
        }
    }
}
