using PatientRegistrySystem.Domain.Dto;
using System.Collections.Generic;

namespace PatientRegistrySystem.API.ViewModel
{
    public class GetUsersViewModel
    {
        public List<UserDto> Users { get; set; }
    }
}
