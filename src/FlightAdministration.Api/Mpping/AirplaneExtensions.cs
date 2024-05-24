using FlightAdministration.Api.DTOs;
using FlightAdministration.Core.Models;

namespace FlightAdministration.Api.Mpping;

public static class AirplaneExtensions {
    public static AirplaneDto ToAirplaneDto(this Airplane airplane) {

        
        return new AirplaneDto(
            airplane.Id,
            airplane.Type,
            airplane.Engine,
            airplane.EmptyWeight,
            airplane.MaxTakeoffWeight,
            airplane.FuelCapacity,
            airplane.PilotsCapacity,
            airplane.PassengersCapacity,
            airplane.FuelCapacity,
            airplane.MaxSpeed
        );
    }
}