using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class Refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32921979-a794-43bc-9b24-b1e81eb280e8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "801dfcbc-c4a1-4cd6-b427-2e1e58e3b4c5", "AQAAAAIAAYagAAAAEIY0p+w4MFIqf5PdJECSDWAiaSNXpIJ1lld8zshIls9aVrfw4A1X22wlJYwmEE050g==", "35065b11-100b-4480-a6ca-fa3fbec15a30" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32921979-a794-43bc-9b24-b1e81eb280e8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bb87dfd-104e-4e86-96a0-4f45c0f9053f", "AQAAAAIAAYagAAAAEPGcDxYIix+zeTUAuWwVA/r8enay3Yj0eLz6rRFyUN6aXEx3D93IO5Gr4pkBHYanBQ==", "525ace3f-64be-49c7-9597-fa35d09e6e67" });
        }
    }
}
