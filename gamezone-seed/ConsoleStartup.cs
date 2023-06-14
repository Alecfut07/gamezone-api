using System;
using gamezone_api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace gamezone_seed
{
	public class ConsoleStartup
	{
        public ConsoleStartup()
        {

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GamezoneContext>(options =>
            {
                //options.UseMySql(Configuration.GetConnectionString("LearningAnalyticsAPIContext"));
                options.UseSqlServer(Environment.GetEnvironmentVariable("DATABASE_URL"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
    }
}

