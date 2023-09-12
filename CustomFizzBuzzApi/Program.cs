using Microsoft.EntityFrameworkCore;
using CustomFizzBuzzApi.Models;
using CustomFizzBuzzApi.Interfaces;
using CustomFizzBuzzApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddScoped<ICustomFizzBuzzService, CustomFizzBuzzService>();

builder.Services.AddControllers();

// Setup Db contexts for logging
// Note: This would normally point to a db host defined in an environment file
builder.Services.AddDbContext<CustomFizzBuzzLoggerContext>(opt =>
    opt.UseInMemoryDatabase("CustomFizzBuzzRequests"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();