﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gamezone_api;

#nullable disable

namespace gamezone_api.Migrations
{
    [DbContext(typeof(GamezoneContext))]
    [Migration("20230417231457_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("gamezone_api.Models.Product", b =>
                {
                    b.Property<long?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("ID"));

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

                    b.HasKey("ID");

                    b.ToTable("products", (string)null);

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            CreateDate = new DateTime(2023, 4, 17, 17, 14, 57, 904, DateTimeKind.Local).AddTicks(7230),
                            Description = "PlayStation 5 Console",
                            Name = "PS5",
                            Price = 500m,
                            ReleaseDate = new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 4, 17, 17, 14, 57, 904, DateTimeKind.Local).AddTicks(7270)
                        },
                        new
                        {
                            ID = 2L,
                            CreateDate = new DateTime(2023, 4, 17, 17, 14, 57, 904, DateTimeKind.Local).AddTicks(7280),
                            Description = "Nintendo Switch Console",
                            Name = "Nintendo Switch",
                            Price = 300m,
                            ReleaseDate = new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 4, 17, 17, 14, 57, 904, DateTimeKind.Local).AddTicks(7280)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}