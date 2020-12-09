using PatientRegistrySystem.DB.Models.DbModels;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.GenericRepository
{
    public interface IGenericRepository<DbEntity, DomainEntity1, DomainEntity2>
        where DbEntity : class,IDbModel
        where DomainEntity1 : IDomainModel
        where DomainEntity2 : IDomainModel
    {
        Task<List<DomainEntity1>> GetAllEntitiesAsync(bool active = true,string userRole="");
        Task<DomainEntity1> GetEntityAsync(int entityId, bool active = true, string userRole = "");

        Task<List<DomainEntity1>> FindAllEntitiesAsync(List<int> entityId, bool active = true);
        Task<DomainEntity1> FindEntityAsync(int entityId, bool active = true);
        Task<DomainEntity1> FindEntityClaimsAsync(ClaimsPrincipal claimsPrincipal);
        Task<DomainEntity1> FindEntityByEmailAsync(string email);

        Task<bool> CreateEntityAsync(DomainEntity2 entity);
        Task<List<bool>> CreateRangeEntitiesAsync(List<DomainEntity2> entity);

        Task<bool> UpdateEntityAsync(DomainEntity1 entity);
        Task<List<bool>> UpdateRangeEntitiesAsync(List<DomainEntity1> entity);

        Task<bool> DeleteEntityHardAsync(DomainEntity1 entity);
        Task<List<bool>> DeleteRangeEntitiesHardAsync(List<DomainEntity1> entity);
        Task<bool> DeleteEntitySoftAsync(DomainEntity1 entity);
        Task<List<bool>> DeleteRangeEntitiesSoftAsync(List<DomainEntity1> entity);
    }
}
