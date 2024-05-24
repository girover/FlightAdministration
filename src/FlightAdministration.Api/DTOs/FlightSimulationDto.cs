
using System.Text.Json.Serialization;

namespace FlightAdministration.Api.DTOs;

[JsonSerializable(typeof(FlightSimulationDto))]
public record FlightSimulationDto(
    string OriginAirport,
    string DestinationAirport,
    double Distance,
    double FlightTime,
    double FuelRequired
);
