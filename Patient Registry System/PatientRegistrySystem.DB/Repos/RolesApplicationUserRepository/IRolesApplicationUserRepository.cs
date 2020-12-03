using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Roles;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.RolesApplicationUserRepository
{
    public interface IRolesApplicationUserRepository
    {
        Task<List<ApplicationUserDto>> GetAllUserRoleAsync(string userRoles);
        Task<ApplicationUserDto> GetUserRoleAsync(int userId, string userRoles);
        Task<ApplicationUserDto> FindUserRoleUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<IdentityResult> CreateUserRoleAsync(ApplicationUserDto applicationUser, string Password, string userRoles);
        Task<IdentityResult> UpdateUserRoleAsync(ApplicationUserDto applicationUser);
        Task<IdentityResult> DeleteUserRoleSoftAsync(ApplicationUserDto applicationUser);
        Task<IdentityResult> DeleteUserRoleDeepAsync(ApplicationUserDto applicationUser);
    }
}
