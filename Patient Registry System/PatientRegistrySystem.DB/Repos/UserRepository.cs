using Microsoft.EntityFrameworkCore;
using PatientRegistrySystem.DB.Contexts;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.DB.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly PatientContext _patientContext;
        private readonly IRecordRepository _recordRepository;

        public UserRepository(PatientContext patientContext, IRecordRepository recordRepository)
        {
            _patientContext = patientContext;
            _recordRepository = recordRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _patientContext.User
                    .Include(e => e.Employee)
                    .Include(d => d.Doctor)
                    .Include(ur => ur.UserRole).ThenInclude(rr => rr.Role)
                    .Include(r => r.Record).ThenInclude(rr => rr.Prescription).ThenInclude(m => m.Medicines).ThenInclude(c => c.Company)
                    .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(d => d.Doctor).ThenInclude(u => u.User)
                    .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(u => u.User)
                    .Include(d => d.Record).ThenInclude(dd => dd.Doctor)
                    .ToArrayAsync();
        }

        public async Task<User> GetIdAsync(int entityId)
        {
            return await _patientContext.User
                    .Include(e => e.Employee)
                    .Include(d => d.Doctor)
                    .Include(ur => ur.UserRole).ThenInclude(rr => rr.Role)
                    .Include(r => r.Record).ThenInclude(rr => rr.Prescription).ThenInclude(m => m.Medicines).ThenInclude(c => c.Company)
                    .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(d=>d.Doctor).ThenInclude(u=>u.User)
                    .Include(e => e.Record).ThenInclude(ee => ee.Employee).ThenInclude(u=>u.User)
                    .Include(d => d.Record).ThenInclude(dd => dd.Doctor)
                    .FirstOrDefaultAsync(u => u.UserId == entityId);
        }

        public async Task<User> CreateEntityAsync(User entity)
        {
            await _patientContext.User.AddAsync(entity);
            await this.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateEntity(User entity)
        {
            _patientContext.User.Update(entity);
            return await this.SaveChangesAsync();
        }

        public async Task<bool> DeleteEntityAsync(User entity)
        {
            var findrecord = await _recordRepository.FindEntityAsync(entity.UserId);
            if (findrecord != null) { await _recordRepository.DeleteEntityAsync(findrecord); }
            _patientContext.User.Remove(entity);
            return await this.SaveChangesAsync();
        }
        public IEnumerable<User> Findentities(Expression<Func<User, bool>> predicate)
        {
            return _patientContext.User.AsQueryable().Where(predicate).ToArray();
        }

        public async Task<User> FindEntityAsync(int entityId)
        {
            return await _patientContext.User.FirstOrDefaultAsync(u => u.UserId == entityId); ;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _patientContext.SaveChangesAsync() > 0);
        }
    }
}
