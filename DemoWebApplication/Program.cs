
using DemoWebApplication.Repository;
using Microsoft.EntityFrameworkCore;

string textDelegate()
{
    return "Hello World";
}
WeatherForecastDelegate weatherForecastDelegate = textDelegate;

var builder = WebApplication.CreateBuilder(args);

// adding configuration for logging on builder object.
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Logging.AddFilter("Microsoft.Hosting.Lifetime",LogLevel.Information);
builder.Services.AddOpenApi();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FontyDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

// VEBOSE, Info , ERROR, EXCEPTION

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};


app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");
app.MapGet("/regions", async (FontyDbContext dbContext) =>
{
 var regions =  await dbContext.Regions.ToListAsync();
 return regions;
});

app.MapControllers();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public delegate string WeatherForecastDelegate();




