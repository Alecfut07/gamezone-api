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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

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
                            CreateDate = new DateTime(2023, 4, 18, 15, 21, 8, 691, DateTimeKind.Local).AddTicks(1490),
                            Description = "PlayStation 5 Console",
                            Name = "PS5",
                            Price = 500m,
                            ReleaseDate = new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 4, 18, 15, 21, 8, 691, DateTimeKind.Local).AddTicks(1540)
                        },
                        new
                        {
                            Id = 2L,
                            CreateDate = new DateTime(2023, 4, 18, 15, 21, 8, 691, DateTimeKind.Local).AddTicks(1550),
                            Description = "Nintendo Switch Console",
                            Name = "Nintendo Switch",
                            Price = 300m,
                            ReleaseDate = new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 4, 18, 15, 21, 8, 691, DateTimeKind.Local).AddTicks(1550)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
