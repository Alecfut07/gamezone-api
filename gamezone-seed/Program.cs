using gamezone_api;
using gamezone_seed.SeedData;
using gamezone_seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using gamezone_seed.DeleteSeedData;
using gamezone_api.Models;
using SendGrid.Helpers.Mail;

DotNetEnv.Env.Load();
Console.WriteLine("Applying seeds");

var webHost = new WebHostBuilder()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .UseStartup<ConsoleStartup>()
    .Build();

using (var context = (GamezoneContext)webHost.Services.GetService(typeof(GamezoneContext)))
{
    Console.WriteLine("connection established");
    if (!context.Users.Any())
    {
        context.Users.AddRange(UsersSeed.InitData());
        context.SaveChanges();
        Console.WriteLine("SUCCESS: Users data added into users table.");
    }

    if (!context.Categories.Any())
    {
        context.Categories.AddRange(CategoriesSeed.InitData());
        context.SaveChanges();
        Console.WriteLine("SUCCESS: Categories data added into categories table.");

        context.Categories.AddRange(new SubCategoriesSeed(context).InitData());
        context.SaveChanges();
        Console.WriteLine("SUCCESS: Subcategories data added into categories table.");
    }

    if (!context.Products.Any())
    {
        context.Products.AddRange(ProductsSeed.InitData());
        context.SaveChanges();
        Console.WriteLine("SUCCESS: Products data added into products table.");
    }

    if (!context.ProductVariants.Any())
    {
        context.ProductVariants.AddRange(new ProductVariantsSeed(context).InitData());
        context.SaveChanges();
        Console.WriteLine("SUCCESS: Product variants data added into product_variants table."); ;
    }

    if (!context.CategoriesProductVariants.Any())
    {
        context.CategoriesProductVariants.AddRange(new CategoriesProductVariantsSeed(context).InitData());
        context.SaveChanges();
        Console.WriteLine("SUCCESS: Categories product variants data added into categories_product_variants table.");
    }
}

Console.WriteLine("Seed done...");
