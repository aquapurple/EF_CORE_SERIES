using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_CODE_SERIES.Migrations
{
    /// <inheritdoc />
    public partial class TestjohnOnModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_student",
                table: "student");

            migrationBuilder.RenameTable(
                name: "student",
                newName: "Student");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "StudentId");

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[,]
                {
                    { new Guid("0e5c1f86-84c6-46ca-be00-8736659a694c"), 25, "Jane Doe" },
                    { new Guid("65ce7d12-416b-4f27-89b8-0cb8d5e611be"), 30, "John Doe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("0e5c1f86-84c6-46ca-be00-8736659a694c"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("65ce7d12-416b-4f27-89b8-0cb8d5e611be"));

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "student");

            migrationBuilder.AddPrimaryKey(
                name: "PK_student",
                table: "student",
                column: "StudentId");
        }
    }
}
