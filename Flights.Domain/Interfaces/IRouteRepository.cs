using Flights.Domain.Entities;

namespace Flights.Domain.Interfaces;

public interface IRouteRepository
{
    Task AddAsync(Route route);
    Task<Route?> GetByIdAsync(int id);
    Task<List<Route>> GetAllAsync();
    Task DeleteAsync(int id);
}