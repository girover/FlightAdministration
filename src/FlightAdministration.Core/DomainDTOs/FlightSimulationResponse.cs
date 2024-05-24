
namespace FlightAdministration.Core.DomainDTOs;

public record FlightSimulationResponse(
    string OriginAirport,
    string DestinationAirport,
    int Distance,
    string FlightTime,
    double FuelRequired
);
