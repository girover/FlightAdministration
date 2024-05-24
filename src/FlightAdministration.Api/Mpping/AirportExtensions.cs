using FlightAdministration.Api.DTOs;
using FlightAdministration.Core.Models;

namespace FlightAdministration.Api.Mpping;


public static class AirportExtensions { 
    
    public static AirportDto ToAirportDto(this Airport airport) {
        
        return new AirportDto(
                     airport.Id,
                     airport.Name,
                     airport.Latitude,
                     airport.Longitude
         );
    }
}