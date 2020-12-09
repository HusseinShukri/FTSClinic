using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.DB.Models.DbModels;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.AplicationUserRepository
{
    public interface IAplicationUserRepository
    {
        Task<List<ApplicationUserDto>> GetAllApplicationUsersAsync(string userRoles, bool active = true);
        Task<ApplicationUserDto> GetApplicationUserAsync(int userId, string userRoles, bool active = true);

        Task<ApplicationUserDto> FindApplicationUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<ApplicationUserDto> FindApplicationUserAsync(int entityId, bool active = true);
        Task<List<ApplicationUserDto>> FindAllApplicationUserAsync(List<int> entityId, bool active = true);
        Task<ApplicationUserDto> FindApplicationUserByEmailAsync(string email);

        Task<IdentityResult> CreateApplicationUserAsync(ApplicationUserCreateModel model);
        Task<List<IdentityResult>> CreateRangeApplicationUserAsync(List<ApplicationUserCreateModel> models);

        Task<IdentityResult> AddToRoleToApplicationUserAsync(ApplicationUserDto applicationUser, string userRoles);
        Task<IdentityResult> UpdateApplicationUserAsync(ApplicationUserDto applicationUser);

        Task<IdentityResult> DeleteApplicationUserSoftAsync(ApplicationUserDto applicationUser);
        Task<IdentityResult> DeleteApplicationUserDeepAsync(ApplicationUserDto applicationUser);
    }
}
