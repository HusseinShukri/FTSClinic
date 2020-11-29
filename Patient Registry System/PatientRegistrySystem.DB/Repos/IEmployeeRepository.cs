﻿using Microsoft.AspNetCore.Identity;
using PatientRegistrySystem.Domain.Dto;
using System.Threading.Tasks;

namespace PatientRegistrySystem.DB.Repos
{
   public interface IEmployeeRepository : IGenericRepository<IdentityResult, ApplicationUserDto>
    {
        Task<IdentityResult> CreateEntityAsync(ApplicationUserDto applicationUser, string Password);
    }
}
