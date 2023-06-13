using System.Text;
using gamezone_api;
using gamezone_api.Application;
using gamezone_api.Controllers;
using gamezone_api.Helpers;
using gamezone_api.Mappers;
using gamezone_api.Middlewares;
using gamezone_api.Models;
using gamezone_api.Repositories;
using gamezone_api.SeedData;
using gamezone_api.Services;
using gamezone_api.Services.Stripe;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SendGrid.Extensions.DependencyInjection;
using SendGrid.Helpers.Mail;
using StackExchange.Redis;
using Stripe;
using ProductsService = gamezone_api.Services.ProductsService;


DotNetEnv.Env.Load();
DotNetEnv.Env.TraversePath().Load();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
        options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          //policy.WithOrigins("http://localhost:3000")
                          policy.WithOrigins("http://localhost", "http://localhost:3000", "http://web", "http://web:3000", "http://137.184.131.233")
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              //.AllowAnyOrigin()
                              .AllowCredentials()
                              .WithExposedHeaders("Authorization", "X-Pagination");
                      });
});

// DISABLING THE AUTOMATIC VALIDATION FROM [ApiController]
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// JWT AUTHENTICATION SCHEME
builder.Services
    .AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ClockSkew = TimeSpan.Zero,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            //ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            //ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = Environment.GetEnvironmentVariable("JWT_VALID_ISSUER"),
            ValidAudience = Environment.GetEnvironmentVariable("JWT_VALID_AUDIENCE"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET"))),
        };
    });

// REDIS SERVER CONNECTION
//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:Redis");
//});

// REDIS SERVER CONNECTION
builder.Services.AddScoped<IDatabase>((serviceProvider) =>
{
    ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(Environment.GetEnvironmentVariable("REDIS_URL"));
    return connection.GetDatabase();
});

builder.Services.AddResponseCaching();
builder.Services.AddDistributedMemoryCache();

// SQL SERVER CONNECTION
builder.Services.AddSqlServer<GamezoneContext>(Environment.GetEnvironmentVariable("DATABASE_URL"));

// MIDDLEWARES
//builder.Services.AddTransient<TokenManagerMiddleware>();

// MAPPERS
builder.Services.AddScoped<ProductsMapper>();
builder.Services.AddScoped<ConditionsMapper>();
builder.Services.AddScoped<EditionsMapper>();
builder.Services.AddScoped<UsersMapper>();
builder.Services.AddScoped<PublishersMapper>();
builder.Services.AddScoped<CartsMapper>();
builder.Services.AddScoped<CategoriesMapper>();

// REPOSITORIES
builder.Services.AddScoped<TokenManagerRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
//builder.Services.AddScoped<ProductVariantsRepository>();
builder.Services.AddScoped<ConditionsRepository>();
builder.Services.AddScoped<EditionsRepository>();
builder.Services.AddScoped<AuthRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<PublishersRepository>();
builder.Services.AddScoped<CartsRepository>();
builder.Services.AddScoped<CategoriesRepository>();

// SERVICES
builder.Services.AddScoped<ILogger>((serviceProvider) =>
{
    var loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder
    .SetMinimumLevel(LogLevel.Trace)
    .AddConsole());

    return loggerFactory.CreateLogger<ILogger>();
});

builder.Services.AddScoped<IProductService, ProductsService>();
//builder.Services.AddScoped<IProductVariantService, ProductVariantService>();
builder.Services.AddScoped<IConditionService, ConditionsService>();
builder.Services.AddScoped<IEditionService, EditionsService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UsersService>();
builder.Services.AddScoped<IPublisherService, PublishersService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ICartsService, CartsService>();
builder.Services.AddScoped<ICategoryService, CategoriesService>();
builder.Services.AddScoped<ITokenManager, TokenManagerService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// STRIPE CONNECTION
StripeConfiguration.ApiKey = Environment.GetEnvironmentVariable("STRIPE_SECRET");
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ChargeService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<IStripeAppService, StripeAppService>();

// SENDGRID
builder.Services.AddSendGrid(option =>
{
    option.ApiKey = Environment.GetEnvironmentVariable("SENDGRID_SECRET");
});
//builder.Services.AddScoped<IEmailSenderService, EmailSenderController>();
//builder.Services.AddTransient<IEmailSenderService, EmailSenderController>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
    });

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
});

// SEEDDER CONFIGURATION
builder.Services.AddScoped<UsersSeed>();

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    SeedData(app);
}

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<UsersSeed>();
        service.Seed();
    }
}

app.UseHttpLogging();

app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapGet("/info/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
        string.Join("\n", endpointSources.SelectMany(source => source.Endpoints)));
}

//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

if (!Directory.Exists("Resources"))
{
    // Create the directory
    DirectoryInfo di = Directory.CreateDirectory("Resources");
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Resources")),
    RequestPath = "/public"
});

app.UseMiddleware<TokenManagerMiddleware>();

app.UseCors(MyAllowSpecificOrigins);

app.Run();

