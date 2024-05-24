using FlightAdministration.Core.Enums;
using FlightAdministration.Core.Exceptions;
using FlightAdministration.Core.Models;
using FlightAdministration.Core.Repositories;
using FlightAdministration.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FlightAdministration.Persistence.Repositories;
public class AirportRepository(FlightAdministrationDbContext dbContext) : IAirportRepositroy {

    private readonly FlightAdministrationDbContext _dbContext = dbContext;

    public async Task<IEnumerable<Airport>> GetAllAsync() {
        return  await _dbContext.Airports.ToListAsync();
    }

    public async Task<Airport?> GetByIdAsync(Guid id) {

        return await _dbContext.Airports.FindAsync(id);
    }

    public async Task AddAsync(Airport airport) {

        await _dbContext.Airports.AddAsync(airport);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Airport?> UpdateAsync(Airport airportToUpdate, Airport airport) {

        if (airportToUpdate is null) {
            throw new ModelNotFoundException("Airport not found");
        }

        airportToUpdate.Name = airport.Name;
        airportToUpdate.Latitude = airport.Latitude;
        airportToUpdate.Longitude = airport.Longitude;

        int updatedRows = await _dbContext.SaveChangesAsync();
        
        if (updatedRows > 0) {
            return airportToUpdate;
        }

        return null;
    }
    
    public async Task DeleteAsync(Airport airport) {

        var airportToDelete = await _dbContext.Airports.FindAsync(airport.Id);

        if (airportToDelete is null) {
            throw new ModelNotFoundException("Airport not found");
        }

        _dbContext.Remove(airport);
        
        int affectedRowes = await _dbContext.SaveChangesAsync();

        if (affectedRowes == 0) {
            throw new DataException("Airport not deleted");
        }
    }
}
