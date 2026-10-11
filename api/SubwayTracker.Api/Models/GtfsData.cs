namespace SubwayTracker.Api.Models;

public class GtfsData
{
    public List<GtfsRoute> Routes { get; set; } = new List<GtfsRoute>();
    public List<GtfsStop> Stops { get; set; } = new List<GtfsStop>();
    public List<GtfsTrip> Trips { get; set; } = new List<GtfsTrip>();
    public List<GtfsShapePoint> Shapes { get; set; } = new List<GtfsShapePoint>();

}