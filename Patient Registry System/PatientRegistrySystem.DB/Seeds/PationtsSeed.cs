using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PatientRegistrySystem.DB.Entities;
using System;

namespace PatientRegistrySystem.DB.Seeds
{
    public static class PationtsSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Role
            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                Name = "Admin",
                NormalizedName = "ADMIN".ToUpper()
            },
             new IdentityRole
             {
                 Id = "2c5e174e-3b0e-446f-86af-483d56fd7211",
                 Name = "Doctor",
                 NormalizedName = "DOCTOR".ToUpper()
             },
             new IdentityRole
             {
                 Id = "2c5e174e-3b0e-446f-86af-483d56fd7212",
                 Name = "Employee",
                 NormalizedName = "EMPLOYEE".ToUpper()
             },
             new IdentityRole
             {
                 Id = "2c5e174e-3b0e-446f-86af-483d56fd7213",
                 Name = "Patient",
                 NormalizedName = "PATIENT".ToUpper()
             }
            );

            //ApplicationUser applicationUser = new ApplicationUser()
            //{
            //    Id = "41e8cb36-0aa8-4f6a-ba9f-31c5c245c35e",
            //    UserName = "Hassan@Qadmany.com",
            //    NormalizedUserName = "HASSAN@QADMANY.COM",
            //    Email = "Hassan@Qadmany.com",
            //    NormalizedEmail = "HASSAN@QADMANY.COM",
            //    EmailConfirmed = false,
            //    PasswordHash = "AQAAAAEAACcQAAAAEJWroDI7TVOGvWwOoo2hM8Z0cYuUB5BYxFrHaSVJMzjhPwIeP5Yc8U0vRdAM2oZBnw==",
            //    SecurityStamp = "QEWFJBBO2O2NF5BHAUZWEEXQTWCF4BTQ",
            //    ConcurrencyStamp = "81420763-f5a3-4e40-80a6-bdfa6b85b5d2",
            //    PhoneNumber = "1234",
            //    PhoneNumberConfirmed = false,
            //    TwoFactorEnabled = false,
            //    LockoutEnd = null,
            //    LockoutEnabled = true,
            //    AccessFailedCount = 0,
            //    User = new User
            //    {
            //        UserId = 1,
            //        IsDeleted = false,
            //        FirstName = "Hassan",
            //        LastName = "Qadmany",
            //        Login = "1234",
            //    }
            //};
            //applicationUser.User.ApplicationUser = applicationUser;
            //applicationUser.User.ApplicationUserId = applicationUser.Id;
            //modelBuilder.Entity<ApplicationUser>().HasData(applicationUser);

            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
            //        UserId = "41e8cb36-0aa8-4f6a-ba9f-31c5c245c35e"
            //    });
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
