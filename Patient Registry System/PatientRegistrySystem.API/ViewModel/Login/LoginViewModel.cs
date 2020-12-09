using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.API.ViewModel.Login
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
