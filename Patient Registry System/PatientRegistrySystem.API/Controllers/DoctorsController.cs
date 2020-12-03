using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PatientRegistrySystem.API.ControllersHelper;
using PatientRegistrySystem.API.ViewModel;
using PatientRegistrySystem.API.ViewModel.GetRecords;
using PatientRegistrySystem.API.ViewModel.Registration;
using PatientRegistrySystem.DB.Models;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Roles;
using PatientRegistrySystem.Services.EmployeeServices;
using System.Threading.Tasks;

namespace PatientRegistrySystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = UserRoles.Doctor)]
    public class DoctorsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;

        public DoctorsController(IMapper mapper,IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] RegistrationDoctoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _employeeService.CreateEmployeeAsync(_mapper.Map<ApplicationUserDto>(model), model.Password);
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
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _employeeService.GetAllEmployeeAsync();
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new GetUsersViewModel
                {
                    Users = result
                });
            }
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetEmployee(int ApplicationUserId)
        {
            var result = await _employeeService.GetEmployeeAsync(ApplicationUserId);
            if (result == null)
            {
                return BadRequest("Bad Inputs");
            }
            else
            {
                return Ok(new GetUserViewModel { User = result });
            }
        }

        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] ApplicationUserDto applicationUserDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _employeeService.UpdateEmployeeAsync(applicationUserDto);
                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(result.GetErrors());
                }
            }
            else
            {
                return BadRequest(ModelState.GetErrors());
            }
        }

        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> SoftDeleteEmployee()
        {
            var result = await _employeeService.DeleteEmployeeSoftAsync(User);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.GetErrors());
            }
        }


    }

}
