using Flights.Application.Dtos;
using Flights.Domain.Entities;
using Flights.Domain.Interfaces;
using Flights.Domain.Services;

namespace Flights.Application.Services;

public class RouteService(IRouteRepository routeRepository, RouteFinderService routeFinderService)
{
    public async Task CreateRouteAsync(RouteDto dto)
    {
        var route = new Route(dto.Origin, dto.Destination, dto.Cost);

        await routeRepository.AddAsync(route);
    }

    public async Task<RouteQueryResponse> GetBestRouteAsync(string origin, string destination)
    {
        var bestRoute = await routeFinderService.FindBestRoute(origin, destination);

        return new RouteQueryResponse(bestRoute.Path, bestRoute.TotalCost);
    }
}