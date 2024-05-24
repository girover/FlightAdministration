using FlightAdministration.Core.Repositories;
using FlightAdministration.Persistence.Data;
using FlightAdministration.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace FlightAdministration.Persistence;
public static class DependencyInjection {

    public static IServiceCollection AddPersistence(this IServiceCollection services) {

        services.AddDbContext<FlightAdministrationDbContext>(
            options => options.UseInMemoryDatabase("InMemoryDb")
        );

        services.AddScoped<IAirplaneRepository, AirplaneRepository>();
        services.AddScoped<IAirportRepositroy, AirportRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // This registers the DatabaseSeeder service
        services.AddHostedService<DatabaseSeeder>();
        
        return services;
    }

}
