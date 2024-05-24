namespace FlightAdministration.Core.Models;
public class Engine {
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int FuelConsumption { get; set; }
    public int EngineTypeId { get; set; }
}
