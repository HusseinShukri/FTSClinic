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
    public class PationtRepository : IPationtRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public PationtRepository(UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> CreateApplicationUser(ApplicationUserDto applicationUser, string Password)
        {
            var applicationUserPatient = _mapper.Map<ApplicationUser>(applicationUser);
            applicationUserPatient.Id = Guid.NewGuid().ToString();
            applicationUserPatient.User.ApplicationUserId = applicationUserPatient.Id;
            var result = await _userManager.CreateAsync(applicationUserPatient, Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(applicationUserPatient, UserRoles.Patient);
            }
            return result;
        }

        public Task<IdentityResult> CreateEntityAsync(ApplicationUserDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteEntityDeepAsync(IdentityResult entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteEntityShallowAsync(IdentityResult entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> FindEntitySallowAsync(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<IdentityResult>> GetAllShallowAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> GetIdShallowAsync(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateEntity(IdentityResult entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
