using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.DB.Repos.EmployeeRepository;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IdentityResult> CreateEmployeeAsync(ApplicationUserDto applicationUser, string Password)
        {
            return await _employeeRepository.CreateEmployeeAsync(applicationUser, Password);
        }

        public async Task<IdentityResult> DeleteEmployeeDeepAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _employeeRepository.DeleteEmployeeDeepAsync(await _employeeRepository.FindEmployeeUserAsync(claimsPrincipal));
        }

        public async Task<IdentityResult> DeleteEmployeeSoftAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _employeeRepository.DeleteEmployeeSoftAsync(await _employeeRepository.FindEmployeeUserAsync(claimsPrincipal));
        }

        public async Task<ApplicationUserDto> FindEmployeeUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _employeeRepository.FindEmployeeUserAsync(claimsPrincipal);
        }

        public async Task<List<ApplicationUserDto>> GetAllEmployeeAsync()
        {
            return await _employeeRepository.GetAllEmployeeAsync();
        }

        public async Task<ApplicationUserDto> GetEmployeeAsync(int userId)
        {
            return await _employeeRepository.GetEmployeeAsync(userId);
        }

        public async Task<IdentityResult> UpdateEmployeeAsync(ApplicationUserDto applicationUser)
        {
            return await _employeeRepository.UpdateEmployeeAsync(applicationUser);
        }
    }

}
