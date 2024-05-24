using FlightAdministration.Core.Enums;
using FlightAdministration.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAdministration.Core.Repositories;
public interface IHasTypeRepository<TEntity, TType> where TEntity: class where TType:Enum {
    Task<List<TEntity>> GetByTypeAsync(TType type);
}
