using Flights.Domain.Entities;
using Flights.Domain.Interfaces;
using Flights.Domain.ValueObjects;

namespace Flights.Domain.Services;

public class RouteFinderService(IRouteRepository routeRepository)
{
    private readonly HashSet<string> _visited = [];
    private readonly List<string> _currentPath = [];
    
    private List<string> _bestPath = [];
    private decimal _bestCost = decimal.MaxValue;

    public async Task<RoutePath> FindBestRoute(string origin, string destination)
    {
        var routes = await routeRepository.GetAllAsync();
        
        if (string.IsNullOrWhiteSpace(origin) || string.IsNullOrWhiteSpace(destination))
        {
            throw new ArgumentException("Origin and destination cannot be empty.");
        }

        ExploreRoutes(routes, origin, destination, 0);

        if (_bestPath.Count == 0)
        {
            throw new InvalidOperationException($"No route found from {origin} to {destination}.");
        }

        return new RoutePath(string.Join(" - ", _bestPath), _bestCost);
    }

    private void ExploreRoutes(List<Route> routes, string current, string destination, decimal currentCost)
    {
        _visited.Add(current);
        _currentPath.Add(current);

        if (current == destination)
        {
            if (currentCost < _bestCost)
            {
                _bestCost = currentCost;
                _bestPath = [.._currentPath];
            }
        }
        else
        {
            foreach (var route in routes.Where(r => r.Origin == current && !_visited.Contains(r.Destination)))
            {
                ExploreRoutes(routes, route.Destination, destination, currentCost + route.Cost);
            }
        }

        _visited.Remove(current);
        _currentPath.RemoveAt(_currentPath.Count - 1);
    }
}