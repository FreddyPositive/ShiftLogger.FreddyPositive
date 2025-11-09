using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShiftLogger.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployeeDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeeList",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 16, 5, 49, 50, 880, DateTimeKind.Unspecified), "Raj" },
                    { 2, new DateTime(2025, 9, 17, 8, 23, 10, 320, DateTimeKind.Unspecified), "Kumar" },
                    { 3, new DateTime(2025, 9, 18, 10, 11, 22, 500, DateTimeKind.Unspecified), "Priya" },
                    { 4, new DateTime(2025, 9, 19, 12, 45, 35, 250, DateTimeKind.Unspecified), "Suresh" },
                    { 5, new DateTime(2025, 9, 20, 14, 5, 45, 880, DateTimeKind.Unspecified), "Anita" },
                    { 6, new DateTime(2025, 9, 21, 16, 15, 55, 123, DateTimeKind.Unspecified), "Manoj" },
                    { 7, new DateTime(2025, 9, 22, 18, 25, 35, 600, DateTimeKind.Unspecified), "Divya" },
                    { 8, new DateTime(2025, 9, 23, 19, 30, 15, 770, DateTimeKind.Unspecified), "Vijay" },
                    { 9, new DateTime(2025, 9, 24, 20, 45, 55, 980, DateTimeKind.Unspecified), "Sneha" },
                    { 10, new DateTime(2025, 9, 25, 21, 55, 5, 440, DateTimeKind.Unspecified), "Arun" },
                    { 11, new DateTime(2025, 9, 26, 22, 10, 30, 210, DateTimeKind.Unspecified), "Lakshmi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeList",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeList",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeeList",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmployeeList",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EmployeeList",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EmployeeList",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EmployeeList",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EmployeeList",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EmployeeList",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EmployeeList",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "EmployeeList",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
