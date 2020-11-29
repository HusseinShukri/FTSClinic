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
    public class AdminRepository : IAdminRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AdminRepository(UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> CreateEntityAsync(ApplicationUserDto applicationUser, string Password)
        {
            var applicationUserAdmin = _mapper.Map<ApplicationUser>(applicationUser);
            applicationUserAdmin.Id= Guid.NewGuid().ToString();
            applicationUserAdmin.User.ApplicationUserId= applicationUserAdmin.Id;
            var result = await _userManager.CreateAsync(applicationUserAdmin, Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(applicationUserAdmin, UserRoles.Admin);
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
