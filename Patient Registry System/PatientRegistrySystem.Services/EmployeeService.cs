using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.DB.Repos;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Dto.Box;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserManagerRepository _userManagerRepository;

        public EmployeeService(IMapper mapper, IUserRepository userRepository,
            IEmployeeRepository employeeRepository, IUserManagerRepository userManagerRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
            _userManagerRepository = userManagerRepository;
        }

        public async Task<IdentityResult> CreateEmployesAsync(ApplicationUserEmployeeBoxDto boxDto)
        {
            var applicationDocotrDto = _userManagerRepository.
                GetApplicationUseerByIdentityClamAsync(boxDto.claimsPrincipalUser);
            if (applicationDocotrDto.Result is null) { return null; }
            boxDto.ApplicationUserDto.User.Employee.Add(new EmployeeDto
            {
                User = boxDto.ApplicationUserDto.User,
                Adress = boxDto.Address,
                Doctor = applicationDocotrDto.Result.User.Doctor.FirstOrDefault()
            });
            return await _employeeRepository.CreateEntityAsync(boxDto.ApplicationUserDto,
                boxDto.Password);
        }

        public async Task<List<UserDto>> GetAllEmployessAsync()
        {
            var userFromDB = await _userRepository.GetAllEmployeesShallowAsync();
            if (!userFromDB.Any()) { return null; }
            return _mapper.Map<List<UserDto>>(userFromDB);
        }
    }
}
