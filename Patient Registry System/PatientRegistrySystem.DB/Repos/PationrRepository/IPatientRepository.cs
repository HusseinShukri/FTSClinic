using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.PationrRepository
{
    public interface IPatientRepository 
    {
        Task<List<ApplicationUserDto>> GetAllPatientAsync();
        Task<ApplicationUserDto> GetPatientAsync(int userId);
        Task<ApplicationUserDto> FindPatientUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<IdentityResult> CreatePatientAsync(ApplicationUserDto applicationUser, string Password);
        Task<IdentityResult> UpdatePatientAsync(ApplicationUserDto applicationUser);
        Task<IdentityResult> DeletePatientSoftAsync(ApplicationUserDto applicationUser);
        Task<IdentityResult> DeletePatientDeepAsync(ApplicationUserDto applicationUser);
    }
}
