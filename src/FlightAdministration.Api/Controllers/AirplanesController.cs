using FlightAdministration.Api.Mpping;
using FlightAdministration.Api.Response;
using FlightAdministration.Core.Models;
using FlightAdministration.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightAdministration.Core.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AirplanesController(IAirplaneService airplaneService) : ControllerBase {

    protected IAirplaneService _airplaneService = airplaneService;

    [HttpGet]
    public async Task<IActionResult> Get() {

        var airplanes = await _airplaneService.GetAllAsync();
        var airplanesDtos = airplanes.Select(a => a.ToAirplaneDto());

        return ResponseHelper.Ok(airplanesDtos, "List of airplanes");
    }

    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id) {

        var result = await _airplaneService.GetByIdAsync(id);

        if (result is null) {
            return ResponseHelper.NotFound($"Airplane with id {id} not found");
        }

        var response = result.ToAirplaneDto();
        
        return ResponseHelper.Ok(response);
    }

    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Airplane airplane) {
        
        if (!ModelState.IsValid) {
            return ResponseHelper.BadRequest(ModelState, "Validation Error.");
        }

        airplane.Id = Guid.NewGuid();
        
        return ResponseHelper.Ok(await _airplaneService.AddAsync(airplane), "Airplane was created.");
    }

    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] Airplane airplane) {

        if (!ModelState.IsValid) {
            return ResponseHelper.BadRequest(ModelState, "Validation Error");
        }

        var updatedAirplane = await _airplaneService.UpdateAsync(id, airplane);
        
        if (updatedAirplane is null) { 
            return ResponseHelper.NotFound($"Airplane with id {id} not found");
        }

        return ResponseHelper.Ok(updatedAirplane, "Airplane was updated successfully.");
    }

    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id) {

        await _airplaneService.DeleteAsync(id);

        return ResponseHelper.Ok(new{ }, "Airplane was deleted successfully.");
    }
}
