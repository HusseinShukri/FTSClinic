using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using PatientRegistrySystem.Domain.Hellper;
using PatientRegistrySystem.DB.Models;

namespace PatientRegistrySystem.DB.Repos.AplicationUserRepository
{
    public class AplicationUserRepository : IAplicationUserRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public AplicationUserRepository(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<ApplicationUserDto>> GetAllApplicationUsersAsync(string userRoles = "")
        {
            if (userRoles.Equals(""))
            {
                return _mapper.Map<List<ApplicationUserDto>>
                 (await _userManager.Users.AsNoTracking()
                     .Include(e => e.Employee)
                     .Include(d => d.Doctor)
                     .Include(r => r.Record).ThenInclude(rr => rr.Prescription).ThenInclude(m => m.Medicines).ThenInclude(c => c.Company)
                     .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(d => d.Doctor).ThenInclude(u => u.ApplicationUser)
                     .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(u => u.ApplicationUser)
                     .Include(d => d.Record).ThenInclude(dd => dd.Doctor)
                     .Where(user => (user.IsDeleted == false) && FindRole(user, userRoles).Result)
                     .ToListAsync());
            }
            else if (userRoles.IsValedRole())
            {
                return _mapper.Map<List<ApplicationUserDto>>
                 (await _userManager.Users.AsNoTracking()
                     .Include(e => e.Employee)
                     .Include(d => d.Doctor)
                     .Include(r => r.Record).ThenInclude(rr => rr.Prescription).ThenInclude(m => m.Medicines).ThenInclude(c => c.Company)
                     .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(d => d.Doctor).ThenInclude(u => u.ApplicationUser)
                     .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(u => u.ApplicationUser)
                     .Include(d => d.Record).ThenInclude(dd => dd.Doctor)
                     .Where(user => (user.IsDeleted == false) && FindRole(user, userRoles).Result)
                     .ToListAsync());
            }
            else
            {
                throw new System.Exception("Invaled Role Name");
            }
        }

        public async Task<ApplicationUserDto> GetApplicationUserAsync(int userId, string userRoles = "")
        {
            if (userRoles.Equals(""))
            {
                return _mapper.Map<ApplicationUserDto>
                 (await _userManager.Users.AsNoTracking()
                     .Include(e => e.Employee)
                     .Include(d => d.Doctor)
                     .Include(r => r.Record).ThenInclude(rr => rr.Prescription).ThenInclude(m => m.Medicines).ThenInclude(c => c.Company)
                     .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(d => d.Doctor).ThenInclude(u => u.ApplicationUser)
                     .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(u => u.ApplicationUser)
                     .Include(d => d.Record).ThenInclude(dd => dd.Doctor)
                     .Where(user => (user.IsDeleted == false) && FindRole(user, userRoles).Result)
                     .FirstOrDefaultAsync(u => u.Id == userId));
            }
            else if (userRoles.IsValedRole())
            {
                return _mapper.Map<ApplicationUserDto>
                 (await _userManager.Users.AsNoTracking()
                     .Include(e => e.Employee)
                     .Include(d => d.Doctor)
                     .Include(r => r.Record).ThenInclude(rr => rr.Prescription).ThenInclude(m => m.Medicines).ThenInclude(c => c.Company)
                     .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(d => d.Doctor).ThenInclude(u => u.ApplicationUser)
                     .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(u => u.ApplicationUser)
                     .Include(d => d.Record).ThenInclude(dd => dd.Doctor)
                     .Where(user => (user.IsDeleted == false) && FindRole(user, userRoles).Result)
                     .FirstOrDefaultAsync(u => u.Id == userId));
            }
            else
            {
                throw new System.Exception("Invaled Role Name");
            }
        }

        private async Task<bool> FindRole(ApplicationUser user, string userRoles)
        {
            return await _userManager.IsInRoleAsync(user, userRoles);
        }

        public async Task<ApplicationUserDto> FindApplicationUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return _mapper.Map<ApplicationUserDto>(await _userManager.GetUserAsync(claimsPrincipal));
        }

        public async Task<IdentityResult> CreateApplicationUserAsync(ApplicationUser applicationUser, string Password)
        {
            return await _userManager.CreateAsync(applicationUser, Password);
        }

        public async Task<IdentityResult> AddToRoleToApplicationUserAsync(ApplicationUser applicationUser, string userRoles)
        {
            return await _userManager.AddToRoleAsync(applicationUser, userRoles);
        }

        public async Task<IdentityResult> UpdateApplicationUserAsync(ApplicationUser applicationUser)
        {
            return await _userManager.UpdateAsync(applicationUser);
        }

        public async Task<IdentityResult> DeleteApplicationUserDeepAsync(ApplicationUser applicationUser)
        {
            return await _userManager.DeleteAsync(applicationUser);
        }

        public async Task<IdentityResult> DeleteApplicationUserSoftAsync(ApplicationUser applicationUser)
        {
            applicationUser.IsDeleted = true;
            return await _userManager.UpdateAsync(applicationUser);
        }
    }
}
