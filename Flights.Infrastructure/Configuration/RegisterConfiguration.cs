using Flights.Domain.Interfaces;
using Flights.Infrastructure.Persistence;
using Flights.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Flights.Infrastructure.Configuration;

public static class RegisterConfiguration
{
    public static void RegisterInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<FlightDbContext>(opts =>
        {
            opts.UseInMemoryDatabase("FlightsDb");
        });

        services.AddScoped<IRouteRepository, RouteRepository>();
    }
}