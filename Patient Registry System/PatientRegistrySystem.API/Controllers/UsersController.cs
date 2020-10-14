using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatientRegistrySystem.DB.Filters;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Services;

namespace PatientRegistrySystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        private readonly IUserService _userService;

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
            if (user == null) { return NotFound(); } else { return Ok(user); }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UserDto user)
        {
            if (user == null) { return NotFound(); }
            if (!await _userService.UpdateUserAsync(id, user)) { return NotFound(); }
            else { return RedirectToAction("GetUser", "Users", new { id }); }
        }

        [HttpPost]
        [UserResultFilterAttribute]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
        {
            var createdUser = await _userService.CreateUserAsync(user);
            if (createdUser == null) { return NotFound(); }
            else { return CreatedAtRoute("GetUser", new { id = createdUser.UserId }, createdUser); }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!await _userService.DeleteUserAsync(id)) { return NotFound(); } else { return NoContent(); }
        }
    }
}
