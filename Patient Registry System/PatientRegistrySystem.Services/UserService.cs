using AutoMapper;
using PatientRegistrySystem.DB.Repos;
using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientRegistrySystem.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var userFromDB = await _userRepository.GetAllShallowAsync();
            if (!userFromDB.Any()) { return null; }
            return _mapper.Map<UserDto[]>(userFromDB);
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            var userFromDB = await _userRepository.GetIdShallowAsync(id);
            if (userFromDB == null) { return null; }
            var map = _mapper.Map<UserDto>(userFromDB);
            return map;
        }

        public async Task<bool> UpdateUserAsync(UserWithIdDto updatedUser)
        {
            var userFromDB = await _userRepository.FindEntitySallowAsync(updatedUser.UserId);
            if (userFromDB == null) { return false; }
            _mapper.Map(updatedUser, userFromDB);
            return await _userRepository.UpdateEntity(updatedUser);
        }

        public async Task<UserWithIdDto> CreateUserAsync(UserDto newUser)
        {
            return _mapper.Map<UserWithIdDto>(await _userRepository.CreateEntityAsync(_mapper.Map<UserWithIdDto>(newUser)));
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var UserFromDB = await _userRepository.FindEntitySallowAsync(userId);
            if (UserFromDB == null) { return false; }
            return await _userRepository.DeleteEntityShallowAsync(UserFromDB);
        }
    }
}
