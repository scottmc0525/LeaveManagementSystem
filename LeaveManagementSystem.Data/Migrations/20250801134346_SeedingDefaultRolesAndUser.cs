using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e92925ca-0050-4b57-81f8-5641806da52b", null, "Supervisor", "SUPERVISOR" },
                    { "eeddc9d1-ebb1-408a-9b0d-22be8152b110", null, "Administrator", "ADMINISTRATOR" },
                    { "ef5c4a95-3623-4c8b-adec-287d4d46f6da", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "32921979-a794-43bc-9b24-b1e81eb280e8", 0, "7fa2ce96-48e5-4430-905b-8185a91ef4ac", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEMKJW5x9XWy3wBCgxjFtonpduiCcHe8/ndyhHxYXPpN0m5xKxWnbx6vud4uISTMNZA==", null, false, "91245cf8-1f53-4a3d-b294-01dc66f458da", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "eeddc9d1-ebb1-408a-9b0d-22be8152b110", "32921979-a794-43bc-9b24-b1e81eb280e8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e92925ca-0050-4b57-81f8-5641806da52b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef5c4a95-3623-4c8b-adec-287d4d46f6da");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eeddc9d1-ebb1-408a-9b0d-22be8152b110", "32921979-a794-43bc-9b24-b1e81eb280e8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eeddc9d1-ebb1-408a-9b0d-22be8152b110");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32921979-a794-43bc-9b24-b1e81eb280e8");
        }
    }
}
