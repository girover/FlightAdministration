using FlightAdministration.Core.Enums;
using FlightAdministration.Core.Models;

namespace FlightAdministration.Core.Repositories;


public interface IAirplaneRepository : IRepository<Airplane>, IHasTypeRepository<Airplane, AirplaneType> {
    
}
