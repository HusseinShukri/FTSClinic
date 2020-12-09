using PatientRegistrySystem.DB.Models.DbModels;
using PatientRegistrySystem.DB.Repos.AplicationUserRepository;
using PatientRegistrySystem.DB.Repos.DbGenericRepository;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.GenericRepository
{
    public class GenericRepository<DbEntity, DomainEntity1, DomainEntity2> : IGenericRepository<DbEntity, DomainEntity1, DomainEntity2>
        where DbEntity : class, IDbModel
        where DomainEntity1 : IDomainModel
        where DomainEntity2 : IDomainModel
    {
        private readonly IAplicationUserRepository _aplicationUserRepository;
        private readonly IDbGeneric<DbEntity, DomainEntity1> _dbGeneric1;
        private readonly IDbGeneric<DbEntity, DomainEntity2> _dbGeneric2;

        public GenericRepository(IAplicationUserRepository aplicationUserRepository
            , IDbGeneric<DbEntity, DomainEntity1> dbGeneric1
            , IDbGeneric<DbEntity, DomainEntity2> dbGeneric2)
        {
            _aplicationUserRepository = aplicationUserRepository;
            _dbGeneric1 = dbGeneric1;
            _dbGeneric2 = dbGeneric2;
        }

        public async Task<bool> CreateEntityAsync(DomainEntity2 entity)
        {
            if (typeof(DomainEntity2) == typeof(ApplicationUserCreateModel))
            {
                var result = await _aplicationUserRepository.CreateApplicationUserAsync((ApplicationUserCreateModel)(object)entity);
                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (typeof(DomainEntity1) == typeof(RecordDto)
                || typeof(DomainEntity1) == typeof(PrescriptionDto)
                || typeof(DomainEntity1) == typeof(MedicineDto)
                || typeof(DomainEntity1) == typeof(CompanyDto))
            {
                return await _dbGeneric2.CreateEntityAsync(entity);
            }
            else
            {
                return false;
            }
        }

        public async Task<List<bool>> CreateRangeEntitiesAsync(List<DomainEntity2> entity)
        {
            if (typeof(DomainEntity2) == typeof(ApplicationUserCreateModel))
            {
                var users = await _aplicationUserRepository.CreateRangeApplicationUserAsync((List<ApplicationUserCreateModel>)(object)entity);
                var results = new List<bool>();
                foreach (var result in users)
                {
                    if (result.Succeeded)
                    {
                        results.Add(true);
                    }
                    else
                    {
                        results.Add(false);
                    }
                }
                return results;
            }
            else if (typeof(DomainEntity1) == typeof(RecordDto)
                || typeof(DomainEntity1) == typeof(PrescriptionDto)
                || typeof(DomainEntity1) == typeof(MedicineDto)
                || typeof(DomainEntity1) == typeof(CompanyDto))
            {
                var results = new List<bool>();
                foreach (var item in entity)
                {
                    results.Add( await _dbGeneric2.CreateEntityAsync(item));
                }
                return results;
            }
            else
            {
                return new List<bool>();
            }
        }

        public async Task<bool> DeleteEntityHardAsync(DomainEntity1 entity)
        {
            if (typeof(DomainEntity1) == typeof(ApplicationUserDto))
            {
                var result = await _aplicationUserRepository.DeleteApplicationUserDeepAsync((ApplicationUserDto)(object)entity);
                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (typeof(DomainEntity1) == typeof(RecordDto)
                || typeof(DomainEntity1) == typeof(PrescriptionDto)
                || typeof(DomainEntity1) == typeof(MedicineDto)
                || typeof(DomainEntity1) == typeof(CompanyDto))
            {
                return await _dbGeneric1.DeleteEntityDeepAsync(entity);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteEntitySoftAsync(DomainEntity1 entity)
        {
            if (typeof(DomainEntity1) == typeof(ApplicationUserDto))
            {
                var result = await _aplicationUserRepository.DeleteApplicationUserSoftAsync((ApplicationUserDto)(object)entity);
                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (typeof(DomainEntity1) == typeof(RecordDto)
                || typeof(DomainEntity1) == typeof(PrescriptionDto)
                || typeof(DomainEntity1) == typeof(MedicineDto)
                || typeof(DomainEntity1) == typeof(CompanyDto))
            {
                return await _dbGeneric1.DeleteEntitySoftAsync(entity);
            }
            else
            {
                return false;
            }
        }

        public async Task<List<bool>> DeleteRangeEntitiesHardAsync(List<DomainEntity1> entity)
        {
            if (typeof(DomainEntity1) == typeof(ApplicationUserDto))
            {
                var results = new List<bool>();
                foreach (var item in entity)
                {
                    var result = await _aplicationUserRepository.DeleteApplicationUserDeepAsync((ApplicationUserDto)(object)item);
                    if (result.Succeeded)
                    {
                        results.Add(true);
                    }
                    else
                    {
                        results.Add(false);
                    }
                }
                return results;
            }
            else if (typeof(DomainEntity1) == typeof(RecordDto)
                || typeof(DomainEntity1) == typeof(PrescriptionDto)
                || typeof(DomainEntity1) == typeof(MedicineDto)
                || typeof(DomainEntity1) == typeof(CompanyDto))
            {
                var results = new List<bool>();
                foreach (var item in entity)
                {
                    results.Add (await _dbGeneric1.DeleteEntityDeepAsync(item));
                }
                return results;
            }
            else
            {
                return new List<bool>();
            }
        }

        public async Task<List<bool>> DeleteRangeEntitiesSoftAsync(List<DomainEntity1> entity)
        {
            if (typeof(DomainEntity1) == typeof(ApplicationUserDto))
            {
                var results = new List<bool>();
                foreach (var item in entity)
                {
                    var result = await _aplicationUserRepository.DeleteApplicationUserSoftAsync((ApplicationUserDto)(object)item);
                    if (result.Succeeded)
                    {
                        results.Add(true);
                    }
                    else
                    {
                        results.Add(true);
                    }
                }
                return results;
            }
            else if (typeof(DomainEntity1) == typeof(RecordDto)
                || typeof(DomainEntity1) == typeof(PrescriptionDto)
                || typeof(DomainEntity1) == typeof(MedicineDto)
                || typeof(DomainEntity1) == typeof(CompanyDto))
            {
                var results = new List<bool>();
                foreach (var item in entity)
                {
                    results.Add(await _dbGeneric1.DeleteEntitySoftAsync(item));
                }
                return results;
            }
            else
            {
                return new List<bool>();
            }
        }

        public async Task<List<DomainEntity1>> FindAllEntitiesAsync(List<int> entityId, bool active = true)
        {
            if (typeof(DomainEntity1) == typeof(ApplicationUserDto))
            {
                return (List<DomainEntity1>)(object)await _aplicationUserRepository.FindAllApplicationUserAsync(entityId, active);
            }
            else if (typeof(DomainEntity1) == typeof(RecordDto)
                || typeof(DomainEntity1) == typeof(PrescriptionDto)
                || typeof(DomainEntity1) == typeof(MedicineDto)
                || typeof(DomainEntity1) == typeof(CompanyDto))
            {
                return (List<DomainEntity1>)(object)await _dbGeneric1.FindAllEntitiesAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<DomainEntity1> FindEntityAsync(int entityId, bool active = true)
        {
            if (typeof(DomainEntity1) == typeof(ApplicationUserDto))
            {
                return (DomainEntity1)(object)await _aplicationUserRepository.FindApplicationUserAsync(entityId, active);
            }
            else if (typeof(DomainEntity1) == typeof(RecordDto)
                || typeof(DomainEntity1) == typeof(PrescriptionDto)
                || typeof(DomainEntity1) == typeof(MedicineDto)
                || typeof(DomainEntity1) == typeof(CompanyDto))
            {
                return (DomainEntity1)(object)await _dbGeneric1.FindEntityAsync(entityId);
            }
            else
            {
                return (DomainEntity1)(object)null;
            }
        }

        public async Task<DomainEntity1> FindEntityClaimsAsync(ClaimsPrincipal claimsPrincipal)
        {
            if (typeof(DomainEntity1) == typeof(ApplicationUserDto))
            {
                return (DomainEntity1)(object)await _aplicationUserRepository.FindApplicationUserAsync(claimsPrincipal);
            }
            else
            {
                return (DomainEntity1)(object)null;
            }
        }

        public async Task<DomainEntity1> FindEntityByEmailAsync(string email)
        {
            if (typeof(DomainEntity1) == typeof(ApplicationUserDto))
            {
                return (DomainEntity1)(object)await _aplicationUserRepository.FindApplicationUserByEmailAsync(email);
            }
            else
            {
                return (DomainEntity1)(object)null;
            }
        }

        public async Task<List<DomainEntity1>> GetAllEntitiesAsync(bool active = true, string userRole = "")///review
        {
            if (typeof(DomainEntity1) == typeof(ApplicationUserDto))
            {
                return (List<DomainEntity1>)(object)await _aplicationUserRepository.GetAllApplicationUsersAsync(userRole, active);
            }
            else if (typeof(DomainEntity1) == typeof(RecordDto)
                || typeof(DomainEntity1) == typeof(PrescriptionDto)
                || typeof(DomainEntity1) == typeof(MedicineDto)
                || typeof(DomainEntity1) == typeof(CompanyDto))
            {
                return (List<DomainEntity1>)(object)await _dbGeneric1.GetAllEntitiesAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<DomainEntity1> GetEntityAsync(int entityId, bool active = true, string userRole = "")// review UserRoel for application user + avtive & deactive filters
        {
            if (typeof(DomainEntity1) == typeof(ApplicationUserDto))
            {
                var result = await _aplicationUserRepository.GetApplicationUserAsync(entityId, userRole, active);
                var t = (DomainEntity1)(object)result;
                return t;
            }
            else if (typeof(DomainEntity1) == typeof(RecordDto)
                || typeof(DomainEntity1) == typeof(PrescriptionDto)
                || typeof(DomainEntity1) == typeof(MedicineDto)
                || typeof(DomainEntity1) == typeof(CompanyDto))
            {
                return (DomainEntity1)(object)await _dbGeneric1.GetEntityAsync(entityId);
            }
            else
            {
                return (DomainEntity1)(object)null;
            }
        }

        public async Task<bool> UpdateEntityAsync(DomainEntity1 entity)
        {
            if (typeof(DomainEntity1) == typeof(ApplicationUserDto))
            {
                var result = await _aplicationUserRepository.UpdateApplicationUserAsync((ApplicationUserDto)(object)entity);
                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (typeof(DomainEntity1) == typeof(RecordDto)
                || typeof(DomainEntity1) == typeof(PrescriptionDto)
                || typeof(DomainEntity1) == typeof(MedicineDto)
                || typeof(DomainEntity1) == typeof(CompanyDto))
            {
                return await _dbGeneric1.UpdateEntityAsync(entity);
            }
            else
            {
                return false;
            }
        }

        public async Task<List<bool>> UpdateRangeEntitiesAsync(List<DomainEntity1> entity)
        {
            if (typeof(DomainEntity1) == typeof(ApplicationUserDto))
            {
                var results = new List<bool>();
                foreach (var item in entity)
                {
                    var result = await _aplicationUserRepository.UpdateApplicationUserAsync((ApplicationUserDto)(object)item);
                    if (result.Succeeded)
                    {
                        results.Add(true);
                    }
                    else
                    {
                        results.Add(false);
                    }
                }
                return results;
            }
            else if (typeof(DomainEntity1) == typeof(RecordDto)
                || typeof(DomainEntity1) == typeof(PrescriptionDto)
                || typeof(DomainEntity1) == typeof(MedicineDto)
                || typeof(DomainEntity1) == typeof(CompanyDto))
            {
                var results = new List<bool>();
                foreach (var item in entity)
                {
                    results.Add(await _dbGeneric1.UpdateEntityAsync(item));
                }
                return results;
            }
            else
            {
                return new List<bool>();
            }
        }
    }
}
