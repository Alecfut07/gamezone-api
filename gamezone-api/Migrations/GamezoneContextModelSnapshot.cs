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

                    b.Property<int>("ConditionId")
                        .HasColumnType("int")
                        .HasColumnName("condition_id")
                        .HasAnnotation("Relational:JsonPropertyName", "condition_id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<int>("EditionId")
                        .HasColumnType("int")
                        .HasColumnName("edition_id")
                        .HasAnnotation("Relational:JsonPropertyName", "edition_id");

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

                    b.HasIndex("ConditionId");

                    b.HasIndex("EditionId");

                    b.ToTable("products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ConditionId = 0,
                            CreateDate = new DateTime(2023, 4, 19, 15, 31, 52, 188, DateTimeKind.Local).AddTicks(5650),
                            Description = "PlayStation 5 Console",
                            EditionId = 0,
                            Name = "PS5",
                            Price = 500m,
                            ReleaseDate = new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 4, 19, 15, 31, 52, 188, DateTimeKind.Local).AddTicks(5670)
                        },
                        new
                        {
                            Id = 2L,
                            ConditionId = 0,
                            CreateDate = new DateTime(2023, 4, 19, 15, 31, 52, 188, DateTimeKind.Local).AddTicks(5670),
                            Description = "Nintendo Switch Console",
                            EditionId = 0,
                            Name = "Nintendo Switch",
                            Price = 300m,
                            ReleaseDate = new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateDate = new DateTime(2023, 4, 19, 15, 31, 52, 188, DateTimeKind.Local).AddTicks(5680)
                        });
                });

            modelBuilder.Entity("gamezone_api.Models.Product", b =>
                {
                    b.HasOne("gamezone_api.Models.Condition", "Condition")
                        .WithMany("Products")
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gamezone_api.Models.Edition", "Edition")
                        .WithMany("Products")
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condition");

                    b.Navigation("Edition");
                });

            modelBuilder.Entity("gamezone_api.Models.Condition", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("gamezone_api.Models.Edition", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
