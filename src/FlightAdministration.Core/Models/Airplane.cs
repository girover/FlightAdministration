using FlightAdministration.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace FlightAdministration.Core.Models;
public class Airplane {
    public Guid Id { get; set; }
    [Required]
    public AirplaneType Type { get; set; }

    [Required]
    public EngineType Engine { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "EmptyWeight must be non-negative")]
    public double EmptyWeight { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "MaxTakeoffWeight must be non-negative")]
    public double MaxTakeoffWeight { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "FuelCapacity must be non-negative")]
    public double FuelCapacity { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "FuelEfficiency must be non-negative")]
    public int FuelEfficiency { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "EngineCount must be non-negative")]
    public int EngineCount { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "PassengersCapacity must be non-negative")]
    public int PassengersCapacity { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "PilotsCapacity must be non-negative")]
    public int PilotsCapacity { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "MaxSpeed must be non-negative")]
    public int MaxSpeed { get; set; }
}
