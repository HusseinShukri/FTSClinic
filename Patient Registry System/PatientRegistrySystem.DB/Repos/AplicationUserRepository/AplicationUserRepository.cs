using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PatientRegistrySystem.DB.Contexts;
using PatientRegistrySystem.DB.Models.DbModels;
using PatientRegistrySystem.DB.Models.IdentityModels;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Hellper;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.AplicationUserRepository
{
    public class AplicationUserRepository : IAplicationUserRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationIdentityDbContext _context;

        public AplicationUserRepository(IMapper mapper, UserManager<ApplicationUser> userManager
            , ApplicationIdentityDbContext context)
        {
            _mapper = mapper;
            _userManager = userManager;
            _context = context;
        }

        public async Task<List<ApplicationUserDto>> GetAllApplicationUsersAsync(string userRoles = "", bool active = true)
        {
            if (active)
            {
                if (userRoles.Equals(""))
                {
                    return _mapper.Map<List<ApplicationUserDto>>
                     (await _context.Users
                         .AsNoTracking()
                         .Include(e => e.Employee)
                         .Include(d => d.Doctor)
                         .Include(r => r.Record).ThenInclude(rr => rr.Prescription).ThenInclude(m => m.Medicines).ThenInclude(c => c.Company)
                         .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(d => d.Doctor).ThenInclude(u => u.ApplicationUser)
                         .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(u => u.ApplicationUser)
                         .Include(d => d.Record).ThenInclude(dd => dd.Doctor)
                         .Where(user => user.IsDeleted == false)
                         .ToListAsync());
                }
                else if (userRoles.IsValedRole())
                {
                    return _mapper.Map<List<ApplicationUserDto>>(_context.Users
                         .AsNoTracking()
                         .Include(e => e.Employee)
                         .Include(d => d.Doctor)
                         .Include(r => r.Record).ThenInclude(rr => rr.Prescription).ThenInclude(m => m.Medicines).ThenInclude(c => c.Company)
                         .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(d => d.Doctor).ThenInclude(u => u.ApplicationUser)
                         .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(u => u.ApplicationUser)
                         .Include(d => d.Record).ThenInclude(dd => dd.Doctor)
                         .Include(e => e.UserRoles).ThenInclude(r => r.Role)
                         .Where(user => user.IsDeleted == false)
                         .Where(user => user.UserRoles.Select(e => e.Role.Name.Equals(userRoles)).Any())
                         .ToList());
                }
                else
                {
                    return null;
                }
            }
            else
            {
                if (userRoles.Equals(""))
                {
                    return _mapper.Map<List<ApplicationUserDto>>
                     (await _context.Users.AsNoTracking()
                         .Include(e => e.Employee)
                         .Include(d => d.Doctor)
                         .Include(r => r.Record).ThenInclude(rr => rr.Prescription).ThenInclude(m => m.Medicines).ThenInclude(c => c.Company)
                         .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(d => d.Doctor).ThenInclude(u => u.ApplicationUser)
                         .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(u => u.ApplicationUser)
                         .Include(d => d.Record).ThenInclude(dd => dd.Doctor)
                         .Where(user => user.IsDeleted == true)
                         .ToListAsync());
                }
                else if (userRoles.IsValedRole())
                {
                    return _mapper.Map<List<ApplicationUserDto>>
                     (await _context.Users.AsNoTracking()
                         .Include(e => e.Employee)
                         .Include(d => d.Doctor)
                         .Include(r => r.Record).ThenInclude(rr => rr.Prescription).ThenInclude(m => m.Medicines).ThenInclude(c => c.Company)
                         .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(d => d.Doctor).ThenInclude(u => u.ApplicationUser)
                         .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(u => u.ApplicationUser)
                         .Include(d => d.Record).ThenInclude(dd => dd.Doctor)
                         .Where(user => user.UserRoles.Select(e => e.Role.Name.Equals(userRoles)).Any())
                         .ToListAsync());
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<ApplicationUserDto> GetApplicationUserAsync(int userId, string userRoles = "", bool active = true)
        {
            if (active)
            {
                if (userRoles.Equals(""))
                {
                    return _mapper.Map<ApplicationUserDto>(_context.Users.AsNoTracking()
                         .Include(e => e.Employee)
                         .Include(d => d.Doctor)
                         .Include(r => r.Record).ThenInclude(rr => rr.Prescription).ThenInclude(m => m.Medicines).ThenInclude(c => c.Company)
                         .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(d => d.Doctor).ThenInclude(u => u.ApplicationUser)
                         .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(u => u.ApplicationUser)
                         .Include(d => d.Record).ThenInclude(dd => dd.Doctor)
                         .AsEnumerable()
                         .Where(user => user.IsDeleted == false)
                         .FirstOrDefault(u => u.Id == userId)); ;
                }
                else if (userRoles.IsValedRole())
                {
                    return _mapper.Map<ApplicationUserDto>
                     (await _context.Users.AsNoTracking()
                         .Include(e => e.Employee)
                         .Include(d => d.Doctor)
                         .Include(r => r.Record).ThenInclude(rr => rr.Prescription).ThenInclude(m => m.Medicines).ThenInclude(c => c.Company)
                         .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(d => d.Doctor).ThenInclude(u => u.ApplicationUser)
                         .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(u => u.ApplicationUser)
                         .Include(d => d.Record).ThenInclude(dd => dd.Doctor)
                         .Where(user => (user.IsDeleted == false) )
                         .Where(user => user.UserRoles.Select(e => e.Role.Name.Equals(userRoles)).Any())
                         .FirstOrDefaultAsync(u => u.Id == userId));
                }
                else
                {
                    return null;
                }
            }
            else
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
                         .Where(user => user.IsDeleted == true)
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
                         .Where(user => user.IsDeleted == true)
                         .Where(user => user.UserRoles.Select(e => e.Role.Name.Equals(userRoles)).Any())
                         .FirstOrDefaultAsync(u => u.Id == userId));
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<ApplicationUserDto> FindApplicationUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return _mapper.Map<ApplicationUserDto>(await _userManager.GetUserAsync(claimsPrincipal));
        }

        public async Task<ApplicationUserDto> FindApplicationUserByEmailAsync(string email)
        {
            return _mapper.Map<ApplicationUserDto>(await _userManager.FindByEmailAsync(email));
        }

        public async Task<ApplicationUserDto> FindApplicationUserAsync(int entityId, bool active = true)
        {
            if (active)
            {
                return _mapper.Map<ApplicationUserDto>(await _userManager.Users.FirstOrDefaultAsync(e => (e.Id == entityId) && (e.IsDeleted == false)));
            }
            else
            {
                return _mapper.Map<ApplicationUserDto>(await _userManager.Users.FirstOrDefaultAsync(e => (e.Id == entityId) && (e.IsDeleted == true)));
            }
        }

        public async Task<List<ApplicationUserDto>> FindAllApplicationUserAsync(List<int> entityId, bool active = true)
        {
            if (active)
            {
                List<ApplicationUser> result = new List<ApplicationUser>();
                foreach (var item in entityId)
                {
                    result.Add(await _userManager.Users.FirstOrDefaultAsync(e => (e.Id == item) && (e.IsDeleted == false)));
                }
                return _mapper.Map<List<ApplicationUserDto>>(result);
            }
            else
            {
                List<ApplicationUser> result = new List<ApplicationUser>();
                foreach (var item in entityId)
                {
                    result.Add(await _userManager.Users.FirstOrDefaultAsync(e => (e.Id == item) && (e.IsDeleted == true)));
                }
                return _mapper.Map<List<ApplicationUserDto>>(result);
            }
        }

        public async Task<IdentityResult> CreateApplicationUserAsync(ApplicationUserCreateModel model)
        {
            var result = await _userManager.CreateAsync(model.ApplicationUser, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(model.ApplicationUser, model.UserRole);
            }
            return result;
        }

        public async Task<List<IdentityResult>> CreateRangeApplicationUserAsync(List<ApplicationUserCreateModel> models)
        {
            var results = new List<IdentityResult>();
            foreach (var model in models)
            {
                var result = await _userManager.CreateAsync(model.ApplicationUser, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(model.ApplicationUser, model.UserRole);
                }
                results.Add(result);
            }
            return results;
        }

        public async Task<IdentityResult> AddToRoleToApplicationUserAsync(ApplicationUserDto applicationUser, string userRoles)
        {
            return await _userManager.AddToRoleAsync(_mapper.Map<ApplicationUser>(applicationUser), userRoles);
        }

        public async Task<IdentityResult> UpdateApplicationUserAsync(ApplicationUserDto applicationUser)
        {
            return await _userManager.UpdateAsync(_mapper.Map<ApplicationUser>(applicationUser));
        }

        public async Task<IdentityResult> DeleteApplicationUserDeepAsync(ApplicationUserDto applicationUser)
        {
            return await _userManager.DeleteAsync(_mapper.Map<ApplicationUser>(applicationUser));
        }

        public async Task<IdentityResult> DeleteApplicationUserSoftAsync(ApplicationUserDto applicationUser)
        {
            applicationUser.IsDeleted = true;
            return await _userManager.UpdateAsync(_mapper.Map<ApplicationUser>(applicationUser));
        }
    }
}
