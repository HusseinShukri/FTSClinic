using PatientRegistrySystem.DB.Models.DbModels;
using PatientRegistrySystem.DB.Models.IdentityModels;
using PatientRegistrySystem.DB.Repos.GenericRepository;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Roles;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services.AdminServices
{
    public class AdminService : IAdminService
    {
        private readonly IGenericRepository<ApplicationUser, ApplicationUserDto, ApplicationUserCreateModel> _genericRepository;

        public AdminService(IGenericRepository<ApplicationUser, ApplicationUserDto, ApplicationUserCreateModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<bool> CreateAdminAsync(ApplicationUserCreateModel model)
        {
            model.UserRole = UserRoles.Admin;
            return await _genericRepository.CreateEntityAsync(model);
        }

        public async Task<bool> DeleteAdminDeepAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _genericRepository.DeleteEntityHardAsync(await _genericRepository.FindEntityClaimsAsync(claimsPrincipal));
        }

        public async Task<bool> DeleteAdminSoftAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _genericRepository.DeleteEntitySoftAsync(await _genericRepository.FindEntityClaimsAsync(claimsPrincipal));
        }

        public async Task<ApplicationUserDto> FindAdminUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _genericRepository.FindEntityClaimsAsync(claimsPrincipal);
        }

        public async Task<List<ApplicationUserDto>> GetAllAdminAsync()
        {
            return await _genericRepository.GetAllEntitiesAsync(true, UserRoles.Admin);
        }

        public async Task<ApplicationUserDto> GetAdminAsync(int userId)
        {
            return await _genericRepository.GetEntityAsync(userId, true, UserRoles.Admin);
        }

        public async Task<bool> UpdateAdminAsync(ApplicationUserDto applicationUser)
        {
            return await _genericRepository.UpdateEntityAsync(applicationUser);
        }
    }
}
