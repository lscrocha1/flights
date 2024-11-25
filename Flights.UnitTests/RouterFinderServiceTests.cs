using Flights.Domain.Entities;
using Flights.Domain.Interfaces;
using Flights.Domain.Services;
using Moq;

namespace Flights.UnitTests;

public class RouterFinderServiceTests
{
    private readonly Mock<IRouteRepository> _routeRepositoryMock;
    private readonly RouteFinderService _routeFinderService;

    public RouterFinderServiceTests()
    {
        _routeRepositoryMock = new Mock<IRouteRepository>();
        _routeFinderService = new RouteFinderService(_routeRepositoryMock.Object);
    }

    [Fact]
    public async Task FindBestRouteAsync_ShouldReturnBestRoute()
    {
        // Arrange
        var routes = new List<Route>
        {
            new("GRU", "BRC", 10),
            new("BRC", "SCL", 5),
            new("GRU", "SCL", 20)
        };

        _routeRepositoryMock.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(routes);

        // Act
        var result = await _routeFinderService.FindBestRoute("GRU", "SCL");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("GRU - BRC - SCL", result.Path);
        Assert.Equal(15, result.TotalCost);
    }
}