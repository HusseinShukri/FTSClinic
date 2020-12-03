using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> CreateEntitySoftAsync(T entity);
        Task<bool> UpdateEntitySoftAsync(T entity);
        Task<bool> DeleteEntityDeepAsync(T entity);
        Task<bool> DeleteEntitySoftAsync(T entity);
        Task<bool> SaveChangesAsync();
    }
}
