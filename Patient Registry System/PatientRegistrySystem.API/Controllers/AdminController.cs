using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientRegistrySystem.API.ControllersHelper;
using PatientRegistrySystem.API.ViewModel;
using PatientRegistrySystem.API.ViewModel.GetRecords;
using PatientRegistrySystem.API.ViewModel.Registration;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Domain.Roles;
using PatientRegistrySystem.Services.DoctorServices;
using System.Threading.Tasks;

namespace PatientRegistrySystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = UserRoles.Admin)]
    public class AdminController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDoctorService _doctorService;

        public AdminController(IMapper mapper,
            IDoctorService doctorService)
        {
            _mapper = mapper;
            _doctorService = doctorService;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] RegistrationDoctoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _doctorService.CreateDoctorAsync(_mapper.Map<ApplicationUserDto>(model), model.Password);
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
        public async Task<IActionResult> GetAllDoctors()
        {
            var result = await _doctorService.GetAllDoctorAsync();
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
        public async Task<IActionResult> GetDoctor(int ApplicationUserId)
        {
            var result = await _doctorService.GetDoctorAsync(ApplicationUserId);
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
        public async Task<IActionResult> UpdateDoctor([FromBody] ApplicationUserDto applicationUserDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _doctorService.UpdateDoctorAsync(applicationUserDto);
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
        public async Task<IActionResult> SoftDeleteDoctor()
        {
            var result = await _doctorService.DeleteDoctorSoftAsync(User);
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
