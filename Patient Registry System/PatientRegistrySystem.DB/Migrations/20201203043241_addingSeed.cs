using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientRegistrySystem.DB.Migrations
{
    public partial class addingSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "78c76ad4-84a9-45cd-8aad-7cbe152e44d2", "Admin", "ADMIN" },
                    { 2, "298cd2fd-84f9-45c2-844c-54eee7a49140", "Doctor", "DOCTOR" },
                    { 3, "5eb902ed-1fad-4bc0-af62-c6848d904e59", "Employee", "EMPLOYEE" },
                    { 4, "b50baff4-18f0-45ea-b6dc-ba421d624fb1", "Patient", "PATIENT" }
                });

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
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4);

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
