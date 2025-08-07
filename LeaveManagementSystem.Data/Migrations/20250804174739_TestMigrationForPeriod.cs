using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestMigrationForPeriod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "StartDate",
                table: "Periods",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "EndDate",
                table: "Periods",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32921979-a794-43bc-9b24-b1e81eb280e8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bb87dfd-104e-4e86-96a0-4f45c0f9053f", "AQAAAAIAAYagAAAAEPGcDxYIix+zeTUAuWwVA/r8enay3Yj0eLz6rRFyUN6aXEx3D93IO5Gr4pkBHYanBQ==", "525ace3f-64be-49c7-9597-fa35d09e6e67" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Periods",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Periods",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32921979-a794-43bc-9b24-b1e81eb280e8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "254cc304-fe1b-45ef-b184-d40d903ba44f", "AQAAAAIAAYagAAAAEHmaBFmCRz5JZDXpiUWSyfaSd7Gz056YvXYupgf6ulWBG8qHpVXozDmzaor5/l7Buw==", "64cc8ff2-c1fe-4863-9dce-19194aec0110" });
        }
    }
}
