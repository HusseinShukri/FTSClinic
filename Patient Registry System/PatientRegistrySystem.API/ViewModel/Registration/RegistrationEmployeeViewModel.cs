using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.API.ViewModel.Registration
{
    public class RegistrationEmployeeViewModel
    {
        [StringLength(30, ErrorMessage = "Max Length is {1}")]
        [Required(ErrorMessage = "The FirstName is required")]
        public string FirstName { get; set; }

        [StringLength(30, ErrorMessage = "Max Length is {1}")]
        [Required(ErrorMessage = "The LastName is required")]
        public string LastName { get; set; }

        [StringLength(30, ErrorMessage = "Max Length is {1}")]
        [Required(ErrorMessage = "The Login is required")]
        public string Login { get; set; }

        [StringLength(30, ErrorMessage = "Max Length is {1}")]
        [Required(ErrorMessage = "The password is required")]
        public string Password { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "The email address is not valid")]
        [StringLength(50, ErrorMessage = "Max Length is {1}")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Phone is required")]
        [StringLength(15, ErrorMessage = "Max Length is {1}")]
        public string Phone { get; set; }

        [Display(Name = "Worke Adress")]
        [Required(ErrorMessage = "The Adress is required")]
        [StringLength(50, ErrorMessage = "Max Length is {1}")]
        public string Address { get; set; }
    }
}
