using FlightAdministration.Core.Enums;
using FlightAdministration.Core.Exceptions;
using FlightAdministration.Core.Models;
using FlightAdministration.Core.Repositories;
using FlightAdministration.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FlightAdministration.Persistence.Repositories;
public class AirplaneRepository(FlightAdministrationDbContext dbContext) : IAirplaneRepository {

    private readonly FlightAdministrationDbContext _dbContext = dbContext;

    public async Task<IEnumerable<Airplane>> GetAllAsync() {
        return  await _dbContext.Airplanes.ToListAsync();
    }

    public async Task<Airplane?> GetByIdAsync(Guid id) {

        return await _dbContext.Airplanes.FindAsync(id);
    }

    public async Task<List<Airplane>> GetByTypeAsync(AirplaneType type) { 

        return await _dbContext.Airplanes.Where(x => x.Type == type).ToListAsync();
    }

    public async Task AddAsync(Airplane airplane) {

        await _dbContext.Airplanes.AddAsync(airplane);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Airplane?> UpdateAsync(Airplane airplaneToUpdate, Airplane airplane) {

        //var airplaneToUpdate = await _dbContext.Airplanes.FindAsync(id);

        airplaneToUpdate.Type = airplane.Type;
        airplaneToUpdate.Engine = airplane.Engine;
        airplaneToUpdate.EmptyWeight = airplane.EmptyWeight;
        airplaneToUpdate.MaxTakeoffWeight = airplane.MaxTakeoffWeight;
        airplaneToUpdate.FuelCapacity = airplane.FuelCapacity;
        airplaneToUpdate.EngineCount = airplane.EngineCount;
        airplaneToUpdate.PassengersCapacity = airplane.PassengersCapacity;
        airplaneToUpdate.PilotsCapacity = airplane.PilotsCapacity;
        airplaneToUpdate.MaxSpeed = airplane.MaxSpeed;

        int updatedRows = await _dbContext.SaveChangesAsync();
        
        if (updatedRows > 0) {
            return airplaneToUpdate;
        }

        return null;
    }
    
    public async Task DeleteAsync(Airplane airplane) {

        var airplaneToDelete = await _dbContext.Airplanes.FindAsync(airplane.Id);

        if (airplaneToDelete is null) {
            throw new ModelNotFoundException("Airplane not found");
        }

        _dbContext.Remove(airplane);
        
        int affectedRowes = await _dbContext.SaveChangesAsync();

        if (affectedRowes == 0) {
            throw new DataException("Airplane not deleted");
        }
    }
}
