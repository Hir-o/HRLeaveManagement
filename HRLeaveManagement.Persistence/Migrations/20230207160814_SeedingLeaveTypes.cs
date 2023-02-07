using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRLeaveManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingLeaveTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreatedBy", "CurrentModifiedNumber", "DateCreated", "DefaultDays", "LastModifiedBy", "LastModifiedDate", "LeaveName" },
                values: new object[,]
                {
                    { 1, "Seed User", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Seed User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual Leave" },
                    { 2, "Seed User", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Seed User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sick Leave" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
