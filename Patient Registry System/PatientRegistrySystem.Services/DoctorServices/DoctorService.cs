using PatientRegistrySystem.DB.Models.DbModels;
using PatientRegistrySystem.DB.Models.IdentityModels;
using PatientRegistrySystem.DB.Repos.GenericRepository;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Roles;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services.DoctorServices
{
    public class DoctorService : IDoctorService
    {
        private readonly IGenericRepository<ApplicationUser, ApplicationUserDto, ApplicationUserCreateModel> _genericRepository;

        public DoctorService(IGenericRepository<ApplicationUser, ApplicationUserDto, ApplicationUserCreateModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<bool> CreateDoctorAsync(ApplicationUserCreateModel model)
        {
            model.UserRole = UserRoles.Doctor;
            return await _genericRepository.CreateEntityAsync(model);
        }

        public async Task<bool> DeleteDoctorDeepAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _genericRepository.DeleteEntityHardAsync(await _genericRepository.FindEntityClaimsAsync(claimsPrincipal));
        }

        public async Task<bool> DeleteDoctorSoftAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _genericRepository.DeleteEntitySoftAsync(await _genericRepository.FindEntityClaimsAsync(claimsPrincipal));
        }

        public async Task<ApplicationUserDto> FindDoctorUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _genericRepository.FindEntityClaimsAsync(claimsPrincipal);
        }

        public async Task<List<ApplicationUserDto>> GetAllDoctorAsync()
        {
            return await _genericRepository.GetAllEntitiesAsync(true, UserRoles.Doctor);
        }

        public async Task<ApplicationUserDto> GetDoctorAsync(int userId)
        {
            return await _genericRepository.GetEntityAsync(userId, true, UserRoles.Doctor);
        }

        public async Task<bool> UpdateDoctorAsync(ApplicationUserDto applicationUser)
        {
            return await _genericRepository.UpdateEntityAsync(applicationUser);
        }
    }
}
