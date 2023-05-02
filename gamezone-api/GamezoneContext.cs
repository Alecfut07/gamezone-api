using System.Reflection.Metadata;
using gamezone_api.Models;
using gamezone_api.SeedData;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api
{
    public class GamezoneContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Condition> Conditions { get; set; }

        public DbSet<Edition> Editions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<VideoGame> VideoGames { get; set; }

        public GamezoneContext(DbContextOptions<GamezoneContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // PRODUCTS
            modelBuilder.Entity<Product>(product =>
            {
                product.ToTable("products");

                product.HasKey(p => p.Id);

                product.HasOne(p => p.Condition);
                
                product.HasOne(p => p.Edition);

                product.Property(p => p.ImageURL).IsRequired(false).HasMaxLength(300);

                product.Property(p => p.Name).IsRequired().HasMaxLength(150);

                product.Property(p => p.Price).IsRequired();

                product.Property(p => p.ReleaseDate).IsRequired(false);

                product.Property(p => p.Description).IsRequired(false);

                product.Property(p => p.CreateDate).IsRequired();

                product.Property(p => p.UpdateDate).IsRequired();

                product.HasData(ProductsSeed.InitData());
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

                user.Property(u => u.Email).IsRequired().HasMaxLength(150);

                user.HasIndex(u => u.Email).IsUnique();

                user.Property(u => u.Password).IsRequired();

                user.Property(u => u.CreateDate).IsRequired();

                user.Property(u => u.UpdateDate).IsRequired();
            });

            // PUBLISHERS
            modelBuilder.Entity<Publisher>(publisher =>
            {
                publisher.ToTable("publishers");

                publisher.HasKey(p => p.Id);

                publisher.Property(p => p.Name).IsRequired().HasMaxLength(30);

                publisher.HasData(PublishersSeed.InitData());
            });

            // VIDEOGAMES
            modelBuilder.Entity<VideoGame>(videogame =>
            {
                videogame.ToTable("videogames");
                videogame.HasKey(v => v.Id);

                videogame.HasOne(v => v.Product).WithOne(p => p.VideoGame).HasForeignKey<VideoGame>();

                videogame.HasOne(v => v.Publisher);
            });
        }
    }
}
