using PatientRegistrySystem.DB.Models.DbModels;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services.DoctorServices
{
    public interface IDoctorService
    {
        Task<List<ApplicationUserDto>> GetAllDoctorAsync();
        Task<ApplicationUserDto> GetDoctorAsync(int userId);
        Task<ApplicationUserDto> FindDoctorUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<bool> CreateDoctorAsync(ApplicationUserCreateModel model);
        Task<bool> UpdateDoctorAsync(ApplicationUserDto applicationUser);
        Task<bool> DeleteDoctorSoftAsync(ClaimsPrincipal claimsPrincipal);
        Task<bool> DeleteDoctorDeepAsync(ClaimsPrincipal claimsPrincipal);
    }
}
