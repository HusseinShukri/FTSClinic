using Microsoft.EntityFrameworkCore;
using PatientRegistrySystem.DB.Contexts;
using PatientRegistrySystem.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos
{
   public class RecordRepository : IRecordRepository
    {
        private readonly PatientContext patientContext;

        public RecordRepository(PatientContext patientContext )
        {
            this.patientContext = patientContext;
        }

        public Task<Record> CreateEntityAsync(Record entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteEntityDeepAsync(Record entity)
        {
            patientContext.Remove(entity);
            return await this.SaveChangesAsync(); 
        }

        public Task<bool> DeleteEntityShallowAsync(Record entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Record> Findentities(Expression<Func<Record, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Record> FindEntitySallowAsync(int entityId)
        {
            //for debugging
            var temp = await patientContext.Record.AsNoTracking().FirstOrDefaultAsync(u => u.UserID == entityId);
            return temp;
        }

        public Task<IEnumerable<Record>> GetAllShallowAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Record> GetIdShallowAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await patientContext.SaveChangesAsync() > 0);
        }

        public Task<bool> UpdateEntity(Record entity)
        {
            throw new NotImplementedException();
        }
    }
}
