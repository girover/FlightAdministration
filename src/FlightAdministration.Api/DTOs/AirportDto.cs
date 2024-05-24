namespace FlightAdministration.Api.DTOs;

public record AirportDto (
    Guid Id,
    string Name,
    double Latitude,
    double Longitude
);
