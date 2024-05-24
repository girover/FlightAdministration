using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FlightAdministration.Persistence.Data;

public class DatabaseSeeder(IServiceScopeFactory scop) : IHostedService {
    
    private FlightAdministrationDbContext _context = null!;
    private readonly IServiceScopeFactory _scop = scop;

    public async Task Seed() {

        using var scope = _scop.CreateScope();

        _context = scope.ServiceProvider.GetRequiredService<FlightAdministrationDbContext>();
        
        _context.Database.EnsureCreated();

        await SeedAirplanes();
        await SeedAirports();
    }

    public async Task StartAsync(CancellationToken cancellationToken) {
        await Seed();
    }

    public Task StopAsync(CancellationToken cancellationToken) {
       return Task.CompletedTask;
    }

    private async Task SeedAirplanes() {

        if (!_context.Airplanes.Any()) {

            await _context.Airplanes.AddRangeAsync(Data.Airplanes);
            await _context.SaveChangesAsync();
        }
    }
    private async Task SeedAirports() {

        if (!_context.Airports.Any()) {

            await _context.Airports.AddRangeAsync(Data.Airports);
            await _context.SaveChangesAsync();
        }
    }
}
