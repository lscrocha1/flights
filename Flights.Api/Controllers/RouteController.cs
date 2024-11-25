using Flights.Application.Dtos;
using Flights.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flights.Api.Controllers;

[ApiController]
[Route("api/route")]
public class RouteController(RouteService routeService) : ControllerBase
{
    [HttpPost("test-data")]
    public async Task InsertTestData()
    {
        var routes = new List<RouteDto>()
        {
            new()
            {
                Origin = "GRU",
                Destination = "BRC",
                Cost = 10
            },
            new()
            {
                Origin = "BRC",
                Destination = "SCL",
                Cost = 5
            },
            new()
            {
                Origin = "GRU",
                Destination = "CDG",
                Cost = 75
            },
            new()
            {
                Origin = "GRU",
                Destination = "SCL",
                Cost = 20
            },
            new()
            {
                Origin = "GRU",
                Destination = "ORL",
                Cost = 56
            },
            new()
            {
                Origin = "ORL",
                Destination = "CDG",
                Cost = 5
            },
            new()
            {
                Origin = "SCL",
                Destination = "ORL",
                Cost = 20
            }
        };

        var tasks = new List<Task>();
        
        routes.ForEach(route =>
        {
            tasks.Add(routeService.CreateRouteAsync(route));
        });

        await Task.WhenAll(tasks);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateRoute([FromBody] RouteDto dto)
    {
        await routeService.CreateRouteAsync(dto);

        return Ok();
    }
    
    [HttpGet("best-route")]
    public async Task<IActionResult> FindBestRoute([FromQuery] string origin, [FromQuery] string destination)
    {
        var result = await routeService.GetBestRouteAsync(origin, destination);
        
        return Ok(result);
    }
}