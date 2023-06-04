using System.Reflection.Metadata;
using gamezone_api.Models;
using gamezone_api.SeedData;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api
{
    public class GamezoneContext : DbContext
    {
        public DbSet<JwtDenyList> JwtDenyLists { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductVariant> ProductVariants { get; set; }

        public DbSet<CategoryProductVariant> CategoriesProductVariants { get; set; }

        public DbSet<Condition> Conditions { get; set; }

        public DbSet<Edition> Editions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public GamezoneContext(DbContextOptions<GamezoneContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // JWT DENY LIST
            modelBuilder.Entity<JwtDenyList>(jwtDenyList =>
            {
                jwtDenyList.ToTable("jwt_deny_list");

                jwtDenyList.HasIndex(jwtDL => jwtDL.Id);

                jwtDenyList.Property(jwtDL => jwtDL.Jti).IsRequired();

                jwtDenyList.Property(jwtDL => jwtDL.ExpiryDate).IsRequired();
            });

            // CATEGORIES
            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("categories");

                category.HasIndex(c => c.Id);

                category.Property(c => c.Name).IsRequired().HasMaxLength(40);

                category.Property(c => c.Handle).IsRequired().HasMaxLength(40);

                category.Property(c => c.CreateDate).IsRequired();

                category.Property(c => c.UpdateDate).IsRequired();

                category.HasOne(c => c.ParentCategory);
            });

            // PRODUCTS
            modelBuilder.Entity<Product>(product =>
            {
                product.ToTable("products");

                product.HasKey(p => p.Id);

                product.Property(p => p.ImageURL).IsRequired(false).HasMaxLength(300);

                product.Property(p => p.ImageKey).IsRequired(false);

                product.Property(p => p.Name).IsRequired().HasMaxLength(150);

                product.Property(p => p.ReleaseDate).IsRequired(false);

                product.Property(p => p.Description).IsRequired(false);

                product.Property(p => p.CreateDate).IsRequired();

                product.Property(p => p.UpdateDate).IsRequired();

                //product.HasData(ProductsSeed.InitData());
            });

            // PRODUCT VARIANTS
            modelBuilder.Entity<ProductVariant>(productVariants =>
            {
                productVariants.ToTable("product_variants");

                productVariants.HasKey(pv => pv.Id);

                productVariants.HasOne(pv => pv.Product);

                productVariants.HasOne(pv => pv.Condition);

                productVariants.HasOne(pv => pv.Edition);

                productVariants.Property(pv => pv.Price).IsRequired();

                //productVariants.HasData(ProductVariantsSeed.InitData());
            });

            // CATEGORIES_PRODUCT_VARIANTS
            modelBuilder.Entity<CategoryProductVariant>(categoriesProductVariants =>
            {
                categoriesProductVariants.ToTable("categories_product_variants");

                categoriesProductVariants.HasKey(cpv => cpv.Id);

                categoriesProductVariants
                    .HasOne(cpv => cpv.Category)
                    .WithMany(c => c.CategoriesProductVariants)
                    .HasForeignKey(cpv => cpv.CategoryId);

                categoriesProductVariants
                    .HasOne(cpv => cpv.ProductVariant)
                    .WithMany(pv => pv.CategoriesProductVariants)
                    .HasForeignKey(cpv => cpv.ProductVariantId);
            });

            // CONDITIONS
            modelBuilder.Entity<Condition>(condition =>
            {
                condition.ToTable("conditions");

                condition.HasKey(c => c.Id);

                condition.Property(c => c.State).IsRequired().HasMaxLength(30);

                //condition.HasData(conditionsInit);
            });

            // EDITIONS
            modelBuilder.Entity<Edition>(edition =>
            {
                edition.ToTable("editions");

                edition.HasKey(e => e.Id);

                edition.Property(e => e.Type).IsRequired().HasMaxLength(30);
            });

            // USERS
            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("users");

                user.HasKey(u => u.Id);

                user.Property(u => u.FirstName).IsRequired(false).HasMaxLength(50);

                user.Property(u => u.LastName).IsRequired(false).HasMaxLength(50);

                user.Property(u => u.Email).IsRequired().HasMaxLength(150);

                user.HasIndex(u => u.Email).IsUnique();

                user.Property(u => u.Password).IsRequired();

                user.Property(u => u.Phone).IsRequired(false).HasMaxLength(20);

                user.Property(u => u.Birthdate).IsRequired(false);

                user.HasOne(u => u.Address);

                user.Property(u => u.CreateDate).IsRequired();

                user.Property(u => u.UpdateDate).IsRequired();

                user.HasData(UsersSeed.InitData());
            });

            // ADDRESSES
            modelBuilder.Entity<Address>(address =>
            {
                address.ToTable("addresses");

                address.HasKey(a => a.Id);

                address.Property(a => a.Line1).IsRequired().HasMaxLength(50);

                address.Property(a => a.Line2).IsRequired(false).HasMaxLength(50);

                address.Property(a => a.ZipCode).IsRequired().HasMaxLength(8);

                address.Property(a => a.State).IsRequired().HasMaxLength(50);

                address.Property(a => a.City).IsRequired().HasMaxLength(50);

                address.Property(a => a.Country).IsRequired().HasMaxLength(50);

                address.HasData(AddressesSeed.InitData());
            });

            // PUBLISHERS
            modelBuilder.Entity<Publisher>(publisher =>
            {
                publisher.ToTable("publishers");

                publisher.HasKey(p => p.Id);

                publisher.Property(p => p.Name).IsRequired().HasMaxLength(30);

                publisher.HasData(PublishersSeed.InitData());
            });
        }
    }
}
