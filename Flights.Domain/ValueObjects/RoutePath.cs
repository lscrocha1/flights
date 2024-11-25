namespace Flights.Domain.ValueObjects;

public class RoutePath
{
    public string Path { get; }
    public decimal TotalCost { get; }

    public RoutePath(string path, decimal totalCost)
    {
        Path = path;
        TotalCost = totalCost;
    }
}