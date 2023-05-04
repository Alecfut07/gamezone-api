﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gamezone_api;

#nullable disable

namespace gamezone_api.Migrations
{
    [DbContext(typeof(GamezoneContext))]
    partial class GamezoneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("gamezone_api.Models.Condition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("state");

                    b.HasKey("Id");

                    b.ToTable("conditions", (string)null);
                });

            modelBuilder.Entity("gamezone_api.Models.Edition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("editions", (string)null);
                });

            modelBuilder.Entity("gamezone_api.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("ImageURL")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("release_date");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.ToTable("products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3780),
                            Description = "Nintendo 64 Game",
                            Name = "The Legend of Zelda: Ocarina of Time",
                            ReleaseDate = new DateTime(1998, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3800)
                        },
                        new
                        {
                            Id = 2L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3800),
                            Description = "PlayStation 1 Game",
                            Name = "Tony Hawk's Pro Skater 2",
                            ReleaseDate = new DateTime(2000, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3810)
                        },
                        new
                        {
                            Id = 3L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3810),
                            Description = "PlayStation 3 Game",
                            Name = "Grand Theft Auto 4",
                            ReleaseDate = new DateTime(2008, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3810)
                        },
                        new
                        {
                            Id = 4L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3810),
                            Description = "SEGA Dreamcast Game",
                            Name = "Soul Calibur",
                            ReleaseDate = new DateTime(1999, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3810)
                        },
                        new
                        {
                            Id = 5L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3820),
                            Description = "Nintendo Wii Game",
                            Name = "Super Mario Galaxy",
                            ReleaseDate = new DateTime(2007, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3820)
                        },
                        new
                        {
                            Id = 6L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3820),
                            Description = "Nintendo Wii Game",
                            Name = "Super Mario Galaxy 2",
                            ReleaseDate = new DateTime(2010, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3820)
                        },
                        new
                        {
                            Id = 7L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3830),
                            Description = "Xbox One Game",
                            Name = "Read Dead Redemption 2",
                            ReleaseDate = new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3830)
                        },
                        new
                        {
                            Id = 8L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3830),
                            Description = "Xbox One Game",
                            Name = "Grand Theft Auto 5",
                            ReleaseDate = new DateTime(2014, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3830)
                        },
                        new
                        {
                            Id = 9L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3830),
                            Description = "PC Game",
                            Name = "Disco Elysium: The Final Cut",
                            ReleaseDate = new DateTime(2021, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3830)
                        },
                        new
                        {
                            Id = 10L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3840),
                            Description = "Nintendo Switch Game",
                            Name = "The Legend of Zelda: Breath of the Wild",
                            ReleaseDate = new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3840)
                        },
                        new
                        {
                            Id = 11L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3840),
                            Description = "Nintendo 64 Game",
                            Name = "Perfect Dark",
                            ReleaseDate = new DateTime(2000, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3840)
                        },
                        new
                        {
                            Id = 12L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3850),
                            Description = "Nintendo Gamecube Game",
                            Name = "Metroid Prime",
                            ReleaseDate = new DateTime(2002, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3850)
                        },
                        new
                        {
                            Id = 13L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3850),
                            Description = "Nintendo Switch Game",
                            Name = "Super Mario Odyssey",
                            ReleaseDate = new DateTime(2017, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3850)
                        },
                        new
                        {
                            Id = 14L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3850),
                            Description = "Nintendo Switch Game",
                            Name = "Halo: Combat Evolved",
                            ReleaseDate = new DateTime(2001, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3850)
                        },
                        new
                        {
                            Id = 15L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3860),
                            Description = "SEGA Dreamcast",
                            Name = "NFL 2K1",
                            ReleaseDate = new DateTime(2000, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3860)
                        },
                        new
                        {
                            Id = 16L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3860),
                            Description = "PC Game",
                            Name = "Half-Life 2",
                            ReleaseDate = new DateTime(2004, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3860)
                        },
                        new
                        {
                            Id = 17L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3860),
                            Description = "Xbox 360 Game",
                            Name = "BioSchock",
                            ReleaseDate = new DateTime(2007, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3870)
                        },
                        new
                        {
                            Id = 18L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3870),
                            Description = "Nintendo 64 Game",
                            Name = "GoldenEye 007",
                            ReleaseDate = new DateTime(1997, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3870)
                        },
                        new
                        {
                            Id = 19L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3870),
                            Description = "PlayStation 3 Game",
                            Name = "Uncharted 2: Among Thieves",
                            ReleaseDate = new DateTime(2009, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3870)
                        },
                        new
                        {
                            Id = 20L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3880),
                            Description = "Nintendo Gamecube Game",
                            Name = "Resident Evil 4",
                            ReleaseDate = new DateTime(2005, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3880)
                        },
                        new
                        {
                            Id = 21L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3880),
                            Description = "PlayStation 3 Game",
                            Name = "Batman: Arkham City",
                            ReleaseDate = new DateTime(2011, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3880)
                        },
                        new
                        {
                            Id = 22L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3890),
                            Description = "PlayStation 1 Game",
                            Name = "Tekken 3",
                            ReleaseDate = new DateTime(1998, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3890)
                        },
                        new
                        {
                            Id = 23L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3890),
                            Description = "Xbox Series X Game",
                            Name = "Elden Ring",
                            ReleaseDate = new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3890)
                        },
                        new
                        {
                            Id = 24L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3890),
                            Description = "Xbox 360 Game",
                            Name = "Mass Effect 2",
                            ReleaseDate = new DateTime(2010, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3890)
                        },
                        new
                        {
                            Id = 25L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3900),
                            Description = "Nintendo Gamecube Game",
                            Name = "The Legend of Zelda: Twilight Princess",
                            ReleaseDate = new DateTime(2006, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3900)
                        },
                        new
                        {
                            Id = 26L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3900),
                            Description = "Xbox 360 Game",
                            Name = "The Elder Scrolls 5: Skyrim",
                            ReleaseDate = new DateTime(2011, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3900)
                        },
                        new
                        {
                            Id = 27L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3900),
                            Description = "Nintendo Gamecube Game",
                            Name = "The Legend of Zelda: The Wind Waker",
                            ReleaseDate = new DateTime(2003, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3910)
                        },
                        new
                        {
                            Id = 28L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3910),
                            Description = "PlayStation 1 Game",
                            Name = "Gran Turismo",
                            ReleaseDate = new DateTime(1998, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3910)
                        },
                        new
                        {
                            Id = 29L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3910),
                            Description = "PlayStation 2 Game",
                            Name = "Metal Gear Solid 2: Sons of Liberty",
                            ReleaseDate = new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3910)
                        },
                        new
                        {
                            Id = 30L,
                            CreateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3920),
                            Description = "Nintendo Switch Game",
                            Name = "Persona 5 Royal",
                            ReleaseDate = new DateTime(2022, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 5, 4, 10, 14, 30, 915, DateTimeKind.Local).AddTicks(3920)
                        });
                });

            modelBuilder.Entity("gamezone_api.Models.ProductVariants", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("ConditionId")
                        .HasColumnType("int")
                        .HasColumnName("condition_id");

                    b.Property<int>("EditionId")
                        .HasColumnType("int")
                        .HasColumnName("edition_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    b.HasKey("Id");

                    b.HasIndex("ConditionId");

                    b.HasIndex("EditionId");

                    b.HasIndex("ProductId");

                    b.ToTable("product_variants", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ConditionId = 1,
                            EditionId = 1,
                            Price = 10.20m,
                            ProductId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            ConditionId = 1,
                            EditionId = 2,
                            Price = 15.10m,
                            ProductId = 2L
                        },
                        new
                        {
                            Id = 3L,
                            ConditionId = 1,
                            EditionId = 3,
                            Price = 5.12m,
                            ProductId = 3L
                        },
                        new
                        {
                            Id = 4L,
                            ConditionId = 2,
                            EditionId = 1,
                            Price = 40.22m,
                            ProductId = 4L
                        },
                        new
                        {
                            Id = 5L,
                            ConditionId = 2,
                            EditionId = 2,
                            Price = 32.25m,
                            ProductId = 5L
                        },
                        new
                        {
                            Id = 6L,
                            ConditionId = 2,
                            EditionId = 3,
                            Price = 12.11m,
                            ProductId = 6L
                        },
                        new
                        {
                            Id = 7L,
                            ConditionId = 3,
                            EditionId = 1,
                            Price = 2.02m,
                            ProductId = 7L
                        },
                        new
                        {
                            Id = 8L,
                            ConditionId = 3,
                            EditionId = 2,
                            Price = 11.11m,
                            ProductId = 8L
                        },
                        new
                        {
                            Id = 9L,
                            ConditionId = 3,
                            EditionId = 3,
                            Price = 3.33m,
                            ProductId = 9L
                        },
                        new
                        {
                            Id = 10L,
                            ConditionId = 1,
                            EditionId = 1,
                            Price = 31.31m,
                            ProductId = 10L
                        },
                        new
                        {
                            Id = 11L,
                            ConditionId = 2,
                            EditionId = 1,
                            Price = 60m,
                            ProductId = 11L
                        },
                        new
                        {
                            Id = 12L,
                            ConditionId = 3,
                            EditionId = 1,
                            Price = 21m,
                            ProductId = 12L
                        },
                        new
                        {
                            Id = 13L,
                            ConditionId = 1,
                            EditionId = 2,
                            Price = 10.01m,
                            ProductId = 13L
                        },
                        new
                        {
                            Id = 14L,
                            ConditionId = 2,
                            EditionId = 2,
                            Price = 9m,
                            ProductId = 14L
                        },
                        new
                        {
                            Id = 15L,
                            ConditionId = 3,
                            EditionId = 2,
                            Price = 2m,
                            ProductId = 15L
                        },
                        new
                        {
                            Id = 16L,
                            ConditionId = 1,
                            EditionId = 3,
                            Price = 45.21m,
                            ProductId = 16L
                        },
                        new
                        {
                            Id = 17L,
                            ConditionId = 2,
                            EditionId = 3,
                            Price = 40.04m,
                            ProductId = 17L
                        },
                        new
                        {
                            Id = 18L,
                            ConditionId = 3,
                            EditionId = 3,
                            Price = 12.43m,
                            ProductId = 18L
                        },
                        new
                        {
                            Id = 19L,
                            ConditionId = 1,
                            EditionId = 2,
                            Price = 7.07m,
                            ProductId = 19L
                        },
                        new
                        {
                            Id = 20L,
                            ConditionId = 1,
                            EditionId = 3,
                            Price = 4.31m,
                            ProductId = 20L
                        },
                        new
                        {
                            Id = 21L,
                            ConditionId = 2,
                            EditionId = 1,
                            Price = 6.50m,
                            ProductId = 21L
                        },
                        new
                        {
                            Id = 22L,
                            ConditionId = 2,
                            EditionId = 3,
                            Price = 17.90m,
                            ProductId = 22L
                        },
                        new
                        {
                            Id = 23L,
                            ConditionId = 3,
                            EditionId = 1,
                            Price = 27m,
                            ProductId = 23L
                        },
                        new
                        {
                            Id = 24L,
                            ConditionId = 3,
                            EditionId = 2,
                            Price = 30.08m,
                            ProductId = 24L
                        },
                        new
                        {
                            Id = 25L,
                            ConditionId = 3,
                            EditionId = 2,
                            Price = 41.14m,
                            ProductId = 25L
                        },
                        new
                        {
                            Id = 26L,
                            ConditionId = 3,
                            EditionId = 1,
                            Price = 18.89m,
                            ProductId = 26L
                        },
                        new
                        {
                            Id = 27L,
                            ConditionId = 2,
                            EditionId = 3,
                            Price = 55m,
                            ProductId = 27L
                        },
                        new
                        {
                            Id = 28L,
                            ConditionId = 2,
                            EditionId = 1,
                            Price = 5m,
                            ProductId = 28L
                        },
                        new
                        {
                            Id = 29L,
                            ConditionId = 1,
                            EditionId = 3,
                            Price = 46.72m,
                            ProductId = 29L
                        },
                        new
                        {
                            Id = 30L,
                            ConditionId = 1,
                            EditionId = 2,
                            Price = 60m,
                            ProductId = 30L
                        });
                });

            modelBuilder.Entity("gamezone_api.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("publishers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Nintendo"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sony"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Microsoft"
                        });
                });

            modelBuilder.Entity("gamezone_api.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("encrypted_password");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("gamezone_api.Models.VideoGame", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int")
                        .HasColumnName("publisher_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("PublisherId");

                    b.ToTable("videogames", (string)null);
                });

            modelBuilder.Entity("gamezone_api.Models.ProductVariants", b =>
                {
                    b.HasOne("gamezone_api.Models.Condition", "Condition")
                        .WithMany()
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gamezone_api.Models.Edition", "Edition")
                        .WithMany()
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gamezone_api.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condition");

                    b.Navigation("Edition");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("gamezone_api.Models.VideoGame", b =>
                {
                    b.HasOne("gamezone_api.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gamezone_api.Models.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Publisher");
                });
#pragma warning restore 612, 618
        }
    }
}
