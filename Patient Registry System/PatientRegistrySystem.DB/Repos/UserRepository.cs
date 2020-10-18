using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientRegistrySystem.DB.Contexts;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.DB.Repos;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly PatientContext _patientContext;
        private readonly IRecordRepository _recordRepository;
        private readonly IMapper _mapper;

        public UserRepository(PatientContext patientContext, IRecordRepository recordRepository, IMapper mapper)
        {
            _patientContext = patientContext;
            _recordRepository = recordRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserWithIdDto>> GetAllShallowAsync()
        {
            return _mapper.Map<UserWithIdDto[]>(await _patientContext.User
                    .Include(e => e.Employee)
                    .Include(d => d.Doctor)
                    .Include(ur => ur.UserRole).ThenInclude(rr => rr.Role)
                    .Include(r => r.Record).ThenInclude(rr => rr.Prescription).ThenInclude(m => m.Medicines).ThenInclude(c => c.Company)
                    .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(d => d.Doctor).ThenInclude(u => u.User)
                    .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(u => u.User)
                    .Include(d => d.Record).ThenInclude(dd => dd.Doctor)
                    .Where(u => u.IsDeleted == false)
                    .ToArrayAsync());
        }

        public async Task<UserWithIdDto> GetIdShallowAsync(int entityId)
        {
            var map = _mapper.Map<UserWithIdDto>(await _patientContext.User
                    .Include(e => e.Employee)
                    .Include(d => d.Doctor)
                    .Include(ur => ur.UserRole).ThenInclude(rr => rr.Role)
                    .Include(r => r.Record).ThenInclude(rr => rr.Prescription).ThenInclude(m => m.Medicines).ThenInclude(c => c.Company)
                    .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(d => d.Doctor).ThenInclude(u => u.User)
                    .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(u => u.User)
                    .Include(d => d.Record).ThenInclude(dd => dd.Doctor)
                    .Where(u => u.IsDeleted == false)
                    .FirstOrDefaultAsync(u => u.UserId == entityId));
            return map;
        }

        public async Task<bool> UpdateEntity(UserWithIdDto entity)
        {
            var userEntity = _mapper.Map<User>(entity);
            _patientContext.User.Update(userEntity);
            return await this.SaveChangesAsync();
        }

        public async Task<UserWithIdDto> CreateEntityAsync(UserWithIdDto entity)
        {
            var userEntity = _mapper.Map<User>(entity);
            await _patientContext.User.AddAsync(userEntity);
            await this.SaveChangesAsync();
            return _mapper.Map<UserWithIdDto>(userEntity);
        }

        public async Task<bool> DeleteEntityDeepAsync(UserWithIdDto entity)
        {
            var userEntity = _mapper.Map<User>(entity);
            var findrecord = await _recordRepository.FindEntitySallowAsync(userEntity.UserId);
            if (findrecord != null) { await _recordRepository.DeleteEntityDeepAsync(findrecord); }
            _patientContext.User.Remove(userEntity);
            return await this.SaveChangesAsync();
        }

        public async Task<bool> DeleteEntityShallowAsync(UserWithIdDto entity)
        {
            var userEntity = _mapper.Map<User>(entity);
            userEntity.IsDeleted = true;
            _patientContext.User.Update(userEntity);
            return await this.SaveChangesAsync();
        }

        public async Task<UserWithIdDto> FindEntitySallowAsync(int entityId)
        {
            return _mapper.Map<UserWithIdDto>(await _patientContext.User.AsNoTracking()
                .Where(u => u.IsDeleted == false)
                .FirstOrDefaultAsync(u => u.UserId == entityId));
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _patientContext.SaveChangesAsync() > 0);
        }
    }
}
