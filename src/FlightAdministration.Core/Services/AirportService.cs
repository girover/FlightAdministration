using FlightAdministration.Core.Models;
using FlightAdministration.Core.Repositories;

namespace FlightAdministration.Core.Services;
public class AirportService(IAirportRepositroy airportRepository) : IAirportService {

    private readonly IAirportRepositroy _airportRepository = airportRepository;
    public async Task<IEnumerable<Airport>> GetAllAsync() {
        return await _airportRepository.GetAllAsync();
    }

    public async Task<Airport>? GetByIdAsync(Guid id) {
        return await _airportRepository.GetByIdAsync(id);
    }

    public async Task<Airport> AddAsync(Airport airport) {
        await _airportRepository.AddAsync(airport);
        return airport;
    }


    public void DeleteAsync(Airport airport) {
        _airportRepository.DeleteAsync(airport);
    }

    public async Task<Airport?> UpdateAsync(Guid id, Airport airport) {

        var airportToUpdate = await _airportRepository.GetByIdAsync(id);

        if (airportToUpdate == null) {
            return null;
        }
        
        await _airportRepository.UpdateAsync(airportToUpdate, airport);

        return airport;
    }

    public async Task DeleteAsync(Guid id) {

        var airport = await _airportRepository.GetByIdAsync(id);
        
        if (airport == null) {
            throw new Exception("Airplane not found");
        }
        await _airportRepository.DeleteAsync(airport);
    }
}
