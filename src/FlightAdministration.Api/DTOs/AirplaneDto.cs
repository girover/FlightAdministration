using FlightAdministration.Core.Enums;

namespace FlightAdministration.Api.DTOs;

public record AirplaneDto(
    Guid Id,
    AirplaneType Type,
    EngineType EngineType,
    double EmptyWeight,
    double MaxTakeoffWeight,
    double FuelEfficiency,
    int NumberOfPilots,
    int PassengerCapacity,
    double FuelCapacity,
    double MaxSpeed
);
