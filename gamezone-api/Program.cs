using System.Text;
using gamezone_api;
using gamezone_api.Helpers;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Repositories;
using gamezone_api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
        options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          //policy.WithOrigins("http://localhost:3000");
                          policy.AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowAnyOrigin()
                              .WithExposedHeaders("Authorization");
                      });
});

// Add services to the container.

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
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
        };
    });

// REDIS SERVER CONNECTION
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:Redis");
});

// SQL SERVER CONNECTION
builder.Services.AddSqlServer<GamezoneContext>(builder.Configuration["DatabaseSettings:SQL_Server"]);

// MAPPERS
builder.Services.AddScoped<ProductsMapper>();
builder.Services.AddScoped<ConditionsMapper>();
builder.Services.AddScoped<EditionsMapper>();
builder.Services.AddScoped<UsersMapper>();
builder.Services.AddScoped<PublishersMapper>();

// REPOSITORIES
builder.Services.AddScoped<ProductsRepository>();
//builder.Services.AddScoped<ProductVariantsRepository>();
builder.Services.AddScoped<ConditionsRepository>();
builder.Services.AddScoped<EditionsRepository>();
builder.Services.AddScoped<AuthRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<PublishersRepository>();

// SERVICES
builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IProductVariantService, ProductVariantService>();
builder.Services.AddScoped<IConditionService, ConditionService>();
builder.Services.AddScoped<IEditionService, EditionService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
    });
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
});

var app = builder.Build();

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

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Resources")),
    RequestPath = "/public"
});

app.UseCors(MyAllowSpecificOrigins);

app.Run();

