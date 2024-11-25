using Flights.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flights.Infrastructure.Persistence;

public class FlightDbContext(DbContextOptions<FlightDbContext> opts) : DbContext(opts)
{
    public DbSet<Route> Routes { get; set; }
}