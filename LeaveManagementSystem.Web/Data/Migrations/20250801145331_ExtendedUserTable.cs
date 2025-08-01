using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32921979-a794-43bc-9b24-b1e81eb280e8",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "122d3d63-3677-4cbc-8827-11fe41e6356b", new DateOnly(1990, 1, 1), "Default", "Admin", "AQAAAAIAAYagAAAAEDmiLYd4ZB7V57WAvy5Y4F/KWz0qZk1c054j2a8e7HETubj1H883Q1A5UPc4V50SbQ==", "44eb88c8-a3ad-4b21-bd28-f3f7610726aa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32921979-a794-43bc-9b24-b1e81eb280e8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fa2ce96-48e5-4430-905b-8185a91ef4ac", "AQAAAAIAAYagAAAAEMKJW5x9XWy3wBCgxjFtonpduiCcHe8/ndyhHxYXPpN0m5xKxWnbx6vud4uISTMNZA==", "91245cf8-1f53-4a3d-b294-01dc66f458da" });
        }
    }
}
