using PatientRegistrySystem.DB.Models.DbModels;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services.PatientServices
{
    public interface IPatientService
    {
        Task<List<ApplicationUserDto>> GetAllPatientAsync();
        Task<ApplicationUserDto> GetPatientAsync(int userId);
        Task<ApplicationUserDto> FindPatientUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<bool> CreatePatientAsync(ApplicationUserCreateModel model);
        Task<bool> UpdatePatientAsync(ApplicationUserDto applicationUser);
        Task<bool> DeletePatientSoftAsync(ClaimsPrincipal claimsPrincipal);
        Task<bool> DeletePatientDeepAsync(ClaimsPrincipal claimsPrincipal);
    }
}
