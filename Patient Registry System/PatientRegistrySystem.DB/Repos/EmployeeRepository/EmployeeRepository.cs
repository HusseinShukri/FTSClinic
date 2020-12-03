using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.DB.Models;
using PatientRegistrySystem.DB.Repos.AplicationUserRepository;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Roles;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMapper _mapper;
        private readonly IAplicationUserRepository _aplicationUserRepository;

        public EmployeeRepository(IMapper mapper, IAplicationUserRepository aplicationUserRepository)
        {
            _mapper = mapper;
            _aplicationUserRepository = aplicationUserRepository;
        }

        public async Task<IdentityResult> CreateEmployeeAsync(ApplicationUserDto applicationUser, string Password)
        {
            var applicationUserEmployee = _mapper.Map<ApplicationUser>(applicationUser);
            var result = _aplicationUserRepository.CreateApplicationUserAsync(applicationUserEmployee, Password);
            if (result.Result.Succeeded)
            {
                await _aplicationUserRepository.AddToRoleToApplicationUserAsync(applicationUserEmployee, UserRoles.Employee);
            }
            return result.Result;
        }

        public async Task<IdentityResult> DeleteEmployeeDeepAsync(ApplicationUserDto applicationUser)
        {
            return await _aplicationUserRepository.DeleteApplicationUserDeepAsync(_mapper.Map<ApplicationUser>(applicationUser));
        }

        public async Task<IdentityResult> DeleteEmployeeSoftAsync(ApplicationUserDto applicationUser)
        {
            return await _aplicationUserRepository.DeleteApplicationUserSoftAsync(_mapper.Map<ApplicationUser>(applicationUser));
        }

        public async Task<ApplicationUserDto> FindEmployeeUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await _aplicationUserRepository.FindApplicationUserAsync(claimsPrincipal);
        }

        public async Task<ApplicationUserDto> GetEmployeeAsync(int userId)
        {
            return await _aplicationUserRepository.GetApplicationUserAsync(userId, UserRoles.Employee);
        }

        public async Task<List<ApplicationUserDto>> GetAllEmployeeAsync()
        {
            return await _aplicationUserRepository.GetAllApplicationUsersAsync(UserRoles.Employee);
        }

        public async Task<IdentityResult> UpdateEmployeeAsync(ApplicationUserDto applicationUser)
        {
            return await _aplicationUserRepository.UpdateApplicationUserAsync(_mapper.Map<ApplicationUser>(applicationUser));
        }
    }
}

