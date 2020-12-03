using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.DoctorRepository
{
    public interface IDoctorRepository
    {
        Task<List<ApplicationUserDto>> GetAllDoctorAsync();
        Task<ApplicationUserDto> GetDoctorAsync(int userId);
        Task<ApplicationUserDto> FindDoctorUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<IdentityResult> CreateDoctorAsync(ApplicationUserDto applicationUser, string Password);
        Task<IdentityResult> UpdateDoctorAsync(ApplicationUserDto applicationUser);
        Task<IdentityResult> DeleteDoctorSoftAsync(ApplicationUserDto applicationUser);
        Task<IdentityResult> DeleteDoctorDeepAsync(ApplicationUserDto applicationUser);
    }
}
