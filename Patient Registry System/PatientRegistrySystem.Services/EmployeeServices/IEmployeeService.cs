using Microsoft.AspNetCore.Identity;
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
        Task<IdentityResult> CreateEmployeeAsync(ApplicationUserDto applicationUser, string Password);
        Task<IdentityResult> UpdateEmployeeAsync(ApplicationUserDto applicationUser);
        Task<IdentityResult> DeleteEmployeeSoftAsync(ClaimsPrincipal claimsPrincipal);
        Task<IdentityResult> DeleteEmployeeDeepAsync(ClaimsPrincipal claimsPrincipal);
    }
}
