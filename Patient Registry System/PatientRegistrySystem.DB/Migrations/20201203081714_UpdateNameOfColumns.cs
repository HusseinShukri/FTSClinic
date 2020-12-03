using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientRegistrySystem.DB.Migrations
{
    public partial class UpdateNameOfColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_AspNetUsers_UserId",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_UserId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Record_AspNetUsers_UserID",
                table: "Record");

            migrationBuilder.DropIndex(
                name: "IX_Record_UserID",
                table: "Record");

            migrationBuilder.DropIndex(
                name: "IX_Employee_UserId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_UserId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Record");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Doctor");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Record",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Doctor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "528d12f4-874b-4838-b1f3-1df040f4ddba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d8ba92b4-aaa6-4b23-a888-b88b8a86369e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f9227e35-346f-4408-9538-7725aa6a2bc7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "f06d937b-5cb9-442f-a813-447814e1cd49");

            migrationBuilder.CreateIndex(
                name: "IX_Record_ApplicationUserId",
                table: "Record",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ApplicationUserId",
                table: "Employee",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ApplicationUserId",
                table: "Doctor",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_AspNetUsers_ApplicationUserId",
                table: "Doctor",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_ApplicationUserId",
                table: "Employee",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Record_AspNetUsers_ApplicationUserId",
                table: "Record",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_AspNetUsers_ApplicationUserId",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_ApplicationUserId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Record_AspNetUsers_ApplicationUserId",
                table: "Record");

            migrationBuilder.DropIndex(
                name: "IX_Record_ApplicationUserId",
                table: "Record");

            migrationBuilder.DropIndex(
                name: "IX_Employee_ApplicationUserId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_ApplicationUserId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Record");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Doctor");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Record",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Doctor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "78c76ad4-84a9-45cd-8aad-7cbe152e44d2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "298cd2fd-84f9-45c2-844c-54eee7a49140");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "5eb902ed-1fad-4bc0-af62-c6848d904e59");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "b50baff4-18f0-45ea-b6dc-ba421d624fb1");

            migrationBuilder.CreateIndex(
                name: "IX_Record_UserID",
                table: "Record",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UserId",
                table: "Employee",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_UserId",
                table: "Doctor",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_AspNetUsers_UserId",
                table: "Doctor",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_UserId",
                table: "Employee",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Record_AspNetUsers_UserID",
                table: "Record",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
