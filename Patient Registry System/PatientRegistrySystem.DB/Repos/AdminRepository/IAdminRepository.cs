using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.AdminRepository
{
    public interface IAdminRepository
    {
        Task<List<ApplicationUserDto>> GetAllAdminAsync();
        Task<ApplicationUserDto> GetAdminAsync(int userId);
        Task<ApplicationUserDto> FindAdminUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<IdentityResult> CreateAdminAsync(ApplicationUserDto applicationUser, string Password);
        Task<IdentityResult> UpdateAdminAsync(ApplicationUserDto applicationUser);
        Task<IdentityResult> DeleteAdminSoftAsync(ApplicationUserDto applicationUser);
        Task<IdentityResult> DeleteAdminDeepAsync(ApplicationUserDto applicationUser);
    }
}
