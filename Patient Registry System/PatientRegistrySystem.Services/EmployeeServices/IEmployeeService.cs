using PatientRegistrySystem.DB.Models.DbModels;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        Task<List<ApplicationUserDto>> GetAllEmployeeAsync();
        Task<ApplicationUserDto> GetEmployeeAsync(int userId);
        Task<ApplicationUserDto> FindEmployeeUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<bool> CreateEmployeeAsync(ApplicationUserCreateModel model);
        Task<bool> UpdateEmployeeAsync(ApplicationUserDto applicationUser);
        Task<bool> DeleteEmployeeSoftAsync(ClaimsPrincipal claimsPrincipal);
        Task<bool> DeleteEmployeeDeepAsync(ClaimsPrincipal claimsPrincipal);
    }
}
