using gamezone_api;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Repositories;
using gamezone_api.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// DISABLING THE AUTOMATIC VALIDATION FROM [ApiController]
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

// SQL SERVER CONNECTION
builder.Services.AddSqlServer<GamezoneContext>(builder.Configuration.GetConnectionString("SQL_Server"));
builder.Services.AddScoped<ProductsMapper>();
builder.Services.AddScoped<ConditionsMapper>();
builder.Services.AddScoped<EditionsMapper>();
builder.Services.AddScoped<ProductsRepository>();
builder.Services.AddScoped<ConditionsRepository>();
builder.Services.AddScoped<EditionsRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IConditionService, ConditionService>();
builder.Services.AddScoped<IEditionService, EditionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

