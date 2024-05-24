using FlightAdministration.Api.Response;
using FlightAdministration.Core.DomainDTOs;
using FlightAdministration.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightAdministration.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FlightController(IFlightSimulator flightSimulator) 
    : ControllerBase {

    private readonly IFlightSimulator _flightSimulator = flightSimulator;

 
    [HttpGet("simulate")]
    public async Task<IActionResult> Get([FromQuery] FlightSimulationRequest request) { 
    
        var simulationResult = await _flightSimulator.Simulate(request);
        
        if (simulationResult == null) {
            return ResponseHelper.BadRequest("Invalid request");
        }

        return ResponseHelper.Ok(simulationResult, "Flight information.");
    }

}
