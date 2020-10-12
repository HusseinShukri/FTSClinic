using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> CreateEntityAsync(T entity);
        Task<bool> UpdateEntity(T entity);
        Task<T> GetIdAsync(int entityId);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> Findentities(Expression<Func<T, bool>> predicate);
        Task<T> FindEntityAsync(int entityId);
        Task<bool> DeleteEntityAsync(T entity);
        Task<bool> SaveChangesAsync();
    }
}
