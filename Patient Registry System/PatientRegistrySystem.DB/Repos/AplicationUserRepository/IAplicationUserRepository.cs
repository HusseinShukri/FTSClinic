using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.DB.Models;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.AplicationUserRepository
{
    public interface IAplicationUserRepository
    {
        Task<List<ApplicationUserDto>> GetAllApplicationUsersAsync(string userRoles);
        Task<ApplicationUserDto> GetApplicationUserAsync(int userId, string userRoles);
        Task<ApplicationUserDto> FindApplicationUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<IdentityResult> CreateApplicationUserAsync(ApplicationUser applicationUser, string Password);
        Task<IdentityResult> AddToRoleToApplicationUserAsync(ApplicationUser applicationUser, string userRoles);
        Task<IdentityResult> UpdateApplicationUserAsync(ApplicationUser applicationUser);
        Task<IdentityResult> DeleteApplicationUserSoftAsync(ApplicationUser applicationUser);
        Task<IdentityResult> DeleteApplicationUserDeepAsync(ApplicationUser applicationUser);
    }
}
