using FlightAdministration.Api.DTOs;
using FlightAdministration.Api.Response;
using FlightAdministration.Core.Controllers;
using FlightAdministration.Core.Models;
using FlightAdministration.Core.Services;
using FlightAdministration.Persistence.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAdministration.Test.Controllers;
public class AirplanesControllerTests {

    [Fact]
    public async Task Get_ReturnsOkResultWithData() {
        // Arrange
        var mockAirplaneService = new Mock<IAirplaneService>();
        var expectedAirplanes = Data.Airplanes;
        
        mockAirplaneService.Setup(service => service.GetAllAsync()).ReturnsAsync(expectedAirplanes);

        var controller = new AirplanesController(mockAirplaneService.Object);

        // Act
        var result = await controller.Get();

        // Assert
        var okResult = Assert.IsType<ObjectResult>(result);
        var response = Assert.IsType<ApiResponse<IEnumerable<AirplaneDto>>>(okResult.Value);
        var airplanesDtos = response.Data.ToList();
        Assert.Equal(expectedAirplanes.Count(), airplanesDtos.Count);
        Assert.Equal("List of airplanes", response.Message); // Check Title property of the ApiResponse
        Assert.True(response.Ok);
    }
}
