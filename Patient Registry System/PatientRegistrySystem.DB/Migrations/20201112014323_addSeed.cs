using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientRegistrySystem.DB.Migrations
{
    public partial class addSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "CompanyId", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "Birzeit", "Birzeit Pharmaceutical Manufacturing Company" },
                    { 2, "Ramallah and Al-Bireh", "Jerusalem Pharmaceuticals" }
                });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "PrescriptionId", "ExpiryDate", "ExtraInformation", "LabTest" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "GASTREX on need", "Stomach Acid Test" },
                    { 2, new DateTime(2020, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "A&D Vit	2 times ber day for 2 weeks", "Vitamins Test" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Name" },
                values: new object[,]
                {
                    { 1, "Patien" },
                    { 2, "Employee" },
                    { 3, "Doctor" },
                    { 4, "Admain" }
                });

            migrationBuilder.InsertData(
                table: "Medicine",
                columns: new[] { "MedicineId", "CompanyId", "Name", "PrescriptionId" },
                values: new object[] { 1, 1, "GASTREX", 1 });

            migrationBuilder.InsertData(
                table: "Medicine",
                columns: new[] { "MedicineId", "CompanyId", "Name", "PrescriptionId" },
                values: new object[] { 2, 1, "GASTREX", 2 });

            migrationBuilder.InsertData(
                table: "Medicine",
                columns: new[] { "MedicineId", "CompanyId", "Name", "PrescriptionId" },
                values: new object[] { 3, 2, "A&D Vit", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicine",
                keyColumn: "MedicineId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicine",
                keyColumn: "MedicineId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicine",
                keyColumn: "MedicineId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "CompanyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "CompanyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "PrescriptionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "PrescriptionId",
                keyValue: 2);
        }
    }
}
