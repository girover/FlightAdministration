using FlightAdministration.Api.Mpping;
using FlightAdministration.Api.Response;
using FlightAdministration.Core.Models;
using FlightAdministration.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightAdministration.Core.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AirportsController(IAirportService airportService) : ControllerBase {

    protected IAirportService _airportService = airportService;

    [HttpGet]
    public async Task<IActionResult> Get() {

        var result = await _airportService.GetAllAsync();

        var airports = result.Select(a => a.ToAirportDto());

        return ResponseHelper.Ok(airports, "List of airports."); 
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id) {

        var airport = await _airportService.GetByIdAsync(id);
        
        if(airport is null) {
            return ResponseHelper.NotFound($"Airport with id {id} not found");
        }
        
        return ResponseHelper.Ok(airport.ToAirportDto(), "Airport is retrieved successfully.");
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Airport airport) {
        
        if (!ModelState.IsValid) { 
            return ResponseHelper.BadRequest(ModelState, "Airport is not valid.");
        }

        airport.Id = Guid.NewGuid();

        var createdAirport = await _airportService.AddAsync(airport);

        if (createdAirport is null) {
            return ResponseHelper.BadRequest(airport, "Airport was not created.");
        }

        return ResponseHelper.Ok(createdAirport.ToAirportDto(), "Airport was created successfully.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] Airport airport) {
        
        if (!ModelState.IsValid) {
            return ResponseHelper.BadRequest(ModelState, "Airport is not valid.");
        }

        var updatedAirplane = await _airportService.UpdateAsync(id, airport);
        
        if (updatedAirplane is null) { 
            return ResponseHelper.BadRequest(airport, $"Airport with id {id} not found");
        }

        return ResponseHelper.Ok(updatedAirplane.ToAirportDto(), "Airport was updated successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id) {
        await _airportService.DeleteAsync(id);

        return ResponseHelper.Ok(new { }, "Airport was deleted successfully.");
    }
}
