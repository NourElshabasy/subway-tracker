using CsvHelper.Configuration.Attributes;
namespace SubwayTracker.Api.Models;

public class GtfsStop
{
    [Name("stop_id")]
    public string StopId { get; set; } = string.Empty;

    [Name("stop_name")]
    public string Name { get; set; } = string.Empty;

    [Name("stop_lat")]
    public double Latitude { get; set; }

    [Name("stop_lon")]
    public double Longitude { get; set; }

    [Name("location_type")]
    public int? LocationType { get; set; }

    [Name("parent_station")]
    public string? ParentStation { get; set; }
}