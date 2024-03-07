using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_CODE_SERIES.Migrations
{
    /// <inheritdoc />
    public partial class TestjohnOnModelCreatingSeparateConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("0e5c1f86-84c6-46ca-be00-8736659a694c"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("65ce7d12-416b-4f27-89b8-0cb8d5e611be"));

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[,]
                {
                    { new Guid("06cecb15-3357-4807-a510-216102e2560a"), 1, "Adrian" },
                    { new Guid("2ddfcf0e-ddf7-4ed3-a004-7c494210e100"), 34, "Anu" },
                    { new Guid("ca1c3e28-1505-4fd7-be32-25032f02e2e0"), 40, "Anish" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("06cecb15-3357-4807-a510-216102e2560a"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("2ddfcf0e-ddf7-4ed3-a004-7c494210e100"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("ca1c3e28-1505-4fd7-be32-25032f02e2e0"));

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[,]
                {
                    { new Guid("0e5c1f86-84c6-46ca-be00-8736659a694c"), 25, "Jane Doe" },
                    { new Guid("65ce7d12-416b-4f27-89b8-0cb8d5e611be"), 30, "John Doe" }
                });
        }
    }
}
