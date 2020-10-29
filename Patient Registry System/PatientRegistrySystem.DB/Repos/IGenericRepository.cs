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
        Task<T> GetIdShallowAsync(int entityId);
        Task<List<T>> GetAllShallowAsync();
        Task<T> FindEntitySallowAsync(int entityId);
        Task<bool> DeleteEntityDeepAsync(T entity);
        Task<bool> DeleteEntityShallowAsync(T entity);
        Task<bool> SaveChangesAsync();
    }
}
