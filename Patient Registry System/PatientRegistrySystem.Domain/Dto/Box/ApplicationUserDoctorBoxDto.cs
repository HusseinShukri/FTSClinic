namespace PatientRegistrySystem.Domain.Dto.Box
{
   public  class ApplicationUserDoctorBoxDto
    {
        public ApplicationUserDto ApplicationUserDto { get; set; }
        public string Password { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
    }
}
