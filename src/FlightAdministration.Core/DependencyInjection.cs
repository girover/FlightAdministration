using FlightAdministration.Core.Repositories;
using FlightAdministration.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace FlightAdministration.Core;
public static class DependencyInjection {

    public static IServiceCollection AddCore(this IServiceCollection services) {

        AddServices(services);

        return services;
    }

    private static IServiceCollection AddServices(IServiceCollection services) {

        services.AddScoped<IAirplaneService, AirplaneService>();
        services.AddScoped<IAirportService, AirportService>();
        services.AddScoped<IFlightSimulator, FlightSimulator>();

        return services;
    }

}
