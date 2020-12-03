using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos.RecordRepository
{
    public interface IRecordRepository
    {
        Task<List<RecordDto>> GetAllRecordsAsync();
        Task<RecordDto> GetRecordAsync(int recordId);
        Task<List<RecordDto>> FindAllUserRecordsAsync(int usersId);
        Task<RecordDto> FindActiveUserRecordAsync(int userId);
        Task<bool> DeleteRecordAsync(RecordDto record);
        Task<bool> CreateRecordAsync(RecordDto record);
        Task<bool> UpdateRecordAsync(RecordDto record);
    }
}
