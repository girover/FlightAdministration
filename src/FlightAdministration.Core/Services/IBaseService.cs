using FlightAdministration.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAdministration.Core.Services;
public interface IBaseService<T>  where T : class {
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<T> AddAsync(T airplane);
    Task<T?> UpdateAsync(Guid id, T airplane);
    Task DeleteAsync(Guid id);
}
