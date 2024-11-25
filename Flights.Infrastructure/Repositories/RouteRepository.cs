using Flights.Domain.Entities;
using Flights.Domain.Interfaces;
using Flights.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Flights.Infrastructure.Repositories;

public class RouteRepository(FlightDbContext flightDbContext) : IRouteRepository
{
    public async Task AddAsync(Route route)
    {
        await flightDbContext.Routes.AddAsync(route);
        await flightDbContext.SaveChangesAsync();
    }

    public async Task<Route?> GetByIdAsync(int id)
    {
        return await flightDbContext.Routes.FindAsync(id);
    }

    public async Task<List<Route>> GetAllAsync()
    {
        return await flightDbContext
            .Routes
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var route = await flightDbContext.Routes.FindAsync(id);

        if (route == null)
            return;
        
        flightDbContext.Routes.Remove(route);
        await flightDbContext.SaveChangesAsync();
    }
}