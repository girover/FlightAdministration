using FlightAdministration.Core.DomainDTOs;

namespace FlightAdministration.Core.Services;
public interface IFlightSimulator {
    Task<FlightSimulationResponse?> Simulate(FlightSimulationRequest request);
}
