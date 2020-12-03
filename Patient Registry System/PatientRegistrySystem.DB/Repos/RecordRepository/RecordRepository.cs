using PatientRegistrySystem.DB.Contexts;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.DB.Repos.GenericRepository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using PatientRegistrySystem.DB.Models;

namespace PatientRegistrySystem.DB.Repos.RecordRepository
{
    public class RecordRepository : IRecordRepository
    {
        private readonly ApplicationIdentityDbContext _ApplicationIdentityDbContext;
        private readonly IGenericRepository<Record> _genericRepository;
        private readonly IMapper _mapper;

        public RecordRepository(ApplicationIdentityDbContext applicationIdentityDbContext
            , IGenericRepository<Record> genericRepository
            , IMapper mapper)
        {
            _ApplicationIdentityDbContext = applicationIdentityDbContext;
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async  Task<List<RecordDto>> GetAllRecordsAsync()
        {
            return  _mapper.Map<List<RecordDto>>( await _ApplicationIdentityDbContext.Record
                .AsNoTracking().ToListAsync());
        }

        public async Task<RecordDto> GetRecordAsync(int recordId)
        {
            return _mapper.Map<RecordDto>(await _ApplicationIdentityDbContext.Record
                .AsNoTracking().FirstOrDefaultAsync(r=>r.RecordId==recordId));
        }

        public async Task<List<RecordDto>> FindAllUserRecordsAsync(int usersId)
        {
            return _mapper.Map<List<RecordDto>>(await _ApplicationIdentityDbContext.Record
                .AsNoTracking().Where(s => (s.Status != 1) && (s.ApplicationUserId == usersId)).ToListAsync());
        }

        public async Task<RecordDto> FindActiveUserRecordAsync(int userId)
        {
            return _mapper.Map<RecordDto>(await _ApplicationIdentityDbContext.Record
                .AsNoTracking().Where(s=>s.Status!=1).FirstOrDefaultAsync(u=>u.ApplicationUserId==userId));
        }

        public async Task<bool> DeleteRecordAsync(RecordDto record)
        {
            return await _genericRepository.DeleteEntityDeepAsync(_mapper.Map<Record>(record));
        }

        public async Task<bool> CreateRecordAsync(RecordDto record)
        {
            return await _genericRepository.CreateEntitySoftAsync(_mapper.Map<Record>(record));
        }

        public async Task<bool> UpdateRecordAsync(RecordDto record)
        {
            return await _genericRepository.UpdateEntitySoftAsync(_mapper.Map<Record>(record));
        }
    }
}
