using FlightAdministration.Core.Models;
using FlightAdministration.Core.Repositories;

namespace FlightAdministration.Core.Services;
public class AirplaneService(IAirplaneRepository airplaneRepository) : IAirplaneService {

    private readonly IAirplaneRepository _airplaneRepository = airplaneRepository;

    public async Task<IEnumerable<Airplane>> GetAllAsync() {
        return await _airplaneRepository.GetAllAsync();
    }

    public async Task<Airplane>? GetByIdAsync(Guid id) {

        return await _airplaneRepository.GetByIdAsync(id);
    }

    public async Task<Airplane> AddAsync(Airplane airplane) {
        await _airplaneRepository.AddAsync(airplane);
        return airplane;
    }


    public async Task DeleteAsync(Airplane airplane) {
        await _airplaneRepository.DeleteAsync(airplane);
    }

    public async Task<Airplane?> UpdateAsync(Guid id, Airplane airplane) {

        var airplaneToUpdate = await _airplaneRepository.GetByIdAsync(id);

        if (airplaneToUpdate == null) {
            return null;
        }

        return await _airplaneRepository.UpdateAsync(airplaneToUpdate, airplane);
    }

    public async Task DeleteAsync(Guid id) {

        var airplane = await _airplaneRepository.GetByIdAsync(id);
        
        if (airplane == null) {
            throw new Exception("Airplane not found");
        }
        await _airplaneRepository.DeleteAsync(airplane);
    }
}
