using PatientRegistrySystem.DB.Models.DbModels;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.DbGenericRepository
{
    public interface IDbGeneric<DbEntity, DomainEntity> where DbEntity : class, IDbModel where DomainEntity : IDomainModel
    {
        Task<List<DomainEntity>> GetAllEntitiesAsync();
        Task<DomainEntity> GetEntityAsync(int entityId);

        Task<List<DomainEntity>> FindAllEntitiesAsync();
        Task<List<DomainEntity>> FindAllEntitiesAsync(int entityId);
        Task<DomainEntity> FindEntityAsync(int entityId);

        Task<bool> CreateEntityAsync(DomainEntity entity);
        Task<bool> UpdateEntityAsync(DomainEntity entity);
        Task<bool> DeleteEntityDeepAsync(DomainEntity entity);
        Task<bool> DeleteEntitySoftAsync(DomainEntity entity);
        Task<bool> SaveChangesAsync();
    }
}