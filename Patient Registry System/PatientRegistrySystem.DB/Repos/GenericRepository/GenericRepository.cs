using Microsoft.EntityFrameworkCore;
using PatientRegistrySystem.DB.Contexts;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationIdentityDbContext _ApplicationDbContext;
        private DbSet<T> _entities;

        public GenericRepository(ApplicationIdentityDbContext applicationIdentityDbContext)
        {
            _ApplicationDbContext = applicationIdentityDbContext;
            _entities = _ApplicationDbContext.Set<T>();
        }

        public async Task<bool> CreateEntitySoftAsync(T entity)
        {
            await _entities.AddAsync(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteEntityDeepAsync(T entity)
        {
            _entities.Remove(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteEntitySoftAsync(T entity)
        {
            _entities.Update(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _ApplicationDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateEntitySoftAsync(T entity)
        {
            _entities.Update(entity);
            return await SaveChangesAsync();
        }
    }
}
