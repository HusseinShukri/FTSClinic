using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PatientRegistrySystem.API.ControllersHelper;
using PatientRegistrySystem.API.ViewModel;
using PatientRegistrySystem.API.ViewModel.Registration;
using PatientRegistrySystem.DB.Entities;
using PatientRegistrySystem.DB.Roles;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Dto.Box;
using PatientRegistrySystem.Services;
using System.Threading.Tasks;

namespace PatientRegistrySystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = UserRoles.Doctor)]
    public class DoctorsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IEmployeeService _employeeService;

        public DoctorsController(UserManager<ApplicationUser> userManager,
             IMapper mapper,
            IUserService userService,
            IEmployeeService employeeService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userService = userService;
            _employeeService = employeeService;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] RegistrationEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUserEmployeeBoxDto box = new ApplicationUserEmployeeBoxDto()
                {
                    ApplicationUserDto = _mapper.Map<ApplicationUserDto>(model),
                    Address = model.Address,
                    Password = model.Password,
                    claimsPrincipalUser = User
                };
                box.ApplicationUserDto.User = _mapper.Map<UserDto>(model);
                var result = _employeeService.CreateEmployesAsync(box);
                if (result.Result.Succeeded)
                {
                    return Ok("Created");
                }
                else
                {
                    return BadRequest(result.Result.GetErrors());
                }
            }
            else
            {
                return BadRequest(ModelState.GetErrors());
            }
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var doctors = await _employeeService.GetAllEmployessAsync();
            if (doctors == null) { return NotFound(); }
            else { return Ok(new GetUsersViewModel { Users = doctors }); }
        }


        [Route("[action]")]
        [HttpPut]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UserDto user)
        {
            if (user == null) { return BadRequest(); }
            if (!await _userService.UpdateUserAsync(user)) { return BadRequest("User doesn't exist"); }
            else { return Ok(); }
        }

        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (!await _userService.DeleteUserAsync(id)) { return BadRequest("User doesn't exist"); } else { return NoContent(); }
        }

    }
}
