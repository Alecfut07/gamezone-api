using gamezone_api;
using gamezone_migration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

DotNetEnv.Env.Load();
Console.WriteLine("Applying migrations");
var webHost = new WebHostBuilder()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .UseStartup<ConsoleStartup>()
    .Build();
using (var context = (GamezoneContext)webHost.Services.GetService(typeof(GamezoneContext)))
{
    context.Database.Migrate();
}
Console.WriteLine("Done");