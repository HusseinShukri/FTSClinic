using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatientRegistrySystem.DB.Contexts;
using PatientRegistrySystem.DB.Models;
using PatientRegistrySystem.DB.Models.DbModels;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.DbGenericRepository
{
    public class DbGeneric<DbEntity, DomainEntity> : IDbGeneric<DbEntity, DomainEntity> where DbEntity : class, IDbModel where DomainEntity : IDomainModel
    {
        private readonly ApplicationIdentityDbContext _applicationIdentityDbContext;
        private readonly IMapper _mapper;
        private DbSet<DbEntity> _entities;

        public DbGeneric(ApplicationIdentityDbContext applicationIdentityDbContext, IMapper mapper)
        {
            _entities = applicationIdentityDbContext.Set<DbEntity>();
            _applicationIdentityDbContext = applicationIdentityDbContext;
            _mapper = mapper;
        }

        public async Task<bool> CreateEntityAsync(DomainEntity entity)
        {
            if (entity.GetType().Equals(typeof(Record))
                || entity.GetType().Equals(typeof(Prescription))
                || entity.GetType().Equals(typeof(Company))
                || entity.GetType().Equals(typeof(Medicine)))
            {
                await _entities.AddAsync(_mapper.Map<DbEntity>(entity));
                return await SaveChangesAsync();
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteEntityDeepAsync(DomainEntity entity)
        {
            if (entity.GetType().Equals(typeof(Record))
                || entity.GetType().Equals(typeof(Prescription))
                || entity.GetType().Equals(typeof(Company))
                || entity.GetType().Equals(typeof(Medicine)))
            {
                _entities.Remove(_mapper.Map<DbEntity>(entity));
                return await SaveChangesAsync();
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteEntitySoftAsync(DomainEntity entity)
        {
            if (entity.GetType().Equals(typeof(Record))
                || entity.GetType().Equals(typeof(Prescription))
                || entity.GetType().Equals(typeof(Company))
                || entity.GetType().Equals(typeof(Medicine)))
            {
                _entities.Update(_mapper.Map<DbEntity>(entity));
                return await SaveChangesAsync();
            }
            else
            {
                return false;
            }
        }

        public async Task<List<DomainEntity>> FindAllEntitiesAsync()
        {
            if (typeof(DbEntity) == typeof(Record))
            {
                var result = _mapper.Map<List<RecordDto>>(await _applicationIdentityDbContext.Record
                    .AsNoTracking().Where(s => (s.Status != 1)).ToListAsync());
                return (List<DomainEntity>)(object)result;
            }
            else if (typeof(DbEntity) == typeof(Prescription))
            {
                var result = _mapper.Map<List<PrescriptionDto>>(await _applicationIdentityDbContext.Prescription
                    .AsNoTracking().ToListAsync());
                return (List<DomainEntity>)(object)result;
            }
            else if (typeof(DbEntity) == typeof(Company))
            {
                var result = _mapper.Map<List<CompanyDto>>(await _applicationIdentityDbContext.Company
                    .AsNoTracking().ToListAsync());
                return (List<DomainEntity>)(object)result;
            }
            else if (typeof(DbEntity) == typeof(Medicine))
            {
                var result = _mapper.Map<List<MedicineDto>>(await _applicationIdentityDbContext.Medicine
                    .AsNoTracking().ToListAsync());
                return (List<DomainEntity>)(object)result;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<DomainEntity>> FindAllEntitiesAsync(int entityId)
        {
            if (typeof(DbEntity) == typeof(Record))
            {
                var result = _mapper.Map<List<RecordDto>>(await _applicationIdentityDbContext.Record
                    .AsNoTracking().Where(s => (s.Status != 1) && (s.ApplicationUserId == entityId)).ToListAsync());
                return (List<DomainEntity>)(object)result;
            }
            else if (typeof(DbEntity) == typeof(Prescription))
            {
                var result = _mapper.Map<List<PrescriptionDto>>(await _applicationIdentityDbContext.Prescription
                    .AsNoTracking().Where(s => s.PrescriptionId == entityId).ToListAsync());
                return (List<DomainEntity>)(object)result;
            }
            else if (typeof(DbEntity) == typeof(Company))
            {
                var result = _mapper.Map<List<CompanyDto>>(await _applicationIdentityDbContext.Company
                    .AsNoTracking().Where(s => s.CompanyId == entityId).ToListAsync());
                return (List<DomainEntity>)(object)result;
            }
            else if (typeof(DbEntity) == typeof(Medicine))
            {
                var result = _mapper.Map<List<MedicineDto>>(await _applicationIdentityDbContext.Medicine
                    .AsNoTracking().Where(s => s.MedicineId == entityId).ToListAsync());
                return (List<DomainEntity>)(object)result;
            }
            else
            {
                return null;
            }
        }

        public async Task<DomainEntity> FindEntityAsync(int entityId)
        {
            if (typeof(DbEntity) == typeof(Record))
            {
                var result = _mapper.Map<RecordDto>(await _applicationIdentityDbContext.Record
                    .AsNoTracking().FirstOrDefaultAsync(s => (s.Status != 1) && (s.ApplicationUserId == entityId)));
                return (DomainEntity)(object)result;
            }
            else if (typeof(DbEntity) == typeof(Prescription))
            {
                var result = _mapper.Map<PrescriptionDto>(await _applicationIdentityDbContext.Prescription
                    .AsNoTracking().FirstOrDefaultAsync(s => s.PrescriptionId == entityId));
                return (DomainEntity)(object)result;
            }
            else if (typeof(DbEntity) == typeof(Company))
            {
                var result = _mapper.Map<CompanyDto>(await _applicationIdentityDbContext.Company
                    .AsNoTracking().FirstOrDefaultAsync(s => s.CompanyId == entityId));
                return (DomainEntity)(object)result;
            }
            else if (typeof(DbEntity) == typeof(Medicine))
            {
                var result = _mapper.Map<MedicineDto>(await _applicationIdentityDbContext.Medicine
                    .AsNoTracking().FirstOrDefaultAsync(s => s.MedicineId == entityId));
                return (DomainEntity)(object)result;
            }
            else
            {
                return (DomainEntity)(object)null;
            }
        }

        public async Task<List<DomainEntity>> GetAllEntitiesAsync()
        {
            if (typeof(DbEntity) == typeof(Record))
            {
                return (List<DomainEntity>)(object)_mapper.Map<List<RecordDto>>(await _applicationIdentityDbContext.Record
                    .AsNoTracking().Include(s => s.ApplicationUser).Include(s => s.Doctor)
                    .Include(s => s.Employee).Include(s => s.Prescription).ToListAsync());
            }
            else if (typeof(DbEntity) == typeof(Prescription))
            {
                return (List<DomainEntity>)(object)_mapper.Map<List<PrescriptionDto>>(await _applicationIdentityDbContext.Prescription
                   .AsNoTracking().Include(s => s.Medicines).ToListAsync());
            }
            else if (typeof(DbEntity) == typeof(Company))
            {
                return (List<DomainEntity>)(object)_mapper.Map<List<CompanyDto>>(await _applicationIdentityDbContext.Company
                    .AsNoTracking().Include(s => s.Medicine).ToListAsync());
            }
            else if (typeof(DbEntity) == typeof(Medicine))
            {
                return (List<DomainEntity>)(object)_mapper.Map<List<MedicineDto>>(await _applicationIdentityDbContext.Medicine
                    .AsNoTracking().Include(s => s.Company).ToListAsync());
            }
            else
            {
                return null;
            }
        }

        public async Task<DomainEntity> GetEntityAsync(int entityId)
        {
            if (typeof(DbEntity) == typeof(Record))
            {
                return (DomainEntity)(object)_mapper.Map<RecordDto>(await _applicationIdentityDbContext.Record
                    .AsNoTracking().Include(s => s.ApplicationUser).Include(s => s.Doctor)
                    .Include(s => s.Employee).Include(s => s.Prescription).FirstOrDefaultAsync(s => s.ApplicationUserId == entityId));
            }
            else if (typeof(DbEntity) == typeof(Prescription))
            {
                return (DomainEntity)(object)_mapper.Map<PrescriptionDto>(await _applicationIdentityDbContext.Prescription
                   .AsNoTracking().Include(s => s.Medicines).FirstOrDefaultAsync(s => s.PrescriptionId == entityId));
            }
            else if (typeof(DbEntity) == typeof(Company))
            {
                return (DomainEntity)(object)_mapper.Map<CompanyDto>(await _applicationIdentityDbContext.Company
                    .AsNoTracking().Include(s => s.Medicine).FirstOrDefaultAsync(s => s.CompanyId == entityId));
            }
            else if (typeof(DbEntity) == typeof(Medicine))
            {
                return (DomainEntity)(object)_mapper.Map<MedicineDto>(await _applicationIdentityDbContext.Medicine
                    .AsNoTracking().Include(s => s.Company).FirstOrDefaultAsync(s => s.MedicineId == entityId));
            }
            else
            {
                return (DomainEntity)(object)null;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _applicationIdentityDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateEntityAsync(DomainEntity entity)
        {
            if (entity.GetType().Equals(typeof(Record))
                || entity.GetType().Equals(typeof(Prescription))
                || entity.GetType().Equals(typeof(Company))
                || entity.GetType().Equals(typeof(Medicine)))
            {
                _entities.Update(_mapper.Map<DbEntity>(entity));
                return await SaveChangesAsync();
            }
            else
            {
                return false;
            }
        }
    }
}
