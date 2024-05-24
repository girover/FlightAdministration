using FlightAdministration.Core.DomainDTOs;
using FlightAdministration.Core.Models;

namespace FlightAdministration.Core.Services;

public class FlightSimulator(IAirplaneService airplaneService, IAirportService airportService) : IFlightSimulator {

    private readonly IAirplaneService _airplaneService = airplaneService;
    private readonly IAirportService _airportService = airportService;

    public async Task<FlightSimulationResponse?> Simulate(FlightSimulationRequest request) {
        
        Airport origin = await _airportService.GetByIdAsync(request.OriginAirportId);
        Airport destination = await _airportService.GetByIdAsync(request.DestinationAirportId);
        Airplane airplane = await _airplaneService.GetByIdAsync(request.AirplaneId);

        if (origin is null || destination is null || airplane is null) {
            return null;
        }

        return Simulate(origin, destination, airplane);
    }

    public static FlightSimulationResponse Simulate(Airport origin, Airport destination, Airplane airplane) {
        
        int distance = (int)CalculateDistanceBetweenTwoAirports(origin, destination);
        double flightTime = CalculateFlightTimeBetweenTwoAirports(distance, airplane.MaxSpeed);
        double fuelRequired = CalculateFuelRequiredBetweemTwoAirports(distance, airplane.FuelEfficiency);

        return new FlightSimulationResponse(
            OriginAirport : origin.Name,
            DestinationAirport : destination.Name,
            Distance : distance,
            FlightTime : ConvertTimeToFormattedString(flightTime),
            FuelRequired : fuelRequired
        );
    }

    private static double CalculateDistanceBetweenTwoAirports(Airport origin, Airport destination) {

        // Calculate distance based on coordinates (Haversine formula)
        return Haversine(origin.Latitude, origin.Longitude, destination.Latitude, destination.Longitude);
    }

    private static double CalculateFlightTimeBetweenTwoAirports(double distance, double speed) {
        
        return distance / speed;
    }

    private static double CalculateFuelRequiredBetweemTwoAirports(double distance, double fuelEfficiency) {
        return fuelEfficiency == 0 ? 0 : distance / fuelEfficiency;
    }

    private static double Haversine(double lat1, double lon1, double lat2, double lon2) {
        // Convert latitude and longitude from degrees to radians
        double R = 6371.0; // Radius of Earth in kilometers. Use 3956 for miles.
        double dLat = DegreesToRadians(lat2 - lat1);
        double dLon = DegreesToRadians(lon2 - lon1);
        lat1 = DegreesToRadians(lat1);
        lat2 = DegreesToRadians(lat2);

        // Haversine formula
        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(lat1) * Math.Cos(lat2) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        double c = 2 * Math.Asin(Math.Sqrt(a));

        // Distance in kilometers
        double distance = R * c;

        return distance;
    }

    private static double DegreesToRadians(double degrees) {
        return degrees * (Math.PI / 180);
    }

    public static string ConvertTimeToFormattedString(double timeInHours) {
        // Convert hours to minutes and seconds
        int hours = (int)timeInHours;
        int remainingMinutes = (int)((timeInHours - hours) * 60);
        int remainingSeconds = (int)(((timeInHours - hours) * 60 - remainingMinutes) * 60);

        // Construct the formatted string
        string formattedTime = $"{hours}:{remainingMinutes}:{remainingSeconds}";

        return formattedTime;
    }
}
