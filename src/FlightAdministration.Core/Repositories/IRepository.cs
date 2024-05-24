using FlightAdministration.Core.Models;

namespace FlightAdministration.Core.Repositories;
public interface IRepository<TEntity> where TEntity : class {
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Guid id);
    Task AddAsync(TEntity entity);
    Task<TEntity?> UpdateAsync(TEntity toUpdate, TEntity enity);
    Task DeleteAsync(TEntity entity);
}
