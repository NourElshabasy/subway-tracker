using CsvHelper.Configuration.Attributes;
namespace SubwayTracker.Api.Models;

public class GtfsRoute
{
    [Name("route_id")]
    public string RouteId { get; set; } = string.Empty;
    [Name("route_short_name")]
    public string ShortName { get; set; } = string.Empty;
    [Name("route_long_name")]
    public string LongName { get; set; } = string.Empty;
    [Name("route_color")]
    public string Color { get; set; } = string.Empty;
}