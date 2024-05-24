using FlightAdministration.Core.DomainDTOs;
using FlightAdministration.Core.Services;
using FlightAdministration.Persistence.Data;
using Moq;

namespace FlightAdministration.Test;
public class FlightSimulatorTest {
    
    [Fact]
    public async Task Simulate_Returns_FlightSimulationResponse() {
        // Arrange
        var originAirport       = Data.Airports.ElementAt(0);
        var destinationAirport  = Data.Airports.ElementAt(1);
        var airplane            = Data.Airplanes.ElementAt(2);

        var airportServiceMock = new Mock<IAirportService>();

        airportServiceMock.Setup(s => s.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Guid id) => id == originAirport.Id ? originAirport : destinationAirport);

        var airplaneServiceMock = new Mock<IAirplaneService>();

        airplaneServiceMock.Setup(s => s.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(airplane);

        var flightSimulator = new FlightSimulator(airplaneServiceMock.Object, airportServiceMock.Object);

        var request = new FlightSimulationRequest(
            OriginAirportId : originAirport.Id,
            DestinationAirportId : destinationAirport.Id,
            AirplaneId : airplane.Id
        );

        // Act
        var result = await flightSimulator.Simulate(request);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Copenhagen Airport", result.OriginAirport);
        Assert.Equal("Billund Airport", result.DestinationAirport);
    }
}
