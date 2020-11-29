using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos
{
    public interface IGenericRepository<T,k> where T : class
    {
        Task<T> CreateEntityAsync(k entity);
        Task<bool> UpdateEntity(T entity);
        Task<T> GetIdShallowAsync(int entityId);
        Task<List<T>> GetAllShallowAsync();
        Task<T> FindEntitySallowAsync(int entityId);
        Task<bool> DeleteEntityDeepAsync(T entity);
        Task<bool> DeleteEntityShallowAsync(T entity);
        Task<bool> SaveChangesAsync();
    }
}
