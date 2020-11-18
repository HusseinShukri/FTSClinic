using System.ComponentModel.DataAnnotations;

namespace PatientRegistrySystem.API.ViewModel.Registration
{
    public class RegistrationDoctoreViewModel
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

        [Display(Name = "First Adress")]
        [Required(ErrorMessage = "The first Adress is required")]
        [StringLength(50, ErrorMessage = "Max Length is {1}")]
        public string Adress1 { get; set; }

        [Display(Name = "Second Adress")]
        [StringLength(50, ErrorMessage = "Max Length is {1}")]
        public string Adress2 { get; set; }
    }
}
