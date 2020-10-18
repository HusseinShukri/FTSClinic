using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Services;

namespace PatientRegistrySystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        public UsersController(IUserService userService, IMapper Mapper)
        {
            _userService = userService;
            _mapper = Mapper;
        }
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            if (users == null) { return NotFound(); } else { return Ok(users); }
        }

        [HttpGet("{id:int}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null) { return BadRequest("User doesn't exist"); } else { return Ok(user); }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserWithIdDto user)
        {
            if (user == null) { return BadRequest(); }
            if (!await _userService.UpdateUserAsync(user)) { return BadRequest("User doesn't exist"); }
            else { return RedirectToAction("GetUser", "Users", new { id=user.UserId }); }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
        {
            if (user == null) { return BadRequest(); }
            var createdUser = await _userService.CreateUserAsync(user);
            if (createdUser == null) { return BadRequest("0 users crreated"); }
            else { return CreatedAtRoute("GetUser", new { id = createdUser.UserId }, _mapper.Map<UserDto>(createdUser)); }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!await _userService.DeleteUserAsync(id)) { return BadRequest("User doesn't exist"); } else { return NoContent(); }
        }
    }
}
