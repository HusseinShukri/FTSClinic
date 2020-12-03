using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services.AdminServices
{
    public interface IAdminService
    {
        Task<List<ApplicationUserDto>> GetAllAdminAsync();
        Task<ApplicationUserDto> GetAdminAsync(int userId);
        Task<ApplicationUserDto> FindAdminUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<IdentityResult> CreateAdminAsync(ApplicationUserDto applicationUser, string Password);
        Task<IdentityResult> UpdateAdminAsync(ApplicationUserDto applicationUser);
        Task<IdentityResult> DeleteAdminSoftAsync(ClaimsPrincipal claimsPrincipal);
        Task<IdentityResult> DeleteAdminDeepAsync(ClaimsPrincipal claimsPrincipal);
    }
}
