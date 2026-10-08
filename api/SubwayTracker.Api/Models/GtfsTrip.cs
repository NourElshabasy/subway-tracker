using CsvHelper.Configuration.Attributes;
namespace SubwayTracker.Api.Models;

public class GtfsTrip
{
    [Name("route_id")]
    public string RouteId { get; set; } = string.Empty;

    [Name("trip_id")]
    public string TripId { get; set; } = string.Empty;

    [Name("service_id")]
    public string ServiceId { get; set; } = string.Empty;

    [Name("trip_headsign")]
    public string HeadSign { get; set; } = string.Empty;

    [Name("direction_id")]
    public int DirectionId { get; set; }

    [Name("shape_id")]
    public string ShapeId { get; set; } = string.Empty;
}