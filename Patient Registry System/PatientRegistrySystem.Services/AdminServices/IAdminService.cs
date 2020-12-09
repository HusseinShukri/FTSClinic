using PatientRegistrySystem.DB.Models.DbModels;
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
        Task<bool> CreateAdminAsync(ApplicationUserCreateModel model);
        Task<bool> UpdateAdminAsync(ApplicationUserDto applicationUser);
        Task<bool> DeleteAdminSoftAsync(ClaimsPrincipal claimsPrincipal);
        Task<bool> DeleteAdminDeepAsync(ClaimsPrincipal claimsPrincipal);
    }
}
