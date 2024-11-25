namespace Flights.Domain.Entities;

public class Route(string origin, string destination, decimal cost)
{
    public int Id { get; private set; }
    public string Origin { get; private set; } = origin;
    public string Destination { get; private set; } = destination;
    public decimal Cost { get; private set; } = cost;
}