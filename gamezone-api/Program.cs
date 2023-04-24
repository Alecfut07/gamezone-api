using System.Text;
using gamezone_api;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Repositories;
using gamezone_api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

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

// SQL SERVER CONNECTION
builder.Services.AddSqlServer<GamezoneContext>(builder.Configuration["ConnectionStrings:SQL_Server"]);

// MAPPERS
builder.Services.AddScoped<ProductsMapper>();
builder.Services.AddScoped<ConditionsMapper>();
builder.Services.AddScoped<EditionsMapper>();
builder.Services.AddScoped<UsersMapper>();

// REPOSITORIES
builder.Services.AddScoped<ProductsRepository>();
builder.Services.AddScoped<ConditionsRepository>();
builder.Services.AddScoped<EditionsRepository>();
builder.Services.AddScoped<AuthRepository>();
builder.Services.AddScoped<UserRepository>();

// SERVICES
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IConditionService, ConditionService>();
builder.Services.AddScoped<IEditionService, EditionService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

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

app.Run();

