using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<List<ApplicationUserDto>> GetAllEmployeeAsync();
        Task<ApplicationUserDto> GetEmployeeAsync(int userId);
        Task<ApplicationUserDto> FindEmployeeUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<IdentityResult> CreateEmployeeAsync(ApplicationUserDto applicationUser, string Password);
        Task<IdentityResult> UpdateEmployeeAsync(ApplicationUserDto applicationUser);
        Task<IdentityResult> DeleteEmployeeSoftAsync(ApplicationUserDto applicationUser);
        Task<IdentityResult> DeleteEmployeeDeepAsync(ApplicationUserDto applicationUser);
    }
}
