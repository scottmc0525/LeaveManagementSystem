using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class RegisterUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32921979-a794-43bc-9b24-b1e81eb280e8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60283979-2fa7-4395-a8e0-031724252b76", "AQAAAAIAAYagAAAAECc+nY2dzyfLUGpIUmwvoBmktNTU1XmZQ4dGwajbykT40/9CZK2dcSchI3ixBKtUzw==", "9268140c-7500-4450-8b77-2923b8e28146" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32921979-a794-43bc-9b24-b1e81eb280e8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "122d3d63-3677-4cbc-8827-11fe41e6356b", "AQAAAAIAAYagAAAAEDmiLYd4ZB7V57WAvy5Y4F/KWz0qZk1c054j2a8e7HETubj1H883Q1A5UPc4V50SbQ==", "44eb88c8-a3ad-4b21-bd28-f3f7610726aa" });
        }
    }
}
