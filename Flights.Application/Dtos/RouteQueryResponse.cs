namespace Flights.Application.Dtos;

public class RouteQueryResponse(string path, decimal totalCost)
{
    public string Path { get; set; } = path;
    public decimal TotalCost { get; set; } = totalCost;
}