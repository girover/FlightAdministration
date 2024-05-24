using FlightAdministration.Core.Enums;
using FlightAdministration.Core.Models;

namespace FlightAdministration.Persistence.Data;
public class Data {
    
    public static readonly IEnumerable<Airplane> Airplanes = [
        new Airplane { Id = new Guid("4f92fbf4-2a78-4a18-b5af-11f65a61d8b3"), Type = AirplaneType.Glider, Engine = EngineType.None, EmptyWeight = 500, MaxTakeoffWeight = 1000, FuelCapacity = 0, EngineCount = 0, PassengersCapacity = 1, PilotsCapacity = 1, MaxSpeed = 200, FuelEfficiency = 0 },
        new Airplane { Id = new Guid("2a06edfc-502b-464f-8678-dc1ee64e33ab"), Type = AirplaneType.Private, Engine = EngineType.Piston, EmptyWeight = 2000, MaxTakeoffWeight = 5000, FuelCapacity = 300, EngineCount = 1, PassengersCapacity = 6, PilotsCapacity = 1, MaxSpeed = 600, FuelEfficiency = 10 },
        new Airplane { Id = new Guid("07d64f14-9b16-4b1e-81db-27e25aa1b8e9"), Type = AirplaneType.Passenger, Engine = EngineType.Turbojet, EmptyWeight = 5000, MaxTakeoffWeight = 20000, FuelCapacity = 10000, EngineCount = 2, PassengersCapacity = 150, PilotsCapacity = 2, MaxSpeed = 900, FuelEfficiency = 5 },
        new Airplane { Id = new Guid("b80c4f97-7b72-4e1e-b14a-cfb5046e5d42"), Type = AirplaneType.Transport, Engine = EngineType.Turbojet, EmptyWeight = 10000, MaxTakeoffWeight = 50000, FuelCapacity = 20000, EngineCount = 2, PassengersCapacity = 50, PilotsCapacity = 2, MaxSpeed = 800, FuelEfficiency = 4 },
        new Airplane { Id = new Guid("fa8bb133-9ff5-4e16-9f80-89cf77d1fb4b"), Type = AirplaneType.Fighter, Engine = EngineType.Turbojet, EmptyWeight = 15000, MaxTakeoffWeight = 30000, FuelCapacity = 5000, EngineCount = 1, PassengersCapacity = 0, PilotsCapacity = 1, MaxSpeed = 1500, FuelEfficiency = 2 },
        new Airplane { Id = new Guid("44647e97-5e9a-49d4-b6aa-7a5a2771bb63"), Type = AirplaneType.Glider, Engine = EngineType.None, EmptyWeight = 500, MaxTakeoffWeight = 1000, FuelCapacity = 0, EngineCount = 0, PassengersCapacity = 1, PilotsCapacity = 1, MaxSpeed = 200, FuelEfficiency = 0 },
        new Airplane { Id = new Guid("8cfb97fb-af44-49db-a548-2d15df0a7aa7"), Type = AirplaneType.Private, Engine = EngineType.Piston, EmptyWeight = 2000, MaxTakeoffWeight = 5000, FuelCapacity = 300, EngineCount = 1, PassengersCapacity = 6, PilotsCapacity = 1, MaxSpeed = 600, FuelEfficiency = 10 },
        new Airplane { Id = new Guid("12e05e36-0f98-4390-b3de-80a4d5d48f42"), Type = AirplaneType.Passenger, Engine = EngineType.Turbojet, EmptyWeight = 5000, MaxTakeoffWeight = 20000, FuelCapacity = 10000, EngineCount = 2, PassengersCapacity = 150, PilotsCapacity = 2, MaxSpeed = 900, FuelEfficiency = 5 },
        new Airplane { Id = new Guid("7b560883-9c54-4ae1-b89e-754d23582de5"), Type = AirplaneType.Transport, Engine = EngineType.Turbojet, EmptyWeight = 10000, MaxTakeoffWeight = 50000, FuelCapacity = 20000, EngineCount = 2, PassengersCapacity = 50, PilotsCapacity = 2, MaxSpeed = 800, FuelEfficiency = 4 },
        new Airplane { Id = new Guid("9277ac32-4e86-4e24-a4a9-540c30809e53"), Type = AirplaneType.Fighter, Engine = EngineType.Turbojet, EmptyWeight = 15000, MaxTakeoffWeight = 30000, FuelCapacity = 5000, EngineCount = 1, PassengersCapacity = 0, PilotsCapacity = 1, MaxSpeed = 1500, FuelEfficiency = 2 }
    ];

    public static readonly IEnumerable<Airport> Airports = [
        new Airport { Id = new Guid("b5c902e5-ced0-47b3-a6de-bf7c02b6ad1b"), Name = "Copenhagen Airport", Latitude = 55.618024, Longitude = 12.650763 },
        new Airport { Id = new Guid("8f57cf39-1e24-4e47-bd9b-33b93472ec7e"), Name = "Billund Airport", Latitude = 55.740322, Longitude = 9.151778 },
        new Airport { Id = new Guid("7f57c3ab-eb78-42e1-97d3-3f2e5b7d1832"), Name = "Aarhus Airport", Latitude = 56.303844, Longitude = 10.619008 },
        new Airport { Id = new Guid("2e68946d-9d57-4741-9bc9-d582d28bb758"), Name = "Aalborg Airport", Latitude = 57.092789, Longitude = 9.849164 },
        new Airport { Id = new Guid("54b2f316-0158-4a21-bd8e-6e51a4bb3a79"), Name = "Esbjerg Airport", Latitude = 55.525942, Longitude = 8.553403 },
        new Airport { Id = new Guid("b13a74d7-f868-4a6a-a9b5-17f64b25f5c5"), Name = "Karup Airport", Latitude = 56.297458, Longitude = 9.124628 },
        new Airport { Id = new Guid("b1241917-4e7c-4c1d-9a14-33b5944167a7"), Name = "Sønderborg Airport", Latitude = 54.964367, Longitude = 9.791731 },
        new Airport { Id = new Guid("4ad6b547-c06b-43d0-9e96-fcd3145e510f"), Name = "Roskilde Airport", Latitude = 55.585567, Longitude = 12.131428 },
        new Airport { Id = new Guid("69a05fe5-d9d2-4c71-92b2-d0258e631cad"), Name = "Bornholm Airport", Latitude = 55.063267, Longitude = 14.759558 },
        new Airport { Id = new Guid("ee0c4b1f-ec10-457e-9067-01b4d7daa0e0"), Name = "Odense Airport", Latitude = 55.476466, Longitude = 10.330933 }
    ];

}
