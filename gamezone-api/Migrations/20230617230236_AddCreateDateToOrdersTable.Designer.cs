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
    [Migration("20230617230236_AddCreateDateToOrdersTable")]
    partial class AddCreateDateToOrdersTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("gamezone_api.Models.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("country");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("line_1");

                    b.Property<string>("Line2")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("line_2");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("state");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("zip_code");

                    b.HasKey("Id");

                    b.ToTable("addresses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            City = "Denver",
                            Country = "United States",
                            Line1 = "7700 S Broadway, Littleton",
                            Line2 = "",
                            State = "CO",
                            ZipCode = "80122"
                        },
                        new
                        {
                            Id = 2L,
                            City = "Denver",
                            Country = "United States",
                            Line1 = "5460 S Broadway, Englewood",
                            Line2 = "",
                            State = "CO",
                            ZipCode = "80113"
                        },
                        new
                        {
                            Id = 3L,
                            City = "San Diego",
                            Country = "United States",
                            Line1 = "435 H St, Chula Vista",
                            Line2 = "",
                            State = "CA",
                            ZipCode = "91910"
                        },
                        new
                        {
                            Id = 4L,
                            City = "San Diego",
                            Country = "United States",
                            Line1 = "500 Hotel Cir N, San Diego",
                            Line2 = "Room 10",
                            State = "CA",
                            ZipCode = "92108"
                        },
                        new
                        {
                            Id = 5L,
                            City = "San Diego",
                            Country = "United States",
                            Line1 = "5998 Alcala Park Way, San Diego",
                            Line2 = "",
                            State = "CA",
                            ZipCode = "92110"
                        });
                });

            modelBuilder.Entity("gamezone_api.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_date");

                    b.Property<string>("Handle")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("handle");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("name");

                    b.Property<long?>("ParentCategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("parent_category_id");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("gamezone_api.Models.CategoryProductVariant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("category_id");

                    b.Property<long>("ProductVariantId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_variant_id");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductVariantId");

                    b.ToTable("categories_product_variants", (string)null);
                });

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

            modelBuilder.Entity("gamezone_api.Models.JwtDenyList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("expiry_date");

                    b.Property<string>("Jti")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("jti");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("jwt_deny_list", (string)null);
                });

            modelBuilder.Entity("gamezone_api.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("email");

                    b.Property<decimal>("Grandtotal")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("grandtotal");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("subtotal");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("tax");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("gamezone_api.Models.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("order_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("subtotal");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("order_details", (string)null);
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

                    b.Property<string>("ImageKey")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image_key");

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
                });

            modelBuilder.Entity("gamezone_api.Models.ProductVariant", b =>
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

                    b.Property<long?>("AddressId")
                        .HasColumnType("bigint")
                        .HasColumnName("address_id");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthday");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit")
                        .HasColumnName("is_admin");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("encrypted_password");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("phone");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("update_date");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("gamezone_api.Models.Category", b =>
                {
                    b.HasOne("gamezone_api.Models.Category", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("gamezone_api.Models.CategoryProductVariant", b =>
                {
                    b.HasOne("gamezone_api.Models.Category", "Category")
                        .WithMany("CategoriesProductVariants")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gamezone_api.Models.ProductVariant", "ProductVariant")
                        .WithMany("CategoriesProductVariants")
                        .HasForeignKey("ProductVariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("ProductVariant");
                });

            modelBuilder.Entity("gamezone_api.Models.Order", b =>
                {
                    b.HasOne("gamezone_api.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("gamezone_api.Models.OrderDetail", b =>
                {
                    b.HasOne("gamezone_api.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gamezone_api.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("gamezone_api.Models.ProductVariant", b =>
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
                        .WithMany("ProductVariants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condition");

                    b.Navigation("Edition");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("gamezone_api.Models.User", b =>
                {
                    b.HasOne("gamezone_api.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("gamezone_api.Models.Category", b =>
                {
                    b.Navigation("CategoriesProductVariants");
                });

            modelBuilder.Entity("gamezone_api.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("gamezone_api.Models.Product", b =>
                {
                    b.Navigation("ProductVariants");
                });

            modelBuilder.Entity("gamezone_api.Models.ProductVariant", b =>
                {
                    b.Navigation("CategoriesProductVariants");
                });

            modelBuilder.Entity("gamezone_api.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
