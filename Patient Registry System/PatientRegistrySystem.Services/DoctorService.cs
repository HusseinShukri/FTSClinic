using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.DB.Repos;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Dto.Box;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IMapper mapper,IUserRepository userRepository,
            IDoctorRepository doctorRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<List<UserDto>> GetAllDoctorssAsync()
        {
            var userFromDB = await _userRepository.GetAllDoctorsShallowAsync();
            if (!userFromDB.Any()) { return null; }
            return _mapper.Map<List<UserDto>>(userFromDB);
        }

        public async Task<IdentityResult> CreateDoctorAsync(ApplicationUserDoctorBoxDto boxDto)
        {
            boxDto.ApplicationUserDto.User.Doctor.Add(new DoctorDto()
            {
                Address1 = boxDto.Address1,
                Address2 = boxDto.Address2,
                User=boxDto.ApplicationUserDto.User
            });
            return await _doctorRepository.CreateEntityAsync(boxDto.ApplicationUserDto, boxDto.Password);
        }
    }
}
