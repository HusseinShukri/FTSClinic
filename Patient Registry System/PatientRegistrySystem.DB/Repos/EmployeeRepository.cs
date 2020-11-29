using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.DB.Roles;
using PatientRegistrySystem.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public EmployeeRepository(UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public Task<IdentityResult> CreateEntityAsync(ApplicationUserDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateEntityAsync(ApplicationUserDto applicationUser, string Password)
        {
            var applicationUserEmployee = _mapper.Map<ApplicationUser>(applicationUser);
            applicationUserEmployee.User.Employee = _mapper.Map<List<Employee>>(applicationUser.User.Employee);
            foreach (var employee in applicationUserEmployee.User.Employee)
            {
                employee.DoctorId = employee.Doctor.DoctorId;
                employee.Doctor = null;
            }
            applicationUserEmployee.Id = Guid.NewGuid().ToString();
            applicationUserEmployee.User.ApplicationUserId = applicationUserEmployee.Id;
            var result = await _userManager.CreateAsync(applicationUserEmployee, Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(applicationUserEmployee, UserRoles.Employee);
            }
            return result;
        }

        public Task<bool> DeleteEntityDeepAsync(IdentityResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEntityShallowAsync(IdentityResult entity)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> FindEntitySallowAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<List<IdentityResult>> GetAllShallowAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> GetIdShallowAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEntity(IdentityResult entity)
        {
            throw new NotImplementedException();
        }
    }
}
