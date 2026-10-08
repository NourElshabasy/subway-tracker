using CsvHelper.Configuration.Attributes;
namespace SubwayTracker.Api.Models;

public class GtfsShapePoint
{
    [Name("shape_id")]
    public string ShapeId { get; set; } = string.Empty;
    [Name("shape_pt_sequence")]
    public int Sequence { get; set; }
    [Name("shape_pt_lat")]
    public double Latitude { get; set; }
    [Name("shape_pt_lon")]
    public double Longitude { get; set; }
}