using FlightAdministration.Core.Enums;
using FlightAdministration.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightAdministration.Persistence.Data;
public class FlightAdministrationDbContext(DbContextOptions<FlightAdministrationDbContext> options) : DbContext(options) {

    public DbSet<Airplane> Airplanes { get; set; }
    public DbSet<Airport> Airports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {

        modelBuilder.Entity<Airplane>().HasKey(a => a.Id);

        modelBuilder.Entity<Airport>().HasKey(a => a.Id);
    }   
}
