using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PatientRegistrySystem.DB.Models;
using System;

namespace PatientRegistrySystem.DB.Seeds
{
    public static class PationtsSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Role
            modelBuilder.Entity<ApplicationRole>().HasData(
            new ApplicationRole
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN".ToUpper()
            },
             new ApplicationRole
             {
                 Id = 2,
                 Name = "Doctor",
                 NormalizedName = "DOCTOR".ToUpper()
             },
             new ApplicationRole
             {
                 Id = 3,
                 Name = "Employee",
                 NormalizedName = "EMPLOYEE".ToUpper()
             },
             new ApplicationRole
             {
                 Id = 4,
                 Name = "Patient",
                 NormalizedName = "PATIENT".ToUpper()
             }
            );
            #endregion
            #region Company
            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId = 1, Name = "Birzeit Pharmaceutical Manufacturing Company", Address = "Birzeit" },
                new Company { CompanyId = 2, Name = "Jerusalem Pharmaceuticals", Address = "Ramallah and Al-Bireh" }
                );
            #endregion
            #region Medicine
            modelBuilder.Entity<Medicine>().HasData(
                new { MedicineId = 1, CompanyId = 1, Name = "GASTREX", PrescriptionId = 1 },
                new { MedicineId = 2, CompanyId = 1, Name = "GASTREX", PrescriptionId = 2 },
                new { MedicineId = 3, CompanyId = 2, Name = "A&D Vit", PrescriptionId = 2 }
                );
            #endregion
            #region Prescription
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription
                {
                    PrescriptionId = 1,
                    LabTest = "Stomach Acid Test",
                    ExtraInformation = "GASTREX on need",
                    ExpiryDate = new DateTime(2020, 6, 17)

                },
                new Prescription
                {
                    PrescriptionId = 2,
                    LabTest = "Vitamins Test",
                    ExtraInformation = "A&D Vit	2 times ber day for 2 weeks",
                    ExpiryDate = new DateTime(2020, 5, 5)
                });
            #endregion
        }
    }
}
