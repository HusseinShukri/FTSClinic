using PatientRegistrySystem.DB.Models.DbModels;
using PatientRegistrySystem.DB.Models.IdentityModels;
using PatientRegistrySystem.DB.Repos.GenericRepository;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Roles;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services.PatientServices
{
    public class PatientService : IPatientService
    {
        private readonly IGenericRepository<ApplicationUser, ApplicationUserDto, ApplicationUserCreateModel> _genericRepository;

        public PatientService(IGenericRepository<ApplicationUser, ApplicationUserDto, ApplicationUserCreateModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<bool> CreatePatientAsync(ApplicationUserCreateModel model)
        {
            model.UserRole = UserRoles.Patient;
            return await _genericRepository.CreateEntityAsync(model);
        }

        public async Task<bool> DeletePatientDeepAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _genericRepository.DeleteEntityHardAsync(await _genericRepository.FindEntityClaimsAsync(claimsPrincipal));
        }

        public async Task<bool> DeletePatientSoftAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _genericRepository.DeleteEntitySoftAsync(await _genericRepository.FindEntityClaimsAsync(claimsPrincipal));
        }

        public async Task<ApplicationUserDto> FindPatientUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _genericRepository.FindEntityClaimsAsync(claimsPrincipal);
        }

        public async Task<List<ApplicationUserDto>> GetAllPatientAsync()
        {
            return await _genericRepository.GetAllEntitiesAsync(true, UserRoles.Patient);
        }

        public async Task<ApplicationUserDto> GetPatientAsync(int userId)
        {
            return await _genericRepository.GetEntityAsync(userId, true, UserRoles.Patient);
        }

        public async Task<bool> UpdatePatientAsync(ApplicationUserDto applicationUser)
        {
            return await _genericRepository.UpdateEntityAsync(applicationUser);
        }
    }
}
