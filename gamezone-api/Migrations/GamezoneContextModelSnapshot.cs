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
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("1ef23f06-626e-4329-afe8-4251c6866293"),
                            CreateDate = new DateTime(2023, 4, 17, 13, 35, 20, 542, DateTimeKind.Local).AddTicks(7080),
                            Description = "PlayStation 5 Console",
                            Name = "PS5",
                            Price = 500m,
                            ReleaseDate = new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 4, 17, 13, 35, 20, 542, DateTimeKind.Local).AddTicks(7120)
                        },
                        new
                        {
                            ProductId = new Guid("396e7720-0071-4d1a-818f-5af2299e18ee"),
                            CreateDate = new DateTime(2023, 4, 17, 13, 35, 20, 542, DateTimeKind.Local).AddTicks(7130),
                            Description = "Nintendo Switch Console",
                            Name = "Nintendo Switch",
                            Price = 300m,
                            ReleaseDate = new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 4, 17, 13, 35, 20, 542, DateTimeKind.Local).AddTicks(7130)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
