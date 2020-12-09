using PatientRegistrySystem.DB.Models.DbModels;
using PatientRegistrySystem.DB.Models.IdentityModels;
using PatientRegistrySystem.DB.Repos.GenericRepository;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Roles;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<ApplicationUser, ApplicationUserDto, ApplicationUserCreateModel> _genericRepository;

        public EmployeeService(IGenericRepository<ApplicationUser, ApplicationUserDto, ApplicationUserCreateModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<bool> CreateEmployeeAsync(ApplicationUserCreateModel model)
        {
            model.UserRole = UserRoles.Employee;
            return await _genericRepository.CreateEntityAsync(model);
        }

        public async Task<bool> DeleteEmployeeDeepAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _genericRepository.DeleteEntityHardAsync(await _genericRepository.FindEntityClaimsAsync(claimsPrincipal));
        }

        public async Task<bool> DeleteEmployeeSoftAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _genericRepository.DeleteEntitySoftAsync(await _genericRepository.FindEntityClaimsAsync(claimsPrincipal));
        }

        public async Task<ApplicationUserDto> FindEmployeeUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _genericRepository.FindEntityClaimsAsync(claimsPrincipal);
        }

        public async Task<List<ApplicationUserDto>> GetAllEmployeeAsync()
        {
            return await _genericRepository.GetAllEntitiesAsync(true, UserRoles.Employee);
        }

        public async Task<ApplicationUserDto> GetEmployeeAsync(int userId)
        {
            return await _genericRepository.GetEntityAsync(userId, true, UserRoles.Employee);
        }

        public async Task<bool> UpdateEmployeeAsync(ApplicationUserDto applicationUser)
        {
            return await _genericRepository.UpdateEntityAsync(applicationUser);
        }
    }
}
