using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using gamezone_api.Models;

namespace gamezone_api
{
    public class gamezoneContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public gamezoneContext(DbContextOptions<gamezoneContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //List<Product> productsInit = new List<Product>
            //{
            //    new Product() { ProductId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), Name = "PS5", Price = 20 },
            //    new Product() { ProductId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), Name = "Nintendo Switch", Price = 50 }
            //};

            //modelBuilder.Entity<Product>(product =>
            //{
            //    product.ToTable("Product");
            //    product.HasKey(p => p.ProductId);

            //    product.Property(p => p.Name).IsRequired().HasMaxLength(150);

            //    product.Property(p => p.Descripcion).IsRequired(false);

            //    product.Property(p => p.Price);
            //    product.HasData(productsInit);
            //});
        }
    }
}
