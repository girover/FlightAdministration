namespace FlightAdministration.Core.DomainDTOs;

public record FlightSimulationRequest(
    Guid OriginAirportId,
    Guid DestinationAirportId,
    Guid AirplaneId
);
