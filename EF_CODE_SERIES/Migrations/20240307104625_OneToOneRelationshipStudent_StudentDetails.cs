using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_CODE_SERIES.Migrations
{
    /// <inheritdoc />
    public partial class OneToOneRelationshipStudent_StudentDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Student",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Student",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "StudentDetails",
                columns: table => new
                {
                    StudentDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetails", x => x.StudentDetailsId);
                    table.ForeignKey(
                        name: "FK_StudentDetails_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "Name" },
                values: new object[,]
                {
                    { new Guid("2b557ddc-1b9a-4082-99cf-8004a6a4ab62"), 34, "Anu" },
                    { new Guid("4ed991cb-4ede-41ae-b640-369ad5b7d5c4"), 40, "Anish" },
                    { new Guid("8e272370-493f-488b-8c0c-a229a5d309ef"), 1, "Adrian" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetails_StudentId",
                table: "StudentDetails",
                column: "StudentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentDetails");

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("2b557ddc-1b9a-4082-99cf-8004a6a4ab62"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("4ed991cb-4ede-41ae-b640-369ad5b7d5c4"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("8e272370-493f-488b-8c0c-a229a5d309ef"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
