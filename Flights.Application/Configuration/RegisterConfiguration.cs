using Flights.Application.Services;
using Flights.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Flights.Application.Configuration;

public static class RegisterConfiguration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<RouteService>();
        services.AddScoped<RouteFinderService>();
    }
}