namespace PatientRegistrySystem.Domain.Dto
{
    public class MedicineDto : IDomainModel
    {
        public string Name { get; set; }
        public CompanyDto CompanyDto { get; set; }
    }
}
