using FlightAdministration.Core.Models;

namespace FlightAdministration.Api.DTOs;

public record FlightSimulationRequest(
    Guid OriginAirportId,
    Guid DestinationAirportId,
    Guid AirplaneId
);
