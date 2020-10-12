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
        private readonly PatientContext patientContext;
        private readonly IRecordRepository recordRepository;

        public UserRepository(PatientContext patientContext, IRecordRepository recordRepository)
        {
            this.patientContext = patientContext;
            this.recordRepository = recordRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await patientContext.User
                    .Include(e => e.Employee)
                    .Include(d => d.Doctor)
                    .Include(ur => ur.UserRole).ThenInclude(rr => rr.Role)
                    .Include(r => r.Record)
                    .ToArrayAsync();
        }

        public async Task<User> GetIdAsync(int entityId)
        {
            return await patientContext.User
                    .Include(e => e.Employee).Where(u => u.UserId == entityId)
                    .Include(d => d.Employee)
                    .Include(ur => ur.UserRole).ThenInclude(rr => rr.Role)
                    .Include(r => r.Record)
                    .FirstOrDefaultAsync(u => u.UserId == entityId);
        }

        public async Task<User> CreateEntityAsync(User entity)
        {
            await patientContext.User.AddAsync(entity);
            await this.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateEntity(User entity)
        {
            patientContext.User.Update(entity);
            return await this.SaveChangesAsync();
        }

        public async Task<bool> DeleteEntityAsync(User entity)
        {
            var Findrecord = await recordRepository.FindEntityAsync(entity.UserId);
            if (Findrecord != null) { await recordRepository.DeleteEntityAsync(Findrecord); }
            patientContext.User.Remove(entity);
            return await this.SaveChangesAsync(); ;
        }
        //todo
        public IEnumerable<User> Findentities(Expression<Func<User, bool>> predicate)
        {
            User[] users;
            using (var context = new PatientContext())
            {
                users = context.User.AsQueryable().Where(predicate).ToArray();
            }
            return users;
        }

        public async Task<User> FindEntityAsync(int entityId)
        {
            return await patientContext.User.FirstOrDefaultAsync(u => u.UserId == entityId); ;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await patientContext.SaveChangesAsync() > 0);
        }
    }
}
