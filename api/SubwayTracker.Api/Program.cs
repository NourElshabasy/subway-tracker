using SubwayTracker.Api.Models;
using SubwayTracker.Api.Services;

var builder = WebApplication.CreateBuilder(args);

var gtfsPath = builder.Configuration["GtfsPath"];
if (string.IsNullOrWhiteSpace(gtfsPath))
{
    throw new InvalidOperationException(
        "Required configuration value 'GtfsPath' is missing or empty. Set it in appsettings.json or another configuration source.");
}

builder.Services.AddOpenApi();

var fullGtfsPath = Path.Combine(builder.Environment.ContentRootPath, gtfsPath);
var gtfsData = new GtfsLoader().Load(fullGtfsPath);
builder.Services.AddSingleton(gtfsData);

var app = builder.Build();

app.Logger.LogInformation(
    "GTFS loaded: {Routes} routes, {Stops} stops, {Trips} trips, {Shapes} shape points",
    gtfsData.Routes.Count, gtfsData.Stops.Count, gtfsData.Trips.Count, gtfsData.Shapes.Count);

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
    var forecast =  Enumerable.Range(1, 5).Select(index =>
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

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
