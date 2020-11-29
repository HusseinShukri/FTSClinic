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
    public class DoctorRepository : IDoctorRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public DoctorRepository(UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public Task<IdentityResult> CreateEntityAsync(ApplicationUserDto applicationUser)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateEntityAsync(ApplicationUserDto applicationUser, string Password)
        {
            var applicationUserDoctor = _mapper.Map<ApplicationUser>(applicationUser);
            applicationUserDoctor.User.Doctor = _mapper.Map<List<Doctor>>(applicationUser.User.Doctor);
            applicationUserDoctor.Id = Guid.NewGuid().ToString();
            applicationUserDoctor.User.ApplicationUserId = applicationUserDoctor.Id;
            var result = await _userManager.CreateAsync(applicationUserDoctor, Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(applicationUserDoctor, UserRoles.Doctor);
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
