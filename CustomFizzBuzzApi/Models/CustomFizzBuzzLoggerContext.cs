using Microsoft.EntityFrameworkCore;

namespace CustomFizzBuzzApi.Models;

public class CustomFizzBuzzLoggerContext : DbContext
{
    public CustomFizzBuzzLoggerContext(DbContextOptions<CustomFizzBuzzLoggerContext> options)
        : base(options)
    {
    }

    public DbSet<CustomFizzBuzzRequestModel> CustomFizzBuzzRequestItems { get; set; } = null!;
    public DbSet<CustomFizzBuzzResponseModel> CustomFizzBuzzResponseItems { get; set; } = null!;
}