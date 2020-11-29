﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientRegistrySystem.API.ViewModel;
using PatientRegistrySystem.API.ViewModel.Registration;
using PatientRegistrySystem.Domain.Dto;
using PatientRegistrySystem.Services;
using PatientRegistrySystem.API.ControllersHelper;
using System.Threading.Tasks;
using PatientRegistrySystem.Domain.Dto.Box;
using PatientRegistrySystem.DB.Roles;

namespace PatientRegistrySystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = UserRoles.Admin)]
    public class AdminController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IDoctorService _doctorService;

        public AdminController(IMapper mapper,
            IUserService userService,
            IDoctorService doctorService)
        {
            _mapper = mapper;
            _userService = userService;
            _doctorService = doctorService;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] RegistrationDoctoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUserDoctorBoxDto box = new ApplicationUserDoctorBoxDto()
                {
                    ApplicationUserDto = _mapper.Map<ApplicationUserDto>(model),
                    Address1 = model.Address1,
                    Address2 = model.Address2,
                    Password = model.Password
                };
                box.ApplicationUserDto.User = _mapper.Map<UserDto>(model);
                var result = _doctorService.CreateDoctorAsync(box);
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
            var doctors = await _doctorService.GetAllDoctorssAsync();
            if (doctors == null) { return NotFound(); }
            else { return Ok(new GetUsersViewModel { Users = doctors }); }
            return null;
        }


        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> UpdateDoctor([FromBody] UserDto user)
        {
            if (user == null) { return BadRequest(); }
            if (!await _userService.UpdateUserAsync(user)) { return BadRequest("User doesn't exist"); }
            else { return Ok(); }
        }

        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            if (!await _userService.DeleteUserAsync(id)) { return BadRequest("User doesn't exist"); } else { return NoContent(); }
        }
    }
}
