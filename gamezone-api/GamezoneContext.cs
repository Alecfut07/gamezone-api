using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using gamezone_api.Models;
using gamezone_api.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace gamezone_api
{
    public class GamezoneContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Condition> Conditions { get; set; }

        public DbSet<Edition> Editions { get; set; }

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
            List<Product> productsInit = new List<Product>
            {
                new Product() { Id = 1, Name = "PS5", Price = 500, ReleaseDate = new DateTime(2020, 11, 19), Description = "PlayStation 5 Console", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 2, Name = "Nintendo Switch", Price = 300, ReleaseDate = new DateTime(2017, 3, 3), Description = "Nintendo Switch Console", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
            };

            modelBuilder.Entity<Product>(product =>
            {
                product.ToTable("products");

                product.HasKey(p => p.Id);

                product.Property(p => p.Name).IsRequired().HasMaxLength(150);

                product.Property(p => p.Price).IsRequired();

                product.Property(p => p.ReleaseDate).IsRequired(false);

                product.Property(p => p.Description).IsRequired(false);

                product.Property(p => p.CreateDate).IsRequired();

                product.Property(p => p.UpdateDate).IsRequired();

                product.HasData(productsInit);
            });

            // CONDITIONS

            //List<Condition> conditionsInit = new List<Condition>
            //{
            //    new Condition() { Id = 1, State = "NEW" },
            //    new Condition() { Id = 2, State = "PRE_OWNED" },
            //    new Condition() { Id = 3, State = "DIGITAL" },
            //};

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
        }
    }
}
