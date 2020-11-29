using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientRegistrySystem.DB.Migrations
{
    public partial class newUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "9afb553c-5a82-41e3-bee3-0470fa0e7ee7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "9da050f0-e1aa-433c-9792-fa85955457a7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "c86bb259-f2e6-4b54-9756-a7fc2adce14e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7213",
                column: "ConcurrencyStamp",
                value: "9cbadbdd-81ea-48c5-b8ba-8049fd7e4e0e");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ba99fb68-4f02-4c09-82fa-3e746a6d0702");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211",
                column: "ConcurrencyStamp",
                value: "441fce78-509f-4e39-9302-79daace811de");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "aff103ef-b48b-463a-8f0f-f9f52def10fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7213",
                column: "ConcurrencyStamp",
                value: "883d6b00-bfc0-44e0-9345-d72ca0cfaaf9");
        }
    }
}
