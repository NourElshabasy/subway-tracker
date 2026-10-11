using CsvHelper;
using System.Collections.Generic;
using System;
using System.IO;
using System.Globalization;
using SubwayTracker.Api.Models;
namespace SubwayTracker.Api.Services;

public class GtfsLoader
{
    public List<T> ReadCsv<T>(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecords<T>().ToList();
    }

    public GtfsData Load(string folderPath)
    {
        var gtfsData = new GtfsData();

        gtfsData.Routes = ReadCsv<GtfsRoute>(Path.Combine(folderPath, "routes.txt"));
        gtfsData.Stops = ReadCsv<GtfsStop>(Path.Combine(folderPath, "stops.txt"));
        gtfsData.Trips = ReadCsv<GtfsTrip>(Path.Combine(folderPath, "trips.txt"));
        gtfsData.Shapes = ReadCsv<GtfsShapePoint>(Path.Combine(folderPath, "shapes.txt"));

        return gtfsData;
    }
}