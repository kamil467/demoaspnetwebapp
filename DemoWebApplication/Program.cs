
using System.Reflection;
using DemoWebApplication.DTO;
using DemoWebApplication.Filters;
using DemoWebApplication.Middlewares;
using DemoWebApplication.Model;
using DemoWebApplication.Profile;
using DemoWebApplication.Repository;
using DemoWebApplication.Service;
using DemoWebApplication.Utility;
using Microsoft.EntityFrameworkCore;

var region = new Region();

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
builder.Services.AddTransient<IRegionService,RegionService>();

builder.Services.AddScoped<IServiceLogger, ServiceLogger>();


// register automapper service
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<RegionCategoryDTOProfile>();
});

// register problem details
builder.Services.AddProblemDetails();



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

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseMiddleware<CustomHeaderMiddleware>();

// app.UseStatusCodePages(); // to return JSON response for status code errors 404 ,  500 browser based errors
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

// throws exception because of JSON serialization
app.MapGet("/regions-cat", async (FontyDbContext dbContext) =>
{
   
        var regions = await dbContext.Regions
            .Include(r => r.Categories)
            .FirstOrDefaultAsync();
        // mapping to DTO 

        return Results.Ok(regions);
    

});

// validating input using endpoint filter
app.MapGet("/regions-cat-by-code/{code}", async (string code,FontyDbContext dbContext) =>
{

    var regions = await dbContext.Regions
        .Include(r => r.Categories)
        .FirstOrDefaultAsync();
    // mapping to DTO 

    return Results.Ok(regions);


}).AddEndpointFilter(ValidationHelper.ValidateRegionCode);


app.MapControllers();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public delegate string WeatherForecastDelegate();







